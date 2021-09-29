using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestMongoDB.Models;
using TestMongoDB.Models.RepositoryInterfaces;

namespace TestMongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;

        public UserController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            return _usersRepository.GetUsers();
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(String id)
        {
            return _usersRepository.GetUserById(id);
        }

        
    }
}
