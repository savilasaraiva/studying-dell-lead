using _03_EFCore.WebAPI.Data;
using _03_EFCore.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _03_EFCore.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArmasController : ControllerBase
    {
        private readonly HeroiContext _context = new HeroiContext();


        // GET: api/Armas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Arma>>> GetArmas()
        {
            return _context.Armas.ToList();
        }

        // GET: api/Armas/:id
        [HttpGet("{id}")]
        public async Task<ActionResult<Arma>> GetArmaId(int id)
        {
            return await _context.Armas.FindAsync(id);
        }

        // POST: api/Armas
        [HttpPost]
        public async Task<ActionResult<Arma>> AddArmas(Arma arma)
        {
            _context.Armas.Add(arma);
            await _context.SaveChangesAsync();
            return arma;
        }

        // PUT: api/Armas/:id
        [HttpPut("{id}")]
        public async Task<ActionResult<Arma>> UpdateArma(int id, Arma arma)
        {

            if (id != arma.Id) return BadRequest();

            else _context.Entry(arma).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArmaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return arma;
        }

        // DELETE: api/Armas/:id
        [HttpDelete("{id}")]
        public async Task<ActionResult<Arma>> DeteleArma(int id)
        {
            Arma arma = await _context.Armas.FindAsync(id);
            _context.Armas.Remove(arma);
            await _context.SaveChangesAsync();
            return arma;
        }
        private bool ArmaExists(int id)
        {
            Arma arma = _context.Armas.Find(id);
            if (arma != null) return true;
            return false;
        }

    }
}
