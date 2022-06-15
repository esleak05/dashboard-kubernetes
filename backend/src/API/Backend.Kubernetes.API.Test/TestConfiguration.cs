using Backend.Kubernetes.API.Application.Handlers.Commands;
using Backend.Kubernetes.API.Application.Handlers.Queries;
using Backend.Kubernetes.API.Bootstrapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace Backend.Kubernetes.API.Test
{
    public class TestConfiguration
    {
        public ServiceProvider ServiceProvider { get; private set; }

        public TestConfiguration()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(
                     path: "appsettings.json",
                     optional: false,
                     reloadOnChange: true)
               .Build();

            serviceCollection.AddSingleton<IConfiguration>(configuration);

            serviceCollection.RegisterApplicationExtension();
            serviceCollection.RegisterRepositoryExtension();
            serviceCollection.RegisterInfraestructureExtension(configuration);


            // TODO Agregar Handlers correspondientes
            serviceCollection.AddMediatR(typeof(SignMandateHandler));
            serviceCollection.AddMediatR(typeof(GetMandatePdfHandler));
            serviceCollection.AddMediatR(typeof(HasMandateHandler));

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

    }
}
