using _04_DapperWebAPI.Models;
using _04_DapperWebAPI.Models.RepositoryInterfaces;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace _04_DapperWebAPI.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly string _connectionString;

        public ClienteRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("LocadoraDB");
        }

        public IEnumerable<Cliente> GetAll()
        {   
            var sqlQuery = @"SELECT c.Id as IdCli, 
                            c.Nome, 
                            c.Telefone,
                            e.Id as IdEnd,
                            e.Logradouro, 
                            e.Bairro,
                            e.Numero,
                            e.Cep
                    FROM dbo.Clientes c 
                    INNER JOIN dbo.Enderecos e
                        ON e.ClienteId = c.Id";

            using (var connection = new SqlConnection(_connectionString))
            {
                var clientes = connection.Query<Cliente, Endereco, Cliente>(sqlQuery, (c, e) => {
                    c.Enderecos = new List<Endereco>();
                    c.Enderecos.Add(e);
                    return c;
                }, splitOn: "IdCli, IdEnd");

                var result = clientes.GroupBy(c => c.IdCli).Select(e =>
                {
                    var groupedClientes = e.First();
                    groupedClientes.Enderecos = e.Select(c => c.Enderecos.Single()).ToList();
                    return groupedClientes;
                });
                return result;
            }
        }

        public Cliente GetOne(int Id)
        {
            /*var sqlQuery = @"SELECT * FROM Clientes WHERE Id = @Id";

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.QueryFirstOrDefault<Cliente>(sqlQuery, new { Id = Id });
            }*/

            var sqlQuery = $@"SELECT c.Id as IdCli, 
                            c.Nome, 
                            c.Telefone,
                            e.Id as IdEnd,
                            e.Logradouro, 
                            e.Bairro,
                            e.Numero,
                            e.Cep
                    FROM dbo.Clientes c 
                    INNER JOIN dbo.Enderecos e
                        ON e.ClienteId = c.Id 
                    WHERE c.Id = {Id}";

            using (var connection = new SqlConnection(_connectionString))
            {
                var cliente = connection.Query<Cliente, Endereco, Cliente>(sqlQuery, (c, e) => {
                    c.Enderecos = new List<Endereco>();
                    c.Enderecos.Add(e);
                    return c;
                }, splitOn: "IdCli, IdEnd");

                var result = cliente.GroupBy(c => c.IdCli).Select(e =>
                {
                    var groupedClientes = e.First();
                    groupedClientes.Enderecos = e.Select(c => c.Enderecos.Single()).ToList();
                    return groupedClientes;
                });
                return result.Single();
            }
        }

        public int GetMaxId()
        {
            var sqlQuery = "SELECT max(id) as id_max FROM Clientes";

            using (var connection = new SqlConnection(_connectionString))
            {
                var result = connection.QueryFirst(sqlQuery);
                var x = result.id_max;
                return x;
            }
        }

        public Cliente Create(Cliente cliente)
        {
            var sqlQuery = "INSERT INTO Clientes (Nome, Telefone) VALUES (@Nome, @Telefone)";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(sqlQuery, new
                {
                    cliente.Nome,
                    cliente.Telefone
                });

                return cliente;
            }
        }


        public Cliente Update(Cliente cliente)
        {
            var sqlQuery = "UPDATE Clientes SET Nome=@Nome, Telefone=@Ano) WHERE Id=@Id";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.ExecuteAsync(sqlQuery, new
                {
                    cliente.Nome,
                    cliente.Telefone
                });

                return cliente;
            }
        }

        public async Task Delete(int Id)
        {
            var sqlQuery = "DELETE from Clientes WHERE Id=@Id";

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(sqlQuery, new { Id = Id });              
            }
        }
    }
}
