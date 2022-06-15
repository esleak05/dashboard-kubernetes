using System;

namespace Backend.Kubernetes.API.Domain.Entities
{
    public class Pod 
    {
        public string Uid{ get; set; }        
        public string Name { get; set; }
        public string Node { get; set; }
        public DateTime CreateDate{ get; set; }
           
    }

}