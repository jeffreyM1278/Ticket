namespace TicketManager.API.Models
{
    public class Comentario
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public int UsuarioId { get; set; }
        public string Contenido { get; set; }
        public DateTime FechaComentario { get; set; }

        public Ticket Ticket { get; set; }
        public Usuario Usuario { get; set; }
    }
}
