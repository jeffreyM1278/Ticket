using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketManager.API.Models;

namespace TicketManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TicketsController(AppDbContext context) => _context = context;

        [HttpGet]
        public IActionResult Get() => Ok(_context.Tickets.Include(t => t.UsuarioCreador).ToList());

        [HttpGet("{id}")]
        public IActionResult Get(int id) => Ok(_context.Tickets.Find(id));

        [HttpGet("por-usuario/{id}")]
        public IActionResult GetPorUsuario(int id)
            => Ok(_context.Tickets.Where(t => t.UsuarioCreadorId == id).ToList());

        [HttpPost]
        public IActionResult Post([FromBody] Ticket t)
        {
            t.FechaCreacion = DateTime.Now;
            t.Estado = "Abierto";
            _context.Tickets.Add(t);
            _context.SaveChanges();
            return Ok(t);
        }

        [HttpPut("{id}/estado")]
        public IActionResult CambiarEstado(int id, [FromBody] string nuevoEstado)
        {
            var ticket = _context.Tickets.Find(id);
            if (ticket == null) return NotFound();
            string anterior = ticket.Estado;
            ticket.Estado = nuevoEstado;
            _context.HistorialEstados.Add(new HistorialEstado
            {
                TicketId = id,
                EstadoAnterior = anterior,
                EstadoNuevo = nuevoEstado,
                FechaCambio = DateTime.Now,
                UsuarioId = ticket.UsuarioCreadorId
            });
            _context.SaveChanges();
            return NoContent();
        }
    }

}
