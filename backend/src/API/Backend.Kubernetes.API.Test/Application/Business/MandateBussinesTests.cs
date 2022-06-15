using Backend.Kubernetes.API.Application.Interfaces;
using Backend.Kubernetes.API.Domain.Exceptions;
using Backend.Kubernetes.API.Test;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Linq;
using Xunit;

namespace Backend.Kubernetes.API.Application.Business.Tests
{
    public class MandateBussinesTests : IClassFixture<TestConfiguration>
    {
        private readonly IMandateBussines _mandateBussines;

        public MandateBussinesTests(TestConfiguration testConfiguration)
        {
            _mandateBussines = testConfiguration.ServiceProvider.GetService<IMandateBussines>() ?? throw new NullReferenceException(nameof(testConfiguration));
        }

        [Fact()]
        public async void HasMandateTest()
        {
            var (fulfillHasMandate, hasMandate) = await _mandateBussines.HasMandate("3.980.483-2");
            Assert.True(fulfillHasMandate && hasMandate);
        }

        [Fact()]
        public async void HasMandateWhitOutLineTest()
        {
            var (fulfillHasMandate, hasMandate) = await _mandateBussines.HasMandate("3.980.483-2");
            Assert.True(fulfillHasMandate && hasMandate);
        }

        [Fact()]
        public async void HasMandateNotFound1Test()
        {
            await Assert.ThrowsAsync<NotFoundException>(() => _mandateBussines.HasMandate("138800229"));
        }

        [Fact()]
        public async void HasMandateNotFound2Test()
        {
            await Assert.ThrowsAsync<NotFoundException>(() => _mandateBussines.HasMandate("129052708"));
        }


        [Fact()]
        public async void HasMandateWithOutRvParserTest()
        {
            var (fulfillHasMandate, hasMandate) = await _mandateBussines.HasMandate("80057059");
            Assert.True(!hasMandate && !fulfillHasMandate);
        }

        [Fact()]
        public async void GetMandatePdfTest()
        {
            byte[] bytes = await _mandateBussines.GetMandatePdf("39804832");
            File.WriteAllBytes("Application/Data/Prueba.pdf", bytes.ToArray());
            Assert.NotNull(bytes);
        }
    }
}