using Backend.Kubernetes.API.Infraestructure.Interfaces;
using Backend.Kubernetes.API.Test;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace Backend.Kubernetes.API.Infraestructure.RemoteServices.clientes.Tests
{
    public class ProductsTests : IClassFixture<TestConfiguration>
    {
        readonly IProducts _products;

        public ProductsTests(TestConfiguration testConfiguration)
        {
            _products = testConfiguration.ServiceProvider.GetService<IProducts>() ?? throw new NullReferenceException(nameof(testConfiguration));
        }

        [Fact()]
        public async void GetPolizaRVTest()
        {
            var response = await _products.GetPolizaRV("1303k");
            Assert.NotEmpty(response);
        }

        [Fact()]
        public async void GetPolizaRVRutFalseTest()
        {
            var response = await _products.GetPolizaRV("1303kk");
            Assert.Empty(response);
        }
    }
}