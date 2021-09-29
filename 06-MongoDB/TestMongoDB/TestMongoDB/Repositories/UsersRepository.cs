using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestMongoDB.Models;
using TestMongoDB.Models.RepositoryInterfaces;

namespace TestMongoDB.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IMongoCollection<User> _users;
        public UsersRepository()
        {
            var client = new MongoClient("mongodb+srv://dbuser:123@cluster0.orzhg.mongodb.net/youtalk?retryWrites=true&w=majority");
            var database = client.GetDatabase("youtalk");
            _users = database.GetCollection<User>("users");
        }

        public List<User> GetUsers()
        {
            return _users.Find(User => true).ToList();
        }
        public User GetUserById(String id)
        {
            return _users.Find($"{{ _id: ObjectId('{id}') }}").Single();
        }

    }
}
