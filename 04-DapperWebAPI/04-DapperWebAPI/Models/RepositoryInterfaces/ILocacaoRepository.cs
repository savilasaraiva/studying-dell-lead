using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _04_DapperWebAPI.Models.RepositoryInterfaces
{
    public interface ILocacaoRepository
    {
        IEnumerable<Locacao> GetAll();
        Locacao GetOne(int IdCli, int IdFilm);
        Locacao Create(Locacao locacao);
        Locacao Update(Locacao locacao);
        Task Delete(int IdCli, int IdFilm);
    }
}
