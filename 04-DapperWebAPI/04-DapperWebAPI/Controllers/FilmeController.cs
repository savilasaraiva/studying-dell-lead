using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using _04_DapperWebAPI.Models;
using _04_DapperWebAPI.Models.RepositoryInterfaces;
using System;
using Microsoft.AspNetCore.Authorization;

namespace _04_DapperWebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeRepository _filmeRepository;

        public FilmeController(IFilmeRepository filmeRepository)
        {
            _filmeRepository = filmeRepository;
        }

        // GET: api/<FilmeController>
        /// <summary>
        /// Lista os filmes da To-do list.
        /// </summary>
        /// <returns>Os itens da To-do list</returns>
        /// <response code="200">Retorna os Filmes da To-do list cadastrados</response>
        /// <response code="400">Se não conseguir retornar Filmes casdastrados</response>
        /// <response code="404">Se não existir Filmes casdastrados</response>
        [HttpGet]
        public ActionResult<IEnumerable<Filme>> Get()
        {
            try
            {
                var result = _filmeRepository.GetAll();
                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message, Result = ex.HResult });
            }
        }

        // GET api/<FilmeController>/5
        /// <summary>
        /// Lista um filme do parametro Id.
        /// </summary>
        /// <returns>Um item da To-do list</returns>
        /// <response code="200">Retorna o Filme cadastrado com id referenciado</response>
        /// <response code="400">Se não conseguir retornar Filme com Id cadastrado</response>
        /// <response code="404">Se não existir Filme com Id cadastrado</response>
        [HttpGet("{id}")]
        public ActionResult<Filme> Get(int id)
        {
            try
            {
                var result = _filmeRepository.GetOne(id);
                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message, Result = ex.HResult });
            }
        }

        // POST api/<FilmeController>
        /// <summary>
        /// Cria um item na To-do list.
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST /Todo
        ///     {
        ///        "nome": "Nome do Filme",
        ///        "ano": "20xx",
        ///        "diretor": "Nome do Diretor",
        ///        "gereno": "Genero do Filme",
        ///      }
        /// </remarks>
        /// <returns>Um novo item criado</returns>
        /// <response code="201">Retorna o novo Filme criado</response>
        /// <response code="400">Se o Filme não for cadastrado</response>
        /// <response code="404">Se não conseguir cadastrar o Filme</response>
        [HttpPost]
        public ActionResult<Filme> Post(Filme filme)
        {
            try
            {
                var result = _filmeRepository.Create(filme);

                return Created(nameof(Get), result);
            }
            catch (Exception ex)
            {
                //return StatusCode(ex.HResult, ex.Message);
                return BadRequest(new { Message = ex.Message, Result = ex.HResult });
            }
        }

        // PUT api/<FilmeController>/5
        /// <summary>
        /// Atualiza um filme na To-do list.
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST /Todo
        ///     {
        ///        "nome": "Nome do Filme",
        ///        "ano": "20xx",
        ///        "diretor": "Nome do Diretor",
        ///        "gereno": "Genero do Filme",
        ///      }
        ///
        /// </remarks>
        /// <param name="id" example="id"></param>
        /// <param name="filme" example=""></param>
        /// <returns>Um item atualizado</returns>
        /// <response code="204">Se o Filme for atualizado</response>
        /// <response code="400">Se o Filme não for atualizado</response>
        [HttpPut("{id}")]
        public ActionResult<Filme> Put(int id, Filme filme)
        {
            try
            {
                if (id != filme.Id)
                    return BadRequest();

                var result = _filmeRepository.Update(filme);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message, Result = ex.HResult });
            }
        }

        // DELETE api/<FilmeController>/5
        /// <summary>
        /// Deleta um filme da To-do list.
        /// </summary>
        /// <param name="id" example="1"></param>
        /// <returns>Um novo item criado</returns>
        /// <response code="204">Se o Filme for deletado</response>
        /// <response code="400">Se o Filme não for deletado</response>
        /// <response code="404">Se o Filme não for encontrado</response>
        [HttpDelete("{id}")]
        public ActionResult<Filme> Delete(int id)
        {
            try
            {
                var result = _filmeRepository.GetOne(id);
                if (result == null)
                    return NotFound();

                _filmeRepository.Delete(result.Id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message, Result = ex.HResult });
            }
        }
    }
}
