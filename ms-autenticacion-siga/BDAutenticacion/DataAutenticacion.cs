using Microsoft.EntityFrameworkCore;

namespace SIGAPrincipal.BDAutenticacion
{
    public class DataAutenticacion : DbContext
    {
        public DataAutenticacion(DbContextOptions<DataAutenticacion> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("autenticacion");

            
            modelBuilder.Entity<UsuarioRol>()
                .HasKey(ur => new { ur.UsuarioId, ur.RolId });

            modelBuilder.Entity<RolPermiso>()
                .HasKey(rp => new { rp.RolId, rp.PermisoId });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<UsuarioRol> UsuarioRoles { get; set; }
        public DbSet<Permiso> Permisos { get; set; }
        public DbSet<RolPermiso> RolPermisos { get; set; }
    }

    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string? PrimerNombre { get; set; }
        public string? SegundoNombre { get; set; }
        public string? PrimerApellido { get; set; }
        public string? SegundoApellido { get; set; }
        public string? Correo { get; set; }
        public string? ContrasenaHash { get; set; } 
        public bool Estado { get; set; }
        public int UniversidadId { get; set; } 
    }

    public class UsuarioRol
    {
        public int UsuarioId { get; set; }
        public int RolId { get; set; }
    }

    public class Rol
    {
        public int RolId { get; set; }
        public string? Nombre { get; set; }
    }

    public class RolPermiso
    {
        public int RolId { get; set; }
        public int PermisoId { get; set; }
    }

    public class Permiso
    {
        public int PermisoId { get; set; }
        public string? Nombre { get; set; }
    }
}