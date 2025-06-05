using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TicketManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public RolesController(AppDbContext context) => _context = context;

        [HttpGet]
        public IActionResult Get() => Ok(_context.Roles.ToList());
    }
}
