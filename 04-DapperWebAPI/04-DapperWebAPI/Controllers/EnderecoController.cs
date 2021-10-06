using _04_DapperWebAPI.Models;
using _04_DapperWebAPI.Models.RepositoryInterfaces;
using _04_DapperWebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _04_DapperWebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly ViaCepService _cepService;

        public EnderecoController(IEnderecoRepository enderecoRepository, ViaCepService cepService)
        {
            _enderecoRepository = enderecoRepository;
            _cepService = cepService;
        }

        // GET: api/<EnderecoController>
        /// <summary>
        /// Lista os enderecos da To-do list.
        /// </summary>
        /// <returns>Os itens da To-do list</returns>
        /// <response code="200">Retorna os Enderecos da To-do list cadastrados</response>
        /// <response code="400">Se não conseguir retornar Enderecos casdastrados</response>
        /// <response code="404">Se não existir Enderecos casdastrados</response>
        [HttpGet]
        public ActionResult<IEnumerable<Endereco>> Get()
        {
            try
            {
                var result = _enderecoRepository.GetAll();
                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(new { Message = ex.Message, Result = ex.HResult });
            }
            
        }

        // GET api/<EnderecoController>/5
        /// <summary>
        /// Lista um endereco do parametro Id.
        /// </summary>
        /// <returns>Um item da To-do list</returns>
        /// <response code="200">Retorna o Endereco cadastrado com id referenciado</response>
        /// <response code="400">Se não conseguir retornar Endereco com Id cadastrado</response>
        /// <response code="404">Se não existir Endereco com Id cadastrado</response>
        [HttpGet("{id}")]
        public  ActionResult<Endereco> Get(int id)
        {
            try
            {
                var result = _enderecoRepository.GetOne(id);
                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message, Result = ex.HResult });
            }
        }

        // GET api/<EnderecoController>/5
        /// <summary>
        /// Lista enderecos do parametro Cep.
        /// </summary>
        /// <returns>Um item da To-do list</returns>
        /// <response code="200">Retorna os Enderecos com Cep referenciado</response>
        /// <response code="400">Se não conseguir retornar os Enderecos com Cep</response>
        /// <response code="404">Se não existir Enderecos com Cep</response>
        [HttpGet("Search/{cep}")]
        public async Task<ActionResult<IEnumerable<Endereco>>> GetAdressAsCep(string cep)
        {
            try
            {
                var result = await _cepService.GetAdress(cep);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message, Result = ex.HResult });
            }
        }

        // POST api/<EnderecoController>
        /// <summary>
        /// Cria um endereco na To-do list.
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST /Todo
        ///     {
        ///         "logradouro": "Rua B",
        ///         "bairro": "Cohab",
        ///         "numero": 89,
        ///         "cep": "63905-665",
        ///         "ClinteId": 1
        ///      }
        /// </remarks>
        /// <returns>Um novo item criado</returns>
        /// <response code="201">Retorna o novo Endereco criado</response>
        /// <response code="400">Se o Endereco não for cadastrado</response>
        /// <response code="404">Se não conseguir cadastrar o Endereco</response>
        [HttpPost]
        public ActionResult<Endereco> Post(Endereco endereco)
        {
            try
            {
                var result = _enderecoRepository.Create(endereco);
                if (result == null)
                    return NotFound();

                return Created(nameof(Get), result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message, Result = ex.HResult });
            }
        }

        // PUT api/<EnderecoController>/5
        /// <summary>
        /// Atualiza um endereco na To-do list.
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     PUT /Todo
        ///     {
        ///         "logradouro": "Rua B",
        ///         "bairro": "Cohab",
        ///         "numero": 89,
        ///         "cep": "63905-665",
        ///         "ClinteId": 1
        ///      }
        ///
        /// </remarks>
        /// <param name="id" example="1"></param>
        /// <param name="endereco" example=""></param>
        /// <returns>Um item atualizado</returns>
        /// <response code="204">Se o Endereco for atualizado</response>
        /// <response code="400">Se o Endereco não for atualizado</response>
        [HttpPut("{id}")]
        public ActionResult Put(int id, Endereco endereco)
        {
            try
            {
                if (id != endereco.Id)
                    return BadRequest();

                _enderecoRepository.Update(endereco);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message, Result = ex.HResult });
            }
            
        }

        // DELETE api/<Enderecoontroller>/5
        /// <summary>
        /// Deleta um endereco da To-do list.
        /// </summary>
        /// <param name="id" example="1"></param>
        /// <returns>Um novo item criado</returns>
        /// <response code="204">Se o Endereco for deletado</response>
        /// <response code="400">Se o Endereco não for deletado</response>
        /// <response code="404">Se o Endereco não for encontrado</response>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var result = _enderecoRepository.GetOne(id);
                if (result == null)
                    return NotFound();

                _enderecoRepository.Delete(result.Id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message, Result = ex.HResult });
            }
        }
    }
}
