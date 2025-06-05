using System.ComponentModel.DataAnnotations;

namespace TicketManager.Web.Models
{
    public class LoginViewModel
    {
        [Required]
        public string Correo { get; set; }

        [Required]
        public string Contraseña { get; set; }
    }
}
