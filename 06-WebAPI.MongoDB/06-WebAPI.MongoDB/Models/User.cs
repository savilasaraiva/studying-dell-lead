using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _06_WebAPI.MongoDB.Models
{
    public class User
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("name")]
        public String Name { get; set; }
        [BsonElement("email")]
        public String Email { get; set; }
        [BsonElement("password")]
        public String Password { get; set; }
    }
}
