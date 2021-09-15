using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _04_DapperWebAPI.Models.RepositoryInterfaces
{
    public interface IClienteRepository
    {
        IEnumerable<Cliente> GetAll();
        Cliente GetOne(int Id);
        int GetMaxId();
        Cliente Create(Cliente cliente);
        Cliente Update(Cliente cliente);
        Task Delete(int Id);
    }
}
