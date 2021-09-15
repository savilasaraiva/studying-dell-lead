using _04_DapperWebAPI.Models;
using _04_DapperWebAPI.Models.RepositoryInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _04_DapperWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocacaoController : ControllerBase
    {
        private readonly ILocacaoRepository _locacaoRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IFilmeRepository _filmeRepository;

        public LocacaoController(ILocacaoRepository locacaoRepository, IClienteRepository clienteRepository, IFilmeRepository filmeRepository)
        {
            _locacaoRepository = locacaoRepository;
            _clienteRepository = clienteRepository;
            _filmeRepository = filmeRepository;
        }

        // GET: api/<LocadoraController>
        /// <summary>
        /// Lista as locacoes da To-do list.
        /// </summary>
        /// <returns>Os itens da To-do list</returns>
        /// <response code="200">Retorna as Locacoes da To-do list cadastrados</response>
        /// <response code="400">Se não existir Locacoes casdastrados</response>
        [HttpGet]
        public ActionResult<IEnumerable<Locacao>> Get()
        {
            try
            {
                var result = _locacaoRepository.GetAll();
                
                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message, Result = ex.HResult });
            }
        }

        // GET api/<LocadoraController>/5
        /// <summary>
        /// Lista locacao dos parametros IdCli e IdFilm.
        /// </summary>
        /// <returns>Um item da To-do list</returns>
        /// <response code="200">Retorna o Locacao cadastrada com Ids referenciado</response>
        /// <response code="400">Se não existir o Locacao casdastrado referente aos Ids</response>
        [HttpGet("{IdCli, IdFilm}")]
        public ActionResult<Cliente> Get(int IdCli, int IdFilm)
        {
            try
            {
                var result = _locacaoRepository.GetOne(IdCli, IdFilm);
                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message, Result = ex.HResult });
            }
        }

        // POST api/<LocadoraController>
        /// <summary>
        /// Cria um item na To-do list.
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST /Todo
        ///     {
        ///        "Cliente": {
        ///             "IdCli": 1
        ///        }
        ///        "Filme": {
        ///             "IdFilm": 1
        ///        }
        ///        "DtLocacao": "2021-09-10T15:40:01"
        ///      }
        /// </remarks>
        /// <param name="value"></param>
        /// <returns>Um novo item criado</returns>
        /// <response code="201">Retorna a nova Locacao criada</response>
        /// <response code="400">Se a Locacao não for criada</response>
        [HttpPost]
        public ActionResult<Filme> Post(Locacao locacao)
        {
            try
            {
                var cliente = _clienteRepository.GetOne(locacao.Cliente.IdCli);
                var filme = _filmeRepository.GetOne(locacao.Filme.IdFilm);

                locacao.Cliente.Id = locacao.Cliente.IdCli;
                locacao.Filme.Id = locacao.Filme.IdFilm;

                if (filme == null || cliente== null)
                {
                    NotFound();
                }

                var result = _locacaoRepository.Create(locacao);

                return Created(nameof(Get), result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message, Result = ex.HResult });
            }
        }

        // PUT api/<LocadoraController>/5
        /// <summary>
        /// Atualiza uma locação na To-do list.
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     PUT /Todo
        ///     {
        ///        "DtLocacao": "2021-09-10T15:40:01",
        ///        "DtDevolucao": "2021-09-10T15:40:01",
        ///     }
        ///
        /// </remarks>
        /// <param name="value"></param>
        /// <response code="204">Se a Locacao for atualizada</response>
        /// <response code="400">Se a Locacao não for atualizada</response>
        [HttpPut("{idCli, idFilm}")]
        public ActionResult Put(int idCli, int idFilm, Locacao locacao)
        {
            try
            {
                if (idCli != locacao.Cliente.IdCli || idFilm != locacao.Filme.IdFilm) return BadRequest();
                _locacaoRepository.Update(locacao);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message, Result = ex.HResult });
            }

        }

        // DELETE api/<LocadoraController>/5
        /// <summary>
        /// Deleta uma locação da To-do list.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Um novo item criado</returns>
        /// <response code="204">Se a Locação for deletada</response>
        /// <response code="400">Se a Locação não for deletada</response>
        /// <response code="404">Se a Locação não for encontrada</response>
        [HttpDelete("{idCli, idFilm}")]
        public ActionResult Delete(int IdCli, int IdFilm)
        {
            try
            {
                var resultCli = _clienteRepository.GetOne(IdCli);
                var resultFilm = _filmeRepository.GetOne(IdFilm);
                if (resultCli == null || resultFilm == null)
                    return NotFound();

                _locacaoRepository.Delete(resultCli.IdCli, resultFilm.IdFilm);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message, Result = ex.HResult });
            }
        }
    }
}
