using _06_WebAPI.MongoDB.Models;
using _06_WebAPI.MongoDB.Models.RespositoryInterfaces;
using Microsoft.AspNetCore.Mvc;
using BC = BCrypt.Net.BCrypt;
using System;
using System.Collections.Generic;
using MongoDB.Bson;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _06_WebAPI.MongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/<UserController>
        /// <summary>
        /// Lista os usuários da To-do list.
        /// </summary>
        /// <returns>Os itens da To-do list</returns>
        /// <response code="200">Retorna os Usuários da To-do list cadastrados</response>
        /// <response code="404">Se não existir Usuários casdastrados</response>
        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            try
            {
                var result = _userRepository.GetAll();
                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message, Result = ex.HResult });
            }

        }

        // GET: api/<UserController>
        /// <summary>
        /// Lista um usuário da To-do list.
        /// </summary>
        /// <returns>O item da To-do list</returns>
        /// <response code="200">Retorna o Usuário refernte ao Id da To-do list cadastrados</response>
        /// <response code="404">Se não existir Usuário referente ao Id casdastrado</response>
        [HttpGet("{id}")]
        public ActionResult<User> Get(String id)
        {
            try
            {
                var result = _userRepository.GetById(id);
                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message, Result = ex.HResult });
            }
        }

        // POST api/<UserController>
        /// <summary>
        /// Cria um endereco na To-do list.
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST /Todo
        ///     {
        ///         name:
        ///         email:
        ///         password:
        ///      }
        /// </remarks>
        /// <param name="value"></param>
        /// <returns>Um novo item criado</returns>
        /// <response code="201">Retorna o novo Endereco criado</response>
        /// <response code="400">Se o Endereco não for cadastrado</response>
        /// <response code="404">Se não conseguir cadastrar o Endereco</response>
        [HttpPost]
        public ActionResult<User> Post(User user)
        {
            string passwordHash = BC.HashPassword(user.Password);
            user.Password = passwordHash;

            try
            {
                var result = _userRepository.Insert(user);
                if (result == null)
                    return NotFound();

                return Created(nameof(Get), result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message, Result = ex.HResult });
            }
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public ActionResult<User> Put(String id, User user)
        {
            string passwordHash = BC.HashPassword(user.Password);
            user.Password = passwordHash;

            try
            {
                user.Id = ObjectId.Parse(id);
                _userRepository.Update(user);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message, Result = ex.HResult });
            }
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(String id)
        {
            try
            {
                var result = _userRepository.GetById(id);
                if (result == null)
                    return NotFound();
                _userRepository.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message, Result = ex.HResult });
            }

        }
    }
}
