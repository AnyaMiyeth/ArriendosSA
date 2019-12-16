using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NgNetCore.Data;
using NgNetCore.Models;
using NgNetCore.ViewModels;

namespace NgNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public ClienteController(ApplicationDbContext context)
        {
            _context = context;
            if (!_context.Clientes.Any())
            {
                var clientes = new List<Cliente>
                {
                    new Cliente { Identificacion = "12", NombreCompleto = "Andrea Pérez", Email = "q@a.com", Telefono = "31755533333" },
                    new Cliente { Identificacion = "13", NombreCompleto = "Pedro Pedroza", Email = "q@a.com", Telefono = "31855533333" }
                };
                _context.AddRange(clientes);
                _context.SaveChanges();
            }
        }
        
   

        [HttpGet]
        public IEnumerable<ClienteViewModel> Get()
        {
            return _context.Clientes.Select(c => new ClienteViewModel
            {
                Identificacion = c.Identificacion,
                Email = c.Email,
                NombreCompleto = c.NombreCompleto,
                Telefono = c.Telefono
            });
        }

        [HttpGet("{identificacion}")]
        public ClienteViewModel Get(string identificacion)
        {
            return _context.Clientes.Where(t => t.Identificacion == identificacion).Select(c => new ClienteViewModel
            {
                Identificacion = c.Identificacion,
                Email = c.Email,
                NombreCompleto = c.NombreCompleto,
                Telefono = c.Telefono
            }).FirstOrDefault();

        }
        [HttpPost]
        public async Task<ActionResult<ClienteViewModel>> PostCliente(ClienteViewModel request)
        {
            var cliente = await _context.Clientes.FindAsync(request.Identificacion);
            if (cliente != null)
            {
                ModelState.AddModelError("Cliente", "El cliente ya se encuentra registrado");
            }
            
            if (!ModelState.IsValid)
            {
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
            }

            cliente = new Cliente()
            {
                Identificacion = request.Identificacion,
                Email = request.Email,
                NombreCompleto = request.NombreCompleto,
                Telefono = request.Telefono
            };

            _context.Clientes.Add(cliente);
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

            return CreatedAtAction("GetArriendo", new { id = cliente.Identificacion }, cliente);
        }

       

    }
}