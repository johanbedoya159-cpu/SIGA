using Microsoft.EntityFrameworkCore;

namespace SIGAPrincipal.BDAcademico
{
    public class DataAcademico : DbContext
    {
        public DataAcademico(DbContextOptions<DataAcademico> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("academico");
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<HistorialAcademico> HistorialAcademicos { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Inscripcion> Inscripciones { get; set; }
        public DbSet<Calificacion> Calificaciones { get; set; }
        public DbSet<OfertaAcademica> OfertasAcademicas { get; set; }
        public DbSet<Periodo> Periodos { get; set; }
        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Docente> Docentes { get; set; }
        public DbSet<Programa> Programas { get; set; }
    }

    public class HistorialAcademico
    {
        public int HistorialAcademicoId { get; set; }
        public int AsignaturaId { get; set; } 
        public string? NombreAsignatura { get; set; }
        public int CreditosAsignatura { get; set; }
        public int Cupos { get; set; }
    }

    public class Estudiante
    {
        public int EstudianteId { get; set; } 
        public int UsuarioId { get; set; } 
        public string? CodigoEstudiante { get; set; }
        public int ProgramaId { get; set; } 
    }

    public class Inscripcion
    {
        public int InscripcionId { get; set; }
        public int UsuarioId { get; set; } 
        public int OfertaAcademicaId { get; set; } 
        public DateTime FechaInscripcion { get; set; }
        public bool Estado { get; set; }
        public int PeriodoId { get; set; } 
    }

    public class Calificacion
    {
        public int CalificacionId { get; set; }
        public double Nota { get; set; }
        public string? TipoNota { get; set; }
        public int InscripcionId { get; set; } 
    }

    public class OfertaAcademica
    {
        public int OfertaAcademicaId { get; set; }
        public int AsignaturaId { get; set; } 
        public int PeriodoId { get; set; } 
        public int CuposMaximos { get; set; }
        public int CuposDisponibles { get; set; }
        public bool Estado { get; set; }
    }

    public class Periodo
    {
        public int PeriodoId { get; set; }
        public string? NombrePeriodo { get; set; }
        public bool Estado { get; set; }
    }

    public class Asignatura
    {
        public int AsignaturaId { get; set; }
        public string? NombreAsignatura { get; set; }
        public int CreditosAsignatura { get; set; }
        public int CuposAsignatura { get; set; }
    }

    public class Horario
    {
        public int HorarioId { get; set; }
        public int GrupoId { get; set; } 
        public string? Aula { get; set; }
        public string? Dia { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
    }

    public class Grupo
    {
        public int GrupoId { get; set; }
        public int DocenteId { get; set; } 
        public int AsignaturaId { get; set; } 
        public string? NombreGrupo { get; set; }
        public int HorarioId { get; set; } 
    }

    public class Docente
    {
        public int DocenteId { get; set; } 
        public int UsuarioId { get; set; } 
        public string? Especialidad { get; set; }
    }

    public class Programa
    {
        public int ProgramaId { get; set; }
        public string? NombrePrograma { get; set; }
    }
}
