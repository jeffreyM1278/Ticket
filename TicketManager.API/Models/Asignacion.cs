namespace TicketManager.API.Models
{
    public class Asignacion
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public int UsuarioAsignadoId { get; set; }
        public DateTime FechaAsignacion { get; set; }

        public Ticket Ticket { get; set; }
        public Usuario UsuarioAsignado { get; set; }
    }
}
