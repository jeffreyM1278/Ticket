using System.ComponentModel.DataAnnotations;

namespace TicketManager.Web.Models
{
    public class TicketViewModel
    {
        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        public string Prioridad { get; set; } // Crítico, Medio, Bajo

        public int UsuarioCreadorId { get; set; } // lo agregamos desde la sesión
    }
}

