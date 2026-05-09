using Microsoft.EntityFrameworkCore;

namespace SIGAPrincipal.BDAdministrativa
{
    public class DataAdministrativa : DbContext
    {
        public DataAdministrativa(DbContextOptions<DataAdministrativa> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("administrativa");
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Universidad> Universidades { get; set; }
        public DbSet<Solicitud> Solicitudes { get; set; }
        public DbSet<HistorialSolicitud> HistorialSolicitudes { get; set; }
        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<ConfiguracionUniversidad> ConfiguracionesUniversidad { get; set; }
        public DbSet<AsignacionUniversidadColaborador> Asignaciones { get; set; }
    }

    public class Universidad
    {
        public int UniversidadId { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public bool Estado { get; set; }
        public string? Nit { get; set; }
    }

    public class Solicitud
    {
        public int SolicitudId { get; set; }
        public int UniversidadId { get; set; } 
        public string? TipoSolicitud { get; set; }
        public string? EstadoSolicitud { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int ColaboradorId { get; set; } 
    }

    public class HistorialSolicitud
    {
        public int HistorialSolicitudId { get; set; }
        public int SolicitudId { get; set; } 
        public string? Accion { get; set; }
        public int ColaboradorId { get; set; } 
        public DateTime Fecha { get; set; }
    }

    public class Colaborador
    {
        public int ColaboradorId { get; set; } 
        public int UsuarioId { get; set; } 
        public string? Cargo { get; set; }
    }

    public class ConfiguracionUniversidad
    {
        public int ConfiguracionUniversidadId { get; set; }
        public int UniversidadId { get; set; } 
        public string? NombreInstitucional { get; set; }
        public string? Logo { get; set; }
        public string? ColoresTema { get; set; }
    }

    public class AsignacionUniversidadColaborador
    {
        public int AsignacionUniversidadColaboradorId { get; set; }
        public int UniversidadId { get; set; } 
        public int ColaboradorId { get; set; } 
    }
}