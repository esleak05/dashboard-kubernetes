using System.Collections.Generic;
using Backend.Kubernetes.API.Domain.Entities;

namespace Backend.Kubernetes.API.Domain.Models
{
    public class PodResponseModel 
    {
        public IEnumerable<Pod> Pods{ get; set; }        
    }    
}