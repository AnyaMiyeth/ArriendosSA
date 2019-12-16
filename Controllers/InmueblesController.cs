using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NgNetCore.Data;
using NgNetCore.Models;

namespace NgNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InmueblesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InmueblesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Inmuebles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inmueble>>> GetInmueble()
        {
            return await _context.Inmueble.ToListAsync();
        }

        // GET: api/Inmuebles/5
        [HttpGet("{NumeroMatricula}")]
        public async Task<ActionResult<Inmueble>> GetInmueble(string NumeroMatricula)
        {
            var inmueble = await _context.Inmueble.FindAsync(NumeroMatricula);

            if (inmueble == null)
            {
                return NotFound();
            }

            return inmueble;
        }

        // PUT: api/Inmuebles/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{NumeroMatricula}")]
        public async Task<IActionResult> PutInmueble(string NumeroMatricula, Inmueble inmueble)
        {
            if (NumeroMatricula != inmueble.NumeroMatricula)
            {
                return BadRequest();
            }

            _context.Entry(inmueble).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InmuebleExists(NumeroMatricula))
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

        // POST: api/Inmuebles
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Inmueble>> PostInmueble(Inmueble inmueble)
        {
            _context.Inmueble.Add(inmueble);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (InmuebleExists(inmueble.NumeroMatricula))
                {
                    ModelState.AddModelError("Inmueble", "El numero de Matricula que intenta registrar ya existe");
                    var problemDetails = new ValidationProblemDetails(ModelState)
                    {
                        Status = StatusCodes.Status409Conflict,
                    };
                    return BadRequest(problemDetails);
                }

                
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetInmueble", new { NumeroMatricula = inmueble.NumeroMatricula }, inmueble);
        }

        // DELETE: api/Inmuebles/5
        [HttpDelete("{NumeroMatricula}")]
        public async Task<ActionResult<Inmueble>> DeleteInmueble(string NumeroMatricula)
        {
            var inmueble = await _context.Inmueble.FindAsync(NumeroMatricula);
            if (inmueble == null)
            {
                return NotFound();
            }

            _context.Inmueble.Remove(inmueble);
            await _context.SaveChangesAsync();

            return inmueble;
        }

        private bool InmuebleExists(string NumeroMatricula)
        {
            return _context.Inmueble.Any(e => e.NumeroMatricula == NumeroMatricula);
        }
    }
}
