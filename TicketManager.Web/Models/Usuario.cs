namespace TicketManager.Web.Models
{
    public class Rol
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }

    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string TipoUsuario { get; set; }
        public string Contraseña { get; set; }
        public int RolId { get; set; }

        public Rol Rol { get; set; }
    }
}