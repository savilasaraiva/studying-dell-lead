using _04_DapperWebAPI.Models;
using _04_DapperWebAPI.Models.RepositoryInterfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace _04_DapperWebAPI.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly string _connectionString;

        public EnderecoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("LocadoraDB");
        }

        public IEnumerable<Endereco> GetAll()
        {
            var sqlQuery = "SELECT * FROM Enderecos";

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Endereco>(sqlQuery);
            }

        }

        public Endereco GetOne(int Id)
        {
            var sqlQuery = "SELECT * FROM Enderecos WHERE Id=@Id";

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.QueryFirstOrDefault<Endereco>(sqlQuery, new { Id = Id });
            }
        }

        public Endereco Create(Endereco endereco)
        {
            var sqlQuery = "INSERT INTO Enderecos (Logradouro, Bairro, Numero, Cep, ClienteId) VALUES (@Logradouro, @Bairro, @Numero, @Cep, @ClienteId)";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.ExecuteAsync(sqlQuery, new
                {
                    endereco.Logradouro,
                    endereco.Bairro,
                    endereco.Numero,
                    endereco.Cep,
                    endereco.ClienteId
                });

                return endereco;
            }
        }


        public Endereco Update(Endereco endereco)
        {
            var sqlQuery = "UPDATE Enderecos SET Logradouro=@Logradouro, Bairro=@Bairro, Numero=@Numero, Cep=@Cep, ClienteId=@ClienteId) WHERE Id=@Id";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.ExecuteAsync(sqlQuery, new
                {
                    endereco.Logradouro,
                    endereco.Bairro,
                    endereco.Numero,
                    endereco.Cep,
                    endereco.ClienteId
                });

                return endereco;
            }
        }

        public async Task Delete(int Id)
        {
            var sqlQuery = "DELETE from Enderecos WHERE Id=@Id";

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(sqlQuery, new { Id = Id });
            }
        }
    }
}
