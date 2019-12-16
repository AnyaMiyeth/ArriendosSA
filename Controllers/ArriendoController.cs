using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NgNetCore.Data;
using NgNetCore.Models;
using NgNetCore.ViewModels;

namespace NgNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArriendoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ArriendoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Arriendoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Arriendo>>> GetArriendo()
        {
            return await _context.Arriendos.ToListAsync();
        }

        // GET: api/Arriendoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Arriendo>> GetArriendo(string id)
        {
            var arriendo = await _context.Arriendos.FindAsync(id);

            if (arriendo == null)
            {
                return NotFound();
            }

            return arriendo;
        }

        // PUT: api/Arriendoes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArriendo(int id, Arriendo arriendo)
        {
            if (id != arriendo.Id)
            {
                return BadRequest();
            }

            _context.Entry(arriendo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArriendoExists(id))
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

        // POST: api/Arriendoes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Arriendo>> PostArriendo(ArriendoRegistrarRequest request)
        {
            var cliente = await _context.Clientes.FindAsync(request.ClienteId);
            var inmueble= await _context.Inmuebles.FindAsync(request.InmuebleMatricula);
            if (cliente == null)
            {
                ModelState.AddModelError("Cliente", "El cliente no se encuentra registrado");
            }
            if (inmueble == null)
            {
                ModelState.AddModelError("Inmueble", "El inmueble no se encuentra registrado");
            }
            if (!ModelState.IsValid) 
            {
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
            }

            var arriendo = new Arriendo(cliente, inmueble, request.Mes);

            _context.Arriendos.Add(arriendo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Guardando Datos", "Se presentó un inconveniente guardando los datos: " + ex.Message);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);

            }

            return CreatedAtAction("GetArriendo", new { id = arriendo.Id }, arriendo);
        }

        // DELETE: api/Arriendoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Arriendo>> DeleteArriendo(string id)
        {
            var arriendo = await _context.Arriendos.FindAsync(id);
            if (arriendo == null)
            {
                return NotFound();
            }

            _context.Arriendos.Remove(arriendo);
            await _context.SaveChangesAsync();

            return arriendo;
        }

        private bool ArriendoExists(int id)
        {
            return _context.Arriendos.Any(e => e.Id == id);
        }
   
    }
}
