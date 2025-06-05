using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketManager.API.Models;

namespace TicketManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentariosController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ComentariosController(AppDbContext context) => _context = context;

        [HttpPost]
        public IActionResult Post([FromBody] Comentario c)
        {
            c.FechaComentario = DateTime.Now;
            _context.Comentarios.Add(c);
            _context.SaveChanges();
            return Ok(c);
        }

        [HttpGet("{ticketId}")]
        public IActionResult GetPorTicket(int ticketId)
            => Ok(_context.Comentarios.Where(c => c.TicketId == ticketId).ToList());
    }

}
