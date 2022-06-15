using System.Threading.Tasks;
using System.Collections.Generic;
using Backend.Kubernetes.API.Domain.Models;


namespace Backend.Kubernetes.API.Infraestructure.Interfaces
{
    public interface IKubernetesService
    {
        Task<PodResponseModel> GetPodsByNamespace(string ns);        
    }

}