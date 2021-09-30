using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _06_WebAPI.MongoDB.Models.RespositoryInterfaces
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User GetById(String id);
        User Insert(User user);
        void Update(User user);
        void Delete(String id);
    }
}
