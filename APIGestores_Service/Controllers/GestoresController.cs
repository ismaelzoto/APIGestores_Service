using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIGestores_Service.Data;
using APIGestores_Service.Modelo;

namespace APIGestores_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GestoresController : ControllerBase
    {
        private readonly APIGestores_ServiceContext _context;

        public GestoresController(APIGestores_ServiceContext context)
        {
            _context = context;
        }

        // GET: api/Gestores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gestores>>> GetGestores()
        {
            return await _context.Gestores.ToListAsync();
        }

        // GET: api/Gestores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gestores>> GetGestores(int id)
        {
            var gestores = await _context.Gestores.FindAsync(id);

            if (gestores == null)
            {
                return NotFound();
            }

            return gestores;
        }

        // PUT: api/Gestores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGestores(int id, Gestores gestores)
        {
            if (id != gestores.id)
            {
                return BadRequest();
            }

            _context.Entry(gestores).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GestoresExists(id))
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

        // POST: api/Gestores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Gestores>> PostGestores(Gestores gestores)
        {
            _context.Gestores.Add(gestores);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGestores", new { id = gestores.id }, gestores);
        }

        // DELETE: api/Gestores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGestores(int id)
        {
            var gestores = await _context.Gestores.FindAsync(id);
            if (gestores == null)
            {
                return NotFound();
            }

            _context.Gestores.Remove(gestores);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GestoresExists(int id)
        {
            return _context.Gestores.Any(e => e.id == id);
        }
    }
}
