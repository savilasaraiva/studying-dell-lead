using System.Collections.Generic;
using System.Threading.Tasks;

namespace _04_DapperWebAPI.Models.RepositoryInterfaces
{
    public interface IFilmeRepository
    {
        IEnumerable<Filme> GetAll();
        Filme GetOne(int Id);
        Filme Create(Filme filme);
        Filme Update(Filme filme);
        Task Delete(int Id);
    }
}
