using _04_DapperWebAPI.Controllers;
using _04_DapperWebAPI.Models;
using _04_DapperWebAPI.Models.RepositoryInterfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace _04_DapperWebAPI.Tests
{
    public class ControllerEnderecoTests
    {
        private MockRepository mockRepository;
        Mock<IEnderecoRepository> _mockEnderecoRespository;

        public ControllerEnderecoTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Default);
            this._mockEnderecoRespository = this.mockRepository.Create<IEnderecoRepository>();
        }

        private EnderecoController EnderecoController()
        {
            return new EnderecoController(this._mockEnderecoRespository.Object);
        }

        [Fact]
        public void GetProcess_ShouldReturnAlistOfEnderecosWhenStatusCode200()
        {
            // arrange
            var enderecoController = this.EnderecoController();

            List<Endereco> enderecos = new List<Endereco>();
            Endereco endereco = new Endereco()
            {
                IdEnd = 1,
                Logradouro = "Teste",
                Bairro = "Teste2",
                Numero = 2,
                Cep = "63900-000",
                ClienteId = 1
            };
            enderecos.Add(endereco);

            // act
            _mockEnderecoRespository.Setup(x => x.GetAll()).Returns(enderecos).Verifiable();

            ActionResult<IEnumerable<Endereco>> result = enderecoController.Get();
            OkObjectResult statusResult = (OkObjectResult)result.Result;

            // assert
            Assert.Equal(200, statusResult.StatusCode);
        }
    }
}
