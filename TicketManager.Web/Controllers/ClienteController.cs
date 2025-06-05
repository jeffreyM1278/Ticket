using Microsoft.AspNetCore.Mvc;
using TicketManager.Web.Models;
using TicketManager.Web.Services;

namespace TicketManager.Web.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ApiService _api;

        public ClienteController(ApiService api)
        {
            _api = api;
        }

        public IActionResult Dashboard()
        {
            ViewBag.Nombre = HttpContext.Session.GetString("Nombre");
            return View();
        }

        [HttpGet]
        public IActionResult CrearTicket()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearTicket(TicketViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            int? userId = HttpContext.Session.GetInt32("UsuarioId");
            if (userId == null) return RedirectToAction("Login", "Account");

            model.UsuarioCreadorId = userId.Value;
            await _api.CrearTicketAsync(model);

            TempData["mensaje"] = "Ticket creado correctamente.";
            return RedirectToAction("Dashboard");
        }
    }
}