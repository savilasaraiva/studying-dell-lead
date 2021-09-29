using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestMongoDB.Models.RepositoryInterfaces
{
    public interface IUsersRepository
    {
        List<User> GetUsers();
        User GetUserById(String id);
    }
}
