namespace TicketManager.API.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Prioridad { get; set; }
        public string Estado { get; set; }
        public DateTime FechaCreacion { get; set; }

        public int UsuarioCreadorId { get; set; }
        public Usuario UsuarioCreador { get; set; }
    }
}
