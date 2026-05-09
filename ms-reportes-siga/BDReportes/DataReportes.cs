using Microsoft.EntityFrameworkCore;

namespace SIGAPrincipal.BDReportes
{
    public class DataReportes : DbContext
    {
        public DataReportes(DbContextOptions<DataReportes> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("reportes");
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Reporte> Reportes { get; set; }
    }

    public class Reporte
    {
        public int ReporteId { get; set; }
        public string? Tipo { get; set; }
        public DateTime FechaGeneracion { get; set; }
        public int UsuarioId { get; set; } 
    }
}
