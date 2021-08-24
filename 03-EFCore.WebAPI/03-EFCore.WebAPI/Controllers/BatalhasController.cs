using _03_EFCore.WebAPI.Data;
using _03_EFCore.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace _03_EFCore.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BatalhasController : ControllerBase
    {
        private readonly HeroiContext _context = new HeroiContext();

        // GET: api/Batalhas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Batalha>>> GetBatalhas()
        {
            return _context.Batalhas.ToList();
        }

        // GET: api/Batalhas/:id
        [HttpGet("{id}")]
        public async Task<ActionResult<Batalha>> GetBatalhaId(int id)
        {
            return await _context.Batalhas.FindAsync(id);
        }


        // POST: api/Batalhas
        [HttpPost]
        public async Task<ActionResult<Batalha>> AddBatalha(Batalha batalha)
        {
            _context.Batalhas.Add(batalha);
            await _context.SaveChangesAsync();
            return batalha;
        }

        // PUT: api/Batalhas/:id
        [HttpPut("{id}")]
        public async Task<ActionResult<Batalha>> UpdateBatalha(int id, Batalha batalha)
        {
            if (id != batalha.Id)  return BadRequest();
            
            else  _context.Entry(batalha).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BatalhaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return batalha;
        }    


        // DELETE: api/Batalhas/:id
        [HttpDelete("{id}")]
        public async Task<ActionResult<Batalha>> DeteleBatalha(int id)
        {
            Batalha batalha = await _context.Batalhas.FindAsync(id);

            if (batalha != null)
            {
                _context.Batalhas.Remove(batalha);
                await _context.SaveChangesAsync();
            }
            return batalha;
        }

        private ActionResult<Batalha> BadRequest()
        {
            throw new NotImplementedException();
        }
        private bool BatalhaExists(int id)
        {
            Batalha batalha = _context.Batalhas.Find(id);
            if (batalha != null) return true;
            return false;
        }

        private ActionResult<Batalha> NotFound()
        {
            throw new NotImplementedException();
        }
    }
}
