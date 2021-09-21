using System;
using Xunit;
using Moq;
using _04_DapperWebAPI.Models.RepositoryInterfaces;
using _04_DapperWebAPI.Controllers;
using System.Collections.Generic;
using _04_DapperWebAPI.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace _04_DapperWebAPI.Tests
{
    public class ControllerClienteTests
    {
        private MockRepository mockRepository;        
        Mock<IClienteRepository> _mockClientRepository;
        Mock<IEnderecoRepository> _mockEnderecoRespository;

        public ControllerClienteTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Default);
            this._mockClientRepository = this.mockRepository.Create<IClienteRepository>();
            this._mockEnderecoRespository = this.mockRepository.Create<IEnderecoRepository>();
        }

        private ClienteController ClienteController()
        {
            return new ClienteController(this._mockClientRepository.Object, this._mockEnderecoRespository.Object);
        }

        [Fact]
        public void GetProcess_ShouldReturnAlistOfClientsWhenStatusCode200()
        {
            // arrange
            var clienteController = this.ClienteController();
            
            List<Cliente> clientes = new List<Cliente>();
            Cliente cliente = new Cliente()
            {
                IdCli = 1,
                Nome = "Teste",
                Telefone = "Teste2"
            };
            clientes.Add(cliente);

            // act
            _mockClientRepository.Setup(x => x.GetAll()).Returns(clientes).Verifiable();

            ActionResult<IEnumerable<Cliente>> result = clienteController.Get();
            OkObjectResult statusResult = (OkObjectResult)result.Result;

            // assert
            Assert.Equal(200, statusResult.StatusCode);
        }

        [Fact]
        public void GetProcess_ShouldReturnAClientWhenStatusCode200()
        {
            // arrange
            var clienteController = this.ClienteController();

            Cliente cliente = new Cliente()
            {
                IdCli = 1,
                Nome = "Teste",
                Telefone = "Teste2"
            };

            // act
            _mockClientRepository.Setup(x => x.GetOne(cliente.Id)).Returns(cliente).Verifiable();

            ActionResult<Cliente> result = clienteController.Get(cliente.Id);
            OkObjectResult statusResult = (OkObjectResult)result.Result;

            // assert
            Assert.Equal(200, statusResult.StatusCode);
        }

        [Fact]
        public void GetProcess_ShouldCreatedAClientWhenStatusCode200()
        {
            // arrange
            var clienteController = this.ClienteController();

            Cliente cliente = new Cliente()
            {
                Nome = "Teste",
                Telefone = "Teste2"
            };

            // act
            _mockClientRepository.Setup(x => x.Create(cliente)).Returns(cliente).Verifiable();

            ActionResult<Cliente> result = clienteController.Created(nameof(clienteController.Get), cliente);
            CreatedResult statusResult = (CreatedResult)result.Result;

            // assert
            Assert.Equal(201, statusResult.StatusCode);
        }
    }
}
