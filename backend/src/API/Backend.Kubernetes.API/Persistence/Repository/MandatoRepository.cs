using Backend.Kubernetes.API.Domain.Exceptions;
using Backend.Kubernetes.API.Persistence.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Threading.Tasks;

namespace Backend.Kubernetes.API.Persistence.Repository
{
    public class MandatoRepository : IMandatoRepository
    {
        private readonly IConfiguration _configuration;

        public MandatoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        /// <summary>
        /// Valida si un cliente tiene un beneficiario tipo conyuge
        /// </summary>
        /// <param name="productCode"> Codigo de producto </param>
        /// <param name="insurancePolicy"> Numero de poliza </param>
        /// <returns>true o false</returns>
        public async Task<bool> HasSpouse(int productCode, int insurancePolicy)
        {
            try
            {
                using var db = new OracleConnection(_configuration.GetConnectionString("PensionesDB"));
                var parameters = new { productCode, insurancePolicy };

                string query = @$" SELECT DISTINCT COUNT(1)
                            FROM PENSIONES.BENEFICIARIOS beneficiario,
                                 PENSIONES.PERSNAT       PERSNAT,
                                 PENSIONES.CODIGOS       codigoRelacion,
                                 PENSIONES.BENEFICIOS    beneficio
                           WHERE 
                                 beneficiario.ben_linea = 3 
                             AND beneficiario.ben_producto = :productCode 
                             AND beneficiario.ben_documento = 2 
                             AND beneficiario.ben_poliza = :insurancePolicy
                             AND beneficiario.ben_relacion = 4         
                             AND PERSNAT.nat_id = beneficiario.ben_beneficiario
                             AND codigoRelacion.cod_int_num = beneficiario.ben_relacion
                             AND codigoRelacion.cod_template = 'TR07-RELACION-BENEFICIARIOS'
                             AND beneficio.bnf_linea = beneficiario.ben_linea
                             AND beneficio.bnf_producto = beneficiario.ben_producto
                             AND beneficio.bnf_documento = beneficiario.ben_documento
                             AND beneficio.bnf_poliza = beneficiario.ben_poliza
                             AND beneficio.bnf_beneficiario = beneficiario.ben_beneficiario
                             AND beneficio.bnf_estado = 0";

                int spouces = await db.QueryFirstOrDefaultAsync<int>(query, parameters);

                return spouces > 0;
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex.Message, ex);
            }
        }

        public async Task<bool> HasValidMandate(int rutWithOutDv)
        {
            try
            {
                using var db = new OracleConnection(_configuration.GetConnectionString("PensionesDB"));
                var parametes = new { rutWithOutDv };
                string query = @$" SELECT  COUNT(1)
                                    FROM
                                    PENSIONES.MANDATO_AMPLIO
                                    WHERE
                                    MAN_RUT_MAND = :rutWithOutDv 
                                    AND MAN_SI_NO = 'SI'
                                    AND MAN_VIGENCIA = 'V'";

                var mandates = await db.QueryFirstOrDefaultAsync<int>(query, parametes);

                return mandates > 0;
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex.Message, ex);
            }

        }

        public async Task<bool> HasCausante(int rutWithOutDv, int insurancePolicy)
        {
            try
            {
                using var db = new OracleConnection(_configuration.GetConnectionString("PensionesDB"));
                var parameters = new { rutWithOutDv, insurancePolicy };
                string query = @$"  SELECT PERSNAT.nat_id nat_id,
                                    PERSNAT.nat_nombre nat_nombre,
                                    PERSNAT.nat_ap_pat nat_ap_pat,
                                    PERSNAT.nat_ap_mat nat_ap_mat,
                                    PERSNAT.nat_numrut nat_numrut,
                                    PERSNAT.nat_dv nat_dv,
                                    PERSNAT.nat_fec_muerte,
                                    PERSNAT.NAT_FEC_NACIM
                            FROM PENSIONES.PERSNAT PERSNAT, PENSIONES.POLIZAS p
                            WHERE PERSNAT.nat_numrut = :rutWithOutDv
                            and p.pol_poliza = :insurancePolicy
                            AND p.POL_CONTRATANTE = PERSNAT.NAT_ID";

                var causante = await db.QueryFirstOrDefaultAsync<int>(query, parameters);

                return causante > 0;
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex.Message, ex);
            }

        }

        public async Task<bool> SaveMandate(int rut, string dv, bool isMandateSigned, string executive)
        {
            try
            {
                using var db = new OracleConnection(_configuration.GetConnectionString("PensionesDB"));
                var mandateDate = DateTime.Now;
                var mandateSigned = isMandateSigned ? "SI" : "NO";
                var parameters = new { rut, dv, mandateSigned, mandateDate, executive };

                string query = @$"  INSERT INTO PENSIONES.MANDATO_AMPLIO
                                  (
                                  MAN_RUT_MAND
                                  , MAN_DV_MAND
                                  , MAN_SI_NO
                                  , MAN_FEC_MANDATO
                                  , MAN_USUARIO_INGRESO
                                  , MAN_SISTEMA_ORIGEN
                                  , MAN_VIGENCIA
                                  )
                                VALUES
                                  (
                                  :rut
                                  , :dv
                                  , :mandateSigned
                                  , :mandateDate
                                  , :executive
                                  , 5
                                  , 'V'
                                  )";

                var res = await db.ExecuteAsync(query, parameters);
                return res > 0;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("No se pudo grabar registro de Mandato", ex);
            }
        }
    }
}
