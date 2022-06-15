using Backend.Kubernetes.API.Infraestructure.RemoteServices;
using Backend.Kubernetes.API.Infraestructure.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Backend.Kubernetes.API.Bootstrapper
{
    public static class InfraestructureExtenions
    {
        public static IServiceCollection RegisterInfraestructureExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient("Products", client =>
            {
                client.BaseAddress = new System.Uri(configuration["Apis:UrlProductos"]);
            });
            services.AddHttpClient("Clients", client =>
            {
                client.BaseAddress = new System.Uri(configuration["Apis:UrlClientes"]);
            });

         
            services.AddTransient<IKubernetesService, KubernetesService>();

            return services;
        }
    }
}
