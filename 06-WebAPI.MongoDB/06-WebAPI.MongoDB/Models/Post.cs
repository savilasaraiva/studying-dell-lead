using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _06_WebAPI.MongoDB.Models
{
    public class Post
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("text")]
        public String Text { get; set; }

        [BsonElement("likes")]
        public String Likes { get; set; }

        [BsonElement("user")]
        public ObjectId User { get; set; }
    }
}
