using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _04_DapperWebAPI.Models.RepositoryInterfaces
{
    public interface IEnderecoRepository
    {
        IEnumerable<Endereco> GetAll();
        Endereco GetOne(int Id);
        Endereco Create(Endereco endereco);
        Endereco Update(Endereco endereco);
        Task Delete(int Id);
    }
}
