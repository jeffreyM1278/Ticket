using TicketManager.Web.Models;
namespace TicketManager.Web.Services

{
    public class ApiService
    {
        private readonly HttpClient _http;

        public ApiService(HttpClient http)
        {
            _http = http;
        }
        public async Task CrearTicketAsync(TicketViewModel model)
        {
            await _http.PostAsJsonAsync("api/tickets", model);
        }
        public async Task<Usuario> LoginAsync(string correo, string contraseña)
        {
            var body = new { Correo = correo, Contraseña = contraseña };
            var response = await _http.PostAsJsonAsync("api/auth/login", body);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Usuario>();
            }
            return null;
        }
    }
}
