using Microsoft.EntityFrameworkCore;
using TicketManager.API.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Rol> Roles { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Asignacion> Asignaciones { get; set; }
    public DbSet<Comentario> Comentarios { get; set; }
    public DbSet<ArchivoAdjunto> ArchivosAdjuntos { get; set; }
    public DbSet<HistorialEstado> HistorialEstados { get; set; }

    
}

