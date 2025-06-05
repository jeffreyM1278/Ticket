using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketManager.API.Models;

namespace TicketManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArchivosController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ArchivosController(AppDbContext context) => _context = context;

        [HttpPost]
        public IActionResult Post([FromBody] ArchivoAdjunto a)
        {
            _context.ArchivosAdjuntos.Add(a);
            _context.SaveChanges();
            return Ok(a);
        }

        [HttpGet("{ticketId}")]
        public IActionResult GetPorTicket(int ticketId)
            => Ok(_context.ArchivosAdjuntos.Where(a => a.TicketId == ticketId).ToList());
    }
}
