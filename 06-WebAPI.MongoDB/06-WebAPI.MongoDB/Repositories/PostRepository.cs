using _06_WebAPI.MongoDB.Models;
using _06_WebAPI.MongoDB.Models.RespositoryInterfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _06_WebAPI.MongoDB.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly IMongoCollection<Post> _post;

        public PostRepository()
        {
            var client = new MongoClient("mongodb+srv://dbuser:123@cluster0.orzhg.mongodb.net/youtalk?retryWrites=true&w=majority");
            var database = client.GetDatabase("youtalk");
            _post = database.GetCollection<Post>("posts");
        }

        public List<Post> GetAll()
        {
            return _post.Find(Post => true).ToList();
        }

        public Post GetById(string id)
        {
            return _post.Find($"{{ _id: ObjectId('{id}') }}").Single();
        }

        public List<Post> GetByIdUser(string idUser)
        {
            var filter = Builders<Post>.Filter.Eq(s => s.User, ObjectId.Parse(idUser));
            return _post.Find(filter).ToList();
        }

        public Post Insert(Post post)
        {
            _post.InsertOne(post);
            return post;
        }

        public Post Update(Post post)
        {
            var filter = Builders<Post>.Filter.Eq(s => s.Id, post.Id);
            var result = _post.ReplaceOne(filter, post);
            return post;
        }

        public void Delete(string id)
        {
            var filter = Builders<Post>.Filter.Eq(s => s.Id, ObjectId.Parse(id));
            var result = _post.DeleteOne(filter);
        }
        
    }
}
