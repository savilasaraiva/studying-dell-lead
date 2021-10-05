using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _06_WebAPI.MongoDB.Models.RespositoryInterfaces
{
    public interface IPostRepository
    {
        List<Post> GetAll();
        Post GetById(String id);
        List<Post> GetByIdUser(string idUser);
        Post Insert(Post post);
        Post Update(Post post);
        void Delete(String id);
    }
}
