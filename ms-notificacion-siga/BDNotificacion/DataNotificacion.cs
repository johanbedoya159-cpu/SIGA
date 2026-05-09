using Microsoft.EntityFrameworkCore;

namespace SIGAPrincipal.BDNotificacion
{
    public class DataNotificacion : DbContext
    {
        public DataNotificacion(DbContextOptions<DataNotificacion> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("notificacion");
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Notificacion> Notificaciones { get; set; }
    }

    public class Notificacion
    {
        public int NotificacionId { get; set; }
        public string? Mensaje { get; set; }
        public DateTime Fecha { get; set; }
        public string? TipoNotificacion { get; set; }
    }
}
