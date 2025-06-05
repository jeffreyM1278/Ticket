using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TicketManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialController : ControllerBase
    {
        private readonly AppDbContext _context;
        public HistorialController(AppDbContext context) => _context = context;

        [HttpGet("{ticketId}")]
        public IActionResult GetHistorial(int ticketId)
            => Ok(_context.HistorialEstados.Where(h => h.TicketId == ticketId).ToList());
    }
}
