using Microsoft.AspNetCore.Mvc;
using TicketManager.Web.Models;
using TicketManager.Web.Services;

namespace TicketManager.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApiService _api;

        public AccountController(ApiService api)
        {
            _api = api;
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var usuario = await _api.LoginAsync(model.Correo, model.Contraseña);
            if (usuario == null)
            {
                ViewBag.Error = "Credenciales inválidas";
                return View(model);
            }

            HttpContext.Session.SetInt32("UsuarioId", usuario.Id);
            HttpContext.Session.SetString("Nombre", usuario.Nombre);
            HttpContext.Session.SetString("Rol", usuario.Rol?.Nombre ?? "");

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }

}
