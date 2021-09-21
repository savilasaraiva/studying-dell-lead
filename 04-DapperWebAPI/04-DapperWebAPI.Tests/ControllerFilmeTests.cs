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
    public class ControllerFilmeTests
    {
        private MockRepository mockRepository;
        Mock<IFilmeRepository> _mockEnderecoRespository;

        public ControllerFilmeTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Default);
            this._mockEnderecoRespository = this.mockRepository.Create<IFilmeRepository>();
        }

        private FilmeController EnderecoController()
        {
            return new FilmeController(this._mockEnderecoRespository.Object);
        }

        [Fact]
        public void GetProcess_ShouldReturnAlistOfFimesWhenStatusCode200()
        {
            // arrange
            var enderecoController = this.EnderecoController();

            List<Filme> filmes = new List<Filme>();
            Filme filme = new Filme()
            {
                Id = 1,
                Nome = "Teste 1",
                Ano = 2020,
                Diretor = "teste",
                Genero = "Genero"
            };
            filmes.Add(filme);

            // act
            _mockEnderecoRespository.Setup(x => x.GetAll()).Returns(filmes).Verifiable();

            ActionResult<IEnumerable<Filme>> result = enderecoController.Get();
            OkObjectResult statusResult = (OkObjectResult)result.Result;

            // assert
            Assert.Equal(200, statusResult.StatusCode);
        }
    }
}
