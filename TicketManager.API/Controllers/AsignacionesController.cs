using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketManager.API.Models;

namespace TicketManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsignacionesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public AsignacionesController(AppDbContext context) => _context = context;

        [HttpPost]
        public IActionResult Post([FromBody] Asignacion a)
        {
            a.FechaAsignacion = DateTime.Now;
            _context.Asignaciones.Add(a);
            _context.SaveChanges();
            return Ok(a);
        }

        [HttpGet("{ticketId}")]
        public IActionResult GetPorTicket(int ticketId)
            => Ok(_context.Asignaciones.Where(a => a.TicketId == ticketId).ToList());
    }
}
