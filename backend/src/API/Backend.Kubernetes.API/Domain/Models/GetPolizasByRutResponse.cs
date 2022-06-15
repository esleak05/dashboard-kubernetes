using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Backend.Kubernetes.API.Domain.Models
{
    public class GetPolizasByRutResponse
    {
        [JsonProperty("polizasVI")]
        public List<PolizasVI> PolizasVI { get; set; }

        [JsonProperty("polizasRV")]
        public List<PolizasRV> PolizasRV { get; set; }

        [JsonProperty("polizasRP")]
        public List<PolizasRP> PolizasRP { get; set; }

        [JsonProperty("polizasCC")]
        public List<PolizasCC> PolizasCC { get; set; }
    }
    public class Producto
    {
        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("tipo")]
        public string Tipo { get; set; }

        [JsonProperty("codigo")]
        public string Codigo { get; set; }

        [JsonProperty("textoDescriptivo")]
        public string TextoDescriptivo { get; set; }

        [JsonProperty("lineaNegocio")]
        public string LineaNegocio { get; set; }
    }

    public class AgenteAtencion
    {
        [JsonProperty("rut")]
        public string Rut { get; set; }

        [JsonProperty("nombres")]
        public string Nombres { get; set; }

        [JsonProperty("apellidoPaterno")]
        public string ApellidoPaterno { get; set; }

        [JsonProperty("apellidoMaterno")]
        public string ApellidoMaterno { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("telefono")]
        public string Telefono { get; set; }
    }

    public class Beneficiario
    {
        [JsonProperty("rut")]
        public string Rut { get; set; }

        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("fechaNacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [JsonProperty("numero")]
        public int Numero { get; set; }

        [JsonProperty("independiente")]
        public bool Independiente { get; set; }

        [JsonProperty("fechaFallecimiento")]
        public DateTime FechaFallecimiento { get; set; }

        [JsonProperty("porcentajeBeneficio")]
        public int PorcentajeBeneficio { get; set; }
    }

    public class Cobertura
    {
        [JsonProperty("codigo")]
        public string Codigo { get; set; }

        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("edadMaxima")]
        public int EdadMaxima { get; set; }

        [JsonProperty("cad")]
        public string Cad { get; set; }

        [JsonProperty("pol")]
        public string Pol { get; set; }

        [JsonProperty("seleccionada")]
        public bool Seleccionada { get; set; }

        [JsonProperty("tipoCobertura")]
        public string TipoCobertura { get; set; }

        [JsonProperty("beneficiarios")]
        public List<Beneficiario> Beneficiarios { get; set; }
    }

    public class MovimientoVP
    {
        [JsonProperty("fechaUltimoVP")]
        public DateTime FechaUltimoVP { get; set; }

        [JsonProperty("montoUltimoVP")]
        public double MontoUltimoVP { get; set; }

        [JsonProperty("fechaUltimoCierreVP")]
        public DateTime FechaUltimoCierreVP { get; set; }

        [JsonProperty("montoUltimoCierreVP")]
        public double MontoUltimoCierreVP { get; set; }

        [JsonProperty("valorUF")]
        public double ValorUF { get; set; }
    }

    public class PolizasVI
    {
        [JsonProperty("poliza")]
        public string Poliza { get; set; }

        [JsonProperty("estado")]
        public string Estado { get; set; }

        [JsonProperty("fechaEstado")]
        public DateTime FechaEstado { get; set; }

        [JsonProperty("fechaInicioVigencia")]
        public DateTime FechaInicioVigencia { get; set; }

        [JsonProperty("fechaTerminoVigencia")]
        public DateTime FechaTerminoVigencia { get; set; }

        [JsonProperty("producto")]
        public Producto Producto { get; set; }

        [JsonProperty("fechaUltimoPago")]
        public DateTime FechaUltimoPago { get; set; }

        [JsonProperty("codigoProducto")]
        public string CodigoProducto { get; set; }

        [JsonProperty("fecu")]
        public int Fecu { get; set; }

        [JsonProperty("primaPlaneada")]
        public int PrimaPlaneada { get; set; }

        [JsonProperty("agenteAtencion")]
        public AgenteAtencion AgenteAtencion { get; set; }

        [JsonProperty("coberturas")]
        public List<Cobertura> Coberturas { get; set; }

        [JsonProperty("movimientoVP")]
        public MovimientoVP MovimientoVP { get; set; }
    }

    public class PolizasRV
    {
        [JsonProperty("poliza")]
        public string Poliza { get; set; }

        [JsonProperty("estado")]
        public string Estado { get; set; }

        [JsonProperty("fechaEstado")]
        public DateTime FechaEstado { get; set; }

        [JsonProperty("fechaInicioVigencia")]
        public DateTime FechaInicioVigencia { get; set; }

        [JsonProperty("fechaTerminoVigencia")]
        public DateTime FechaTerminoVigencia { get; set; }

        [JsonProperty("producto")]
        public Producto Producto { get; set; }

        [JsonProperty("codigoProducto")]
        public string CodigoProducto { get; set; }

        [JsonProperty("montoPensionMensual")]
        public double MontoPensionMensual { get; set; }

        [JsonProperty("porcentajePension")]
        public double PorcentajePension { get; set; }

        [JsonProperty("pensionReferencia")]
        public double PensionReferencia { get; set; }

        [JsonProperty("modalidadPension")]
        public string ModalidadPension { get; set; }

        [JsonProperty("cobertura")]
        public string Cobertura { get; set; }

        [JsonProperty("numeroCargas")]
        public int NumeroCargas { get; set; }

        [JsonProperty("periodoGarantizado")]
        public int PeriodoGarantizado { get; set; }

        [JsonProperty("periodoDiferido")]
        public int PeriodoDiferido { get; set; }

        [JsonProperty("codigoOrigen")]
        public string CodigoOrigen { get; set; }

        [JsonProperty("cic")]
        public int Cic { get; set; }

        [JsonProperty("fecu")]
        public int Fecu { get; set; }

        [JsonProperty("fechaProximoPago")]
        public string FechaProximoPago { get; set; }

        [JsonProperty("endoso")]
        public int Endoso { get; set; }

        [JsonProperty("grupoPago")]
        public int GrupoPago { get; set; }
    }

    public class PolizasRP
    {
        [JsonProperty("poliza")]
        public string Poliza { get; set; }

        [JsonProperty("estado")]
        public string Estado { get; set; }

        [JsonProperty("fechaEstado")]
        public DateTime FechaEstado { get; set; }

        [JsonProperty("fechaInicioVigencia")]
        public DateTime FechaInicioVigencia { get; set; }

        [JsonProperty("fechaTerminoVigencia")]
        public DateTime FechaTerminoVigencia { get; set; }

        [JsonProperty("producto")]
        public Producto Producto { get; set; }

        [JsonProperty("codigoProducto")]
        public string CodigoProducto { get; set; }

        [JsonProperty("periodicidad")]
        public int Periodicidad { get; set; }

        [JsonProperty("primaPlaneada")]
        public double PrimaPlaneada { get; set; }

        [JsonProperty("tipoRenta")]
        public string TipoRenta { get; set; }

        [JsonProperty("nombreTipoRenta")]
        public string NombreTipoRenta { get; set; }

        [JsonProperty("monto")]
        public int Monto { get; set; }

        [JsonProperty("numeroCargas")]
        public int NumeroCargas { get; set; }

        [JsonProperty("mesesGarantizados")]
        public int MesesGarantizados { get; set; }

        [JsonProperty("mesesDiferidos")]
        public int MesesDiferidos { get; set; }

        [JsonProperty("cuotaMortuoria")]
        public int CuotaMortuoria { get; set; }

        [JsonProperty("primaUnica")]
        public double PrimaUnica { get; set; }

        [JsonProperty("renta")]
        public double Renta { get; set; }

        [JsonProperty("rentaTemporal")]
        public double RentaTemporal { get; set; }

        [JsonProperty("fecu")]
        public int Fecu { get; set; }

        [JsonProperty("fechaProximoPago")]
        public DateTime FechaProximoPago { get; set; }

        [JsonProperty("endoso")]
        public int Endoso { get; set; }

        [JsonProperty("periodoGarantizado")]
        public int PeriodoGarantizado { get; set; }

        [JsonProperty("periodoDiferido")]
        public int PeriodoDiferido { get; set; }
    }

    public class Ejecutiva
    {
        [JsonProperty("rut")]
        public string Rut { get; set; }

        [JsonProperty("nombres")]
        public string Nombres { get; set; }

        [JsonProperty("apellidoPaterno")]
        public string ApellidoPaterno { get; set; }

        [JsonProperty("apellidoMaterno")]
        public string ApellidoMaterno { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("telefono")]
        public string Telefono { get; set; }
    }

    public class PolizasCC
    {
        [JsonProperty("poliza")]
        public string Poliza { get; set; }

        [JsonProperty("estado")]
        public string Estado { get; set; }

        [JsonProperty("fechaEstado")]
        public DateTime FechaEstado { get; set; }

        [JsonProperty("fechaInicioVigencia")]
        public DateTime FechaInicioVigencia { get; set; }

        [JsonProperty("fechaTerminoVigencia")]
        public DateTime FechaTerminoVigencia { get; set; }

        [JsonProperty("producto")]
        public Producto Producto { get; set; }

        [JsonProperty("codigoProducto")]
        public string CodigoProducto { get; set; }

        [JsonProperty("numeroCredito")]
        public int NumeroCredito { get; set; }

        [JsonProperty("fechaExpiracion")]
        public DateTime FechaExpiracion { get; set; }

        [JsonProperty("montoBruto")]
        public double MontoBruto { get; set; }

        [JsonProperty("montoLiquido")]
        public double MontoLiquido { get; set; }

        [JsonProperty("montoCuota")]
        public double MontoCuota { get; set; }

        [JsonProperty("cuotasPagadas")]
        public int CuotasPagadas { get; set; }

        [JsonProperty("totalCuotas")]
        public int TotalCuotas { get; set; }

        [JsonProperty("saldoPendiente")]
        public double SaldoPendiente { get; set; }

        [JsonProperty("fechaSaldoPendiente")]
        public DateTime FechaSaldoPendiente { get; set; }

        [JsonProperty("tasaInteresMensual")]
        public double TasaInteresMensual { get; set; }

        [JsonProperty("ejecutiva")]
        public Ejecutiva Ejecutiva { get; set; }
    }


}
