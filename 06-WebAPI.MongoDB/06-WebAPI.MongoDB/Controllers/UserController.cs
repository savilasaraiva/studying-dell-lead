using _06_WebAPI.MongoDB.Models;
using _06_WebAPI.MongoDB.Models.RespositoryInterfaces;
using Microsoft.AspNetCore.Mvc;
using BC = BCrypt.Net.BCrypt;
using System;
using System.Collections.Generic;
using MongoDB.Bson;


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
        [ProducesResponseType(typeof(User), 200)]
        [ProducesResponseType(404)]
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
        /// <remarks>
        /// Exemplo:
        ///
        ///     id: 
        ///
        /// </remarks>
        /// <returns>O item da To-do list</returns>
        /// <response code="200">Retorna o Usuário refernte ao Id da To-do list cadastrados</response>
        /// <response code="404">Se não existir Usuário referente ao Id casdastrado</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(User), 200)]
        [ProducesResponseType(404)]
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
        /// Cria um usuario na To-do list.
        /// </summary>
        /// <remarks>
        /// Exemplo:
        /// 
        ///     POST /Todo
        ///     {
        ///         name: Maria
        ///         email: maria@gmail.com
        ///         password: 123
        ///     }
        /// </remarks>
        /// <param name="value"></param>
        /// <returns>Um novo item criado</returns>
        /// <response code="201">Retorna o novo Usuário criado</response>
        /// <response code="400">Se houver algum erro interno</response>
        /// <response code="404">Se o Usuário não for cadastrado</response>
        [HttpPost]
        [ProducesResponseType(typeof(User), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
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

        // PUT api/<UserController>/5
        /// <summary>
        /// Atualiza um endereco na To-do list.
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     id: 
        /// 
        ///     PUT /Todo
        ///     {
        ///         name: Maria
        ///         email: maria@gmail.com
        ///         password: 123
        ///     }
        ///
        /// </remarks>
        /// <param name="value"></param>
        /// <returns>Um item atualizado</returns>
        /// <response code="200">Se o Usuário for atualizado</response>
        /// <response code="400">Se o Usuário não for atualizado</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(User), 200)]
        [ProducesResponseType(400)]
        public ActionResult<User> Put(String id, User user)
        {
            string passwordHash = BC.HashPassword(user.Password);
            user.Password = passwordHash;

            try
            {
                var result = _userRepository.GetById(id);
                if (result == null)
                    return NotFound();
                user.Id = ObjectId.Parse(id);
                _userRepository.Update(user);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message, Result = ex.HResult });
            }
        }

        // DELETE api/<UsersController>/5
        /// <summary>
        /// Deleta um Usuário da To-do list.
        /// </summary>
        /// 
        /// <remarks>
        /// Exemplo:
        ///
        ///     id: 
        ///
        /// </remarks>
        /// <param name="value"></param>
        /// <returns>Um novo item criado</returns>
        /// <response code="204">Se o Usuário for deletado</response>
        /// <response code="400">Se o Usuário não for deletado</response>
        /// <response code="404">Se o Usuário não for encontrado</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(User), 204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
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
