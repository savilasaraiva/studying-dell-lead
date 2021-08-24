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
    public class HeroisController : ControllerBase
    {
        //private readonly HeroisRepository _repository;
        private readonly HeroiContext _context = new HeroiContext();

        /*public HeroisController(HeroisRepository repository, HeroiContext context)
        {
            _repository = repository;
            _context = context;
        }*/

        // GET: api/Herois
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Heroi>>> GetHerois()
        {
            return await _context.Herois.ToListAsync();
        }

        // GET: api/Herois/:id
        [HttpGet("{id}")]
        public async Task<ActionResult<Heroi>> GetHeroiId(int id)
        {
            return await _context.Herois.FindAsync(id);
        }

        // POST: api/Herois
        [HttpPost]
        public async Task<ActionResult<Heroi>> AddHeroi(Heroi heroi)
        {
            _context.Herois.Add(heroi);
            await _context.SaveChangesAsync();
            return heroi;
        }

        // PUT: api/Herois/:id
        [HttpPut("{id}")]
        public async Task<ActionResult<Heroi>> UpdateHeroi(int id, Heroi heroi)
        {
            if (id != heroi.Id) return BadRequest();

            else _context.Entry(heroi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HeroiExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return heroi;
        }

        // DELETE: api/Herois/:id
        [HttpDelete("{id}")]
        public async Task<ActionResult<Heroi>> DeteleHeroi(int id)
        {
            Heroi heroi = await _context.Herois.FindAsync(id);
            _context.Herois.Remove(heroi);
            await _context.SaveChangesAsync();
            return heroi;
        }

        private bool HeroiExists(int id)
        {
            Batalha batalha = _context.Batalhas.Find(id);
            if (batalha != null) return true;
            return false;
        }
    }
}
