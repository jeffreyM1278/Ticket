namespace TicketManager.API.Models
{
    public class HistorialEstado
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public string EstadoAnterior { get; set; }
        public string EstadoNuevo { get; set; }
        public DateTime FechaCambio { get; set; }
        public int UsuarioId { get; set; }

        public Ticket Ticket { get; set; }
        public Usuario Usuario { get; set; }
    }
}
