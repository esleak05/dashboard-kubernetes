using System.Threading.Tasks;

namespace Backend.Kubernetes.API.Persistence.Interfaces
{
    public interface IMandatoRepository
    {
        Task<bool> HasSpouse(int productCode, int insurancePolicy);
        Task<bool> HasValidMandate(int rutWithOutDv);
        Task<bool> HasCausante(int rutWithOutDv, int insurancePolicy);
        Task<bool> SaveMandate(int rut, string dv, bool isMandateSigned, string executive);

    }
}
