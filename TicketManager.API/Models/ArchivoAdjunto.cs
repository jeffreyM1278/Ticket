namespace TicketManager.API.Models
{
    public class ArchivoAdjunto
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public string NombreArchivo { get; set; }
        public string RutaArchivo { get; set; }

        public Ticket Ticket { get; set; }
    }

}
