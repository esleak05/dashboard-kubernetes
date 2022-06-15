
using Backend.Kubernetes.API.Persistence.Interfaces;
using Backend.Kubernetes.API.Persistence.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Kubernetes.API.Bootstrapper
{
    public static class PersistenceExtension
    {
        public static IServiceCollection RegisterRepositoryExtension(this IServiceCollection services)
        {
            services.AddTransient<IMandatoRepository, MandatoRepository>();
            return services;
        }
    }
}
