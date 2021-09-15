using _04_DapperWebAPI.Models;
using _04_DapperWebAPI.Models.RepositoryInterfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace _04_DapperWebAPI.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private readonly string _connectionString;

        public FilmeRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("LocadoraDB");
        }

        public IEnumerable<Filme> GetAll()
        {
            var sqlQuery = "SELECT * FROM Filmes";

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Filme>(sqlQuery);
            }
        }

        public Filme GetOne(int Id)
        {
            var sqlQuery = "SELECT * FROM Filmes WHERE Id=@Id";

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.QueryFirstOrDefault<Filme>(sqlQuery, new { Id = Id });
            }
        }

        public Filme Create(Filme filme)
        {
            var sqlQuery = "INSERT INTO Filmes (Nome, Ano, Diretor, Genero) VALUES (@Nome, @Ano, @Diretor, @Genero)";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(sqlQuery, new
                {
                    filme.Nome,
                    filme.Ano,
                    filme.Diretor,
                    filme.Genero
                });

                return filme;
            }
        }
               

        public Filme Update(Filme filme)
        {
            var sqlQuery = "UPDATE Filmes SET Nome=@Nome, Ano=@Ano, Diretor=@Diretor, Genero=@Genero WHERE Id=@Id";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(sqlQuery, new
                {
                    filme.Nome,
                    filme.Ano,
                    filme.Diretor,
                    filme.Genero,
                    filme.Id
                });

                return filme;
            }
        }

        public async Task Delete(int Id)
        {
            var sqlQuery = "DELETE FROM Filmes WHERE Id=@Id";

            using (var connection = new SqlConnection(_connectionString))
            {
               await connection.ExecuteAsync(sqlQuery, new { Id = Id });
            }
        }
    }
}
