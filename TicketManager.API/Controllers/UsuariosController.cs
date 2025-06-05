using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketManager.API.Models;

namespace TicketManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UsuariosController(AppDbContext context) => _context = context;

        [HttpGet]
        public IActionResult Get() => Ok(_context.Usuarios.Include(u => u.Rol).ToList());

        [HttpGet("{id}")]
        public IActionResult Get(int id) => Ok(_context.Usuarios.Find(id));

        [HttpPost]
        public IActionResult Post([FromBody] Usuario u)
        {
            _context.Usuarios.Add(u);
            _context.SaveChanges();
            return Ok(u);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Usuario u)
        {
            var actual = _context.Usuarios.Find(id);
            if (actual == null) return NotFound();
            actual.Nombre = u.Nombre;
            actual.Correo = u.Correo;
            actual.Telefono = u.Telefono;
            actual.Contraseña = u.Contraseña;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario == null) return NotFound();
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
