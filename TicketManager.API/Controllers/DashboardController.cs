using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TicketManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly AppDbContext _context;
        public DashboardController(AppDbContext context) => _context = context;

        [HttpGet("resumen")]
        public IActionResult Resumen()
        {
            var total = _context.Tickets.Count();
            var abiertos = _context.Tickets.Count(t => t.Estado == "Abierto");
            var cerrados = _context.Tickets.Count(t => t.Estado == "Cerrado");
            return Ok(new { total, abiertos, cerrados });
        }

        [HttpGet("por-fecha")]
        public IActionResult PorFecha(DateTime desde, DateTime hasta)
        {
            var data = _context.Tickets
                .Where(t => t.FechaCreacion >= desde && t.FechaCreacion <= hasta)
                .GroupBy(t => t.FechaCreacion.Date)
                .Select(g => new {
                    Fecha = g.Key,
                    Total = g.Count()
                });
            return Ok(data);
        }
    }

}
