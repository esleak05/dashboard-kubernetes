using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Kubernetes.API.Domain.Models;
using Backend.Kubernetes.API.Domain.Entities;
using Backend.Kubernetes.API.Infraestructure.Interfaces;
using k8s;
using k8s.Models;

namespace Backend.Kubernetes.API.Infraestructure.RemoteServices
{
    public class KubernetesService : IKubernetesService
    {
        private  KubernetesClientConfiguration _configuration;
        private  k8s.Kubernetes _client;
        public KubernetesService()
        {
        

        }
        public async Task<PodResponseModel> GetPodsByNamespace(string ns)
        {
            _configuration = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").Equals("QA") ? KubernetesClientConfiguration.InClusterConfig()  
                                                                                                       : KubernetesClientConfiguration.BuildDefaultConfig();
            
            _client = new k8s.Kubernetes(_configuration);

            var list = await _client.ListNamespacedPodAsync(ns);

            return new PodResponseModel
            {
                Pods = list.Items.Select(pod => new Pod
                {
                    Uid = pod.Metadata.Uid,
                    Name = pod.Metadata.Name,
                    Node = pod.Spec.NodeName,
                    CreateDate = (DateTime)pod.Metadata.CreationTimestamp

                }).ToList()
            };

        }
    }
} 