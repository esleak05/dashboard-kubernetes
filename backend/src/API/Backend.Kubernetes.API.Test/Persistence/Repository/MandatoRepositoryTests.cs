using AutoBogus;
using Backend.Kubernetes.API.Application.Extensions;
using Backend.Kubernetes.API.Domain.Models;
using Backend.Kubernetes.API.Persistence.Interfaces;
using Backend.Kubernetes.API.Test;
using Bogus;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Backend.Kubernetes.API.Persistence.Repository.Tests
{
    public class MandatoRepositoryTests : IClassFixture<TestConfiguration>
    {

        private readonly IMandatoRepository _repository;
        private readonly ITestOutputHelper _console;

        public MandatoRepositoryTests(TestConfiguration testConfiguration, ITestOutputHelper testOutputHelper)
        {
            _repository = testConfiguration.ServiceProvider.GetService<IMandatoRepository>() ?? throw new NullReferenceException(nameof(testConfiguration));
            _console = testOutputHelper;
        }

        [Fact()]
        public async void HasSpouseTest()
        {
            Assert.True(await _repository.HasSpouse(603, 517981));
        }

        [Fact()]
        public async void HasMandateTest()
        {
            Assert.True(await _repository.HasValidMandate(3980483));
        }

        [Fact()]
        public void FakeTest()
        {
            var teset = new Faker<GetPersonaNaturalResponse>().Generate();
            var lorem = new Bogus.DataSets.Lorem(locale: "es");
            var person = new Bogus.Person();

            var faker = new AutoFaker<GetPersonaNaturalResponse>()
                .RuleFor(f => f.Nombres, o => o.Person.FirstName)
                .RuleFor(f => f.ApellidoPaterno, o => o.Person.LastName)
                .RuleFor(f => f.ApellidoPaterno, o => o.Person.LastName);

            var x = faker.Generate();
            _console.WriteLine(x.Dump());
            _console.WriteLine(lorem.Sentence(5));

        }

        [Fact()]
        public async void HasCausanteTest()
        {
            Assert.True(await _repository.HasCausante(5194673, 1000));
        }

        [Fact()]
        public async void SaveMandateTest()
        {
            Assert.True(await _repository.SaveMandate(6379661, "1", true, "user@confuturo.cl"));
        }
    }
}