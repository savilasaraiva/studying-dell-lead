using _04_DapperWebAPI.Models;
using _04_DapperWebAPI.Models.RepositoryInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _04_DapperWebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IEnderecoRepository _enderecoRepository;

        public ClienteController(IClienteRepository clienteRepository, IEnderecoRepository enderecoRepository)
        {
            _clienteRepository = clienteRepository;
            _enderecoRepository = enderecoRepository;
        }

        // GET: api/<ClienteController>
        /// <summary>
        /// Lista os clientes da To-do list.
        /// </summary>
        /// <returns>Os itens da To-do list</returns>
        /// <response code="200">Retorna os Clientes da To-do list cadastrados</response>
        /// <response code="400">Se não conseguir retornar Clientes casdastrados</response>
        /// <response code="404">Se não existir Clientes casdastrados</response>
        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult<IEnumerable<Cliente>> Get()
        {
            try
            {
                var result = _clienteRepository.GetAll();
                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message, Result = ex.HResult });
            }
        }

        // GET api/<ClienteController>/5
        /// <summary>
        /// Lista o cliente do parametro Id.
        /// </summary>
        /// <param name="id" example="1"></param>
        /// <returns>Um item da To-do list</returns>
        /// <response code="200">Retorna o Cliente cadastrado com id referenciado</response>
        /// <response code="400">Se não conseguir retornar Cliente com Id cadastrado</response>
        /// <response code="404">Se não existir Cliente com Id cadastrado</response>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        public ActionResult<Cliente> Get(int id)
        {
            try
            {
                var result = _clienteRepository.GetOne(id);
                if (result == null)
                    return NotFound();
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message, Result = ex.HResult });
            }
        }

        // GET: api/<ClienteController>/max
        [HttpGet("/max")]
        private int GetMaxId()
        {
            var result = _clienteRepository.GetMaxId();            
            return result;
        }

        // POST api/<ClienteController>
        /// <summary>
        /// Cria um item na To-do list.
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST /Todo
        ///     {
        ///        "nome": "Nome",
        ///        "telefone": "(88) 99999-9999",
        ///        "enderecos": [
        ///          {
        ///             "logradouro": "Rua B",
        ///             "bairro": "Cohab",
        ///             "numero": 89,
        ///             "cep": "63905-665"
        ///          }
        ///        ]
        ///      }
        /// </remarks>
        /// <returns>Um novo item criado</returns>
        /// <response code="201">Retorna o novo Cliente criado</response>
        /// <response code="400">Se não conseguir cadastrar o Cliente</response>
        [HttpPost]
        [ProducesResponseType(typeof(Cliente), 200)]
        public ActionResult<Cliente> Post(Cliente cliente)
        {
            try
            {
                var result = _clienteRepository.Create(cliente);
               
                int idCliente = GetMaxId();

                if (cliente.Enderecos.Count() > 0)
                {
                    foreach (var item in cliente.Enderecos)
                    {
                        item.ClienteId = idCliente;
                        _enderecoRepository.Create(item);
                    }
                }
                return Created(nameof(Get), result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message, Result = ex.HResult });
            }
        }

        // PUT api/<ClienteController>/5
        /// <summary>
        /// Atualiza um cliente na To-do list.
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     PUT /Todo
        ///     {
        ///        "nome": "Nome",
        ///        "telefone": "(88) 99999-9999"
        ///     }
        ///
        /// </remarks>
        /// <param name="id" example="1"></param>
        /// <param name="cliente" example=""></param>
        /// <returns>Um item atualizado</returns>
        /// <response code="200">Se o Cliente for atualizado</response>
        /// <response code="400">Se o Cliente não for atualizado</response>
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        public ActionResult<Cliente> Put(int id, Cliente cliente)
        {
            try
            {
                if (id != cliente.Id) return BadRequest();
                _clienteRepository.Update(cliente);

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message, Result = ex.HResult });
            }

        }

        // DELETE api/<ClienteController>/5
        /// <summary>
        /// Deleta um cliente da To-do list.
        /// </summary>
        /// <param name="id" example="1"></param>
        /// <returns>Um novo item criado</returns>
        /// <response code="200">Se o Cliente for deletado</response>
        /// <response code="400">Se o Cliente não for deletado</response>
        /// <response code="404">Se o Cliente não for encontrado</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        public ActionResult Delete(int id)
        {
            try
            {
                var result = _clienteRepository.GetOne(id);
                if (result == null)
                    return NotFound();

                _clienteRepository.Delete(result.Id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message, Result = ex.HResult });
            }
        }
           
    }
}
