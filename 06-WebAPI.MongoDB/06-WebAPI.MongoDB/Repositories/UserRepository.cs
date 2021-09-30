using _06_WebAPI.MongoDB.Models;
using _06_WebAPI.MongoDB.Models.RespositoryInterfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace _06_WebAPI.MongoDB.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _user;
        public UserRepository()
        {
            var client = new MongoClient("mongodb+srv://dbuser:123@cluster0.orzhg.mongodb.net/youtalk?retryWrites=true&w=majority");
            var database = client.GetDatabase("youtalk");
            _user = database.GetCollection<User>("users");
        }
        public List<User> GetAll()
        {
            return _user.Find(User => true).ToList();
        }
        public User GetById(String id)
        {
            return _user.Find($"{{ _id: ObjectId('{id}') }}").Single();
        }

        public User Insert(User user)
        {
            _user.InsertOne(user);
            return user;
        }

        public void Update(User user)
        {
            var filter = Builders<User>.Filter.Eq(s => s.Id, user.Id);
            var result = _user.ReplaceOneAsync(filter, user);
        }
        public void Delete(String id)
        {
            var filter = Builders<User>.Filter.Eq(s => s.Id, ObjectId.Parse(id));
            var result = _user.DeleteOne(filter);
        }
    }
}
