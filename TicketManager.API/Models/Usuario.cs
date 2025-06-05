namespace TicketManager.API.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string TipoUsuario { get; set; } // Interno o Externo
        public string Contraseña { get; set; }
        public int RolId { get; set; }

        public Rol Rol { get; set; }
        public ICollection<Ticket> TicketsCreados { get; set; }
    }
}
