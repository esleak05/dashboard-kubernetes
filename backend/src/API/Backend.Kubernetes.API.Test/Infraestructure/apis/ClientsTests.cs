using Backend.Kubernetes.API.Domain.Models;
using Backend.Kubernetes.API.Infraestructure.Interfaces;
using Backend.Kubernetes.API.Test;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace Backend.Kubernetes.API.Infraestructure.RemoteServices.Tests
{
    public class ClientsTests : IClassFixture<TestConfiguration>
    {
        readonly IClients _clients;

        public ClientsTests(TestConfiguration testConfiguration)
        {
            _clients = testConfiguration.ServiceProvider.GetService<IClients>() ?? throw new NullReferenceException(nameof(testConfiguration));
        }

        [Fact()]
        public async void GetClientByRutTest()
        {
            GetPersonaNaturalResponse person = await _clients.GetClientByRut("12.925.512-9");
            Assert.NotNull(person);
        }
    }
}