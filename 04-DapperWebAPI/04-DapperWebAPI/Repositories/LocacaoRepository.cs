using _04_DapperWebAPI.Models;
using _04_DapperWebAPI.Models.RepositoryInterfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace _04_DapperWebAPI.Repositories
{
    public class LocacaoRepository : ILocacaoRepository
    {
        private readonly string _connectionString;

        public LocacaoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("LocadoraDB");
        }

        public IEnumerable<Locacao> GetAll()
        {
            var sqlQuery = @"SELECT l.DtLocacao,
                            l.DtDevolucao,
                            c.Id as IdCli,
                            c.Nome,
                            c.Telefone, 
                            f.Id as IdFilm,
                            f.Nome,
                            f.Ano,
                            f.Diretor,
                            f.Genero
                    FROM dbo.Locacoes l 
                    INNER JOIN dbo.Clientes c
                        ON l.ClienteId = c.Id
                    INNER JOIN dbo.Filmes f
                        ON l.FilmeId = f.Id";

            using (var connection = new SqlConnection(_connectionString))
            {
                var locacoes = connection.Query<Locacao, Cliente, Filme, Locacao>(sqlQuery, (l, c, f) =>
                {
                    l.Cliente = c;
                    l.Filme = f;
                    return l;
                }, splitOn: "IdCli, IdFilm");
                return locacoes;
            }            
        }

        public Locacao GetOne(int IdCli, int IdFilm)
        {
            Locacao loc = new Locacao();
            var sqlQuery = @"SELECT l.DtLocacao,
                            l.DtDevolucao,
                            c.Id as IdCli,
                            c.Nome,
                            c.Telefone, 
                            f.Id as IdFilm,
                            f.Nome,
                            f.Ano,
                            f.Diretor,
                            f.Genero
                    FROM dbo.Locacoes l 
                    INNER JOIN dbo.Clientes c
                        ON l.ClienteId = c.Id
                    INNER JOIN dbo.Filmes f
                        ON l.FilmeId = f.Id
                    WHERE ClienteId=" + IdCli + "AND FilmeId=" + IdFilm;

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Query<Locacao, Cliente, Filme, Locacao>(sqlQuery, (l, c, f) =>
                {
                    loc.Cliente = c;
                    loc.Filme = f;
                    return l;
                }, splitOn: "IdCli, IdFilm");
                return loc;
            }
        }

        public Locacao Create(Locacao locacao)
        {
            var sqlQuery = "INSERT INTO Locacao (ClienteId, FilmeId, DtLocacao) VALUES (@IdCli, @IdFilm, @DtLocacao)";
            

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(sqlQuery, new
                {                    
                    locacao.Cliente.IdCli,
                    locacao.Filme.IdFilm,
                    locacao.DtLocacao
                });
                return locacao;
            }
        }


        public Locacao Update(Locacao locacao)
        {
            var sqlQuery = "UPDATE Filmes SET DtLocacao=@DtLocacao, DtDevolucao=@DtDevolucao WHERE ClienteId=@IdCli AND FilmeId=@IdFilm";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(sqlQuery, new
                {
                    locacao.DtLocacao,
                    locacao.DtDevolucao
                });

                return locacao;
            }
        }

        public async Task Delete(int IdCli, int IdFilm)
        {
            var sqlQuery = "DELETE FROM Locacao WHERE ClienteId=@IdCli AND FilmeId=@IdFilm";

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(sqlQuery, new {
                    ClinteId = IdCli,
                    FilmeId = IdFilm
                });
            }
        }
    }
}
