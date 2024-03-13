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
    public class PrioridadesController : ControllerBase
    {
        private readonly Contexto _context;

        public PrioridadesController(Contexto context)
        {
            _context = context;
        }

        // GET: api/Prioridades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prioridades>>> GetPrioridades()
        {
            return await _context.Prioridades.ToListAsync();
        }

        // GET: api/Prioridades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Prioridades>> GetPrioridades(int id)
        {
            var prioridades = await _context.Prioridades.FindAsync(id);

            if (prioridades == null)
            {
                return NotFound();
            }

            return prioridades;
        }

        // PUT: api/Prioridades/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrioridades(int id, Prioridades prioridades)
        {
            if (id != prioridades.PrioridadId)
            {
                return BadRequest();
            }

            _context.Entry(prioridades).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrioridadesExists(id))
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

        // POST: api/Prioridades
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Prioridades>> PostPrioridades(Prioridades prioridades)
        {
            if (prioridades.PrioridadId <= 0 || !PrioridadesExists(prioridades.PrioridadId))
            {
                _context.Prioridades.Add(prioridades);
            }
            else
            {
                _context.Prioridades.Update(prioridades);
            }
            await _context.SaveChangesAsync();
            return Ok(prioridades);
        }

        // DELETE: api/Prioridades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrioridades(int id)
        {
            if (!_context.Prioridades.Any())
            {
                return NotFound();
            }
            var prioridades = await _context.Prioridades.FindAsync(id);
            if (prioridades == null)
            {
                return NotFound();
            }
            _context.Prioridades.Remove(prioridades);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Prioridades
        [HttpDelete("DeleteDetail/{id}")]
        public async Task<IActionResult> DeleteDetail(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var detail = await _context.Prioridades.FirstOrDefaultAsync(t => t.PrioridadId == id);
            if (detail == null)
            {
                return NotFound();
            }
            _context.Prioridades.Remove(detail);
            await _context.SaveChangesAsync();
            return Ok();
        }

        private bool PrioridadesExists(int id)
        {
            return _context.Prioridades.Any(e => e.PrioridadId == id);
        }
    }
}
