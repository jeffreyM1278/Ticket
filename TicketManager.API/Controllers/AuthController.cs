using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketManager.API.Models;

namespace TicketManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        public AuthController(AppDbContext context) => _context = context;

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto login)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Correo == login.Correo && u.Contraseña == login.Contraseña);
            if (usuario == null) return Unauthorized("Credenciales inválidas");
            return Ok(usuario);
        }

        [HttpPost("register-cliente")]
        public IActionResult RegisterCliente([FromBody] Usuario nuevo)
        {
            nuevo.TipoUsuario = "Externo";
            nuevo.RolId = 3; // Cliente
            _context.Usuarios.Add(nuevo);
            _context.SaveChanges();
            return Ok(nuevo);
        }
    }

}
