using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Library.Models;
using MigrarTareasAWASM.Api.DAL;

namespace MigrarTareasAWASM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SistemasController : ControllerBase
    {
        private readonly Contexto _context;

        public SistemasController(Contexto context)
        {
            _context = context;
        }

        // GET: api/Sistemas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sistemas>>> GetSistema()
        {
            return await _context.Sistema.ToListAsync();
        }

        // GET: api/Sistemas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sistemas>> GetSistemas(int id)
        {
            var sistemas = await _context.Sistema.FindAsync(id);

            if (sistemas == null)
            {
                return NotFound();
            }

            return sistemas;
        }

        // PUT: api/Sistemas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSistemas(int id, Sistemas sistemas)
        {
            if (id != sistemas.SistemaId)
            {
                return BadRequest();
            }

            _context.Entry(sistemas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SistemasExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        // POST: api/Sistemas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sistemas>> PostSistemas(Sistemas sistemas)
        {
            if (sistemas.SistemaId <= 0 || !SistemasExists(sistemas.SistemaId))
            {
                _context.Sistema.Add(sistemas);
            }
            else
            {
                _context.Sistema.Update(sistemas);
            }
            await _context.SaveChangesAsync();
            return Ok(sistemas);
        }
        // DELETE: api/Sistemas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSistemas(int id)
        {
            if (!_context.Sistema.Any())
            {
                return NotFound();
            }
            var sistemas = await _context.Sistema.FindAsync(id);
            if (sistemas == null)
            {
                return NotFound();
            }
            _context.Sistema.Remove(sistemas);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        // DELETE: api/Sistemas
        [HttpDelete("DeleteDetail/{id}")]
        public async Task<IActionResult> DeleteDetail(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var detail = await _context.Sistema.FirstOrDefaultAsync(s => s.SistemaId == id);
            if (detail == null)
            {
                return NotFound();
            }
            _context.Sistema.Remove(detail);
            await _context.SaveChangesAsync();
            return Ok();
        }
        private bool SistemasExists(int id)
        {
            return _context.Sistema.Any(s => s.SistemaId == id);
        }
    }
}
