using System;

namespace Backend.Kubernetes.API.Application.DTOs 
{
    public class Pod
    {
        public string UID { get; set; }
        public string Name { get; set; }
        public string Namespace { get; set; }
    }

}