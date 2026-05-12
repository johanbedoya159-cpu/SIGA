using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SIGAPrincipal.Migrations
{
    /// <inheritdoc />
    public partial class InitAcademico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "academico");

            migrationBuilder.CreateTable(
                name: "Asignaturas",
                schema: "academico",
                columns: table => new
                {
                    AsignaturaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NombreAsignatura = table.Column<string>(type: "text", nullable: true),
                    CreditosAsignatura = table.Column<int>(type: "integer", nullable: false),
                    CuposAsignatura = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignaturas", x => x.AsignaturaId);
                });

            migrationBuilder.CreateTable(
                name: "Calificaciones",
                schema: "academico",
                columns: table => new
                {
                    CalificacionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nota = table.Column<double>(type: "double precision", nullable: false),
                    TipoNota = table.Column<string>(type: "text", nullable: true),
                    InscripcionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calificaciones", x => x.CalificacionId);
                });

            migrationBuilder.CreateTable(
                name: "Docentes",
                schema: "academico",
                columns: table => new
                {
                    DocenteId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UsuarioId = table.Column<int>(type: "integer", nullable: false),
                    Especialidad = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docentes", x => x.DocenteId);
                });

            migrationBuilder.CreateTable(
                name: "Estudiantes",
                schema: "academico",
                columns: table => new
                {
                    EstudianteId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UsuarioId = table.Column<int>(type: "integer", nullable: false),
                    CodigoEstudiante = table.Column<string>(type: "text", nullable: true),
                    ProgramaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.EstudianteId);
                });

            migrationBuilder.CreateTable(
                name: "Grupos",
                schema: "academico",
                columns: table => new
                {
                    GrupoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DocenteId = table.Column<int>(type: "integer", nullable: false),
                    AsignaturaId = table.Column<int>(type: "integer", nullable: false),
                    NombreGrupo = table.Column<string>(type: "text", nullable: true),
                    HorarioId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupos", x => x.GrupoId);
                });

            migrationBuilder.CreateTable(
                name: "HistorialAcademicos",
                schema: "academico",
                columns: table => new
                {
                    HistorialAcademicoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AsignaturaId = table.Column<int>(type: "integer", nullable: false),
                    NombreAsignatura = table.Column<string>(type: "text", nullable: true),
                    CreditosAsignatura = table.Column<int>(type: "integer", nullable: false),
                    Cupos = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialAcademicos", x => x.HistorialAcademicoId);
                });

            migrationBuilder.CreateTable(
                name: "Horarios",
                schema: "academico",
                columns: table => new
                {
                    HorarioId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GrupoId = table.Column<int>(type: "integer", nullable: false),
                    Aula = table.Column<string>(type: "text", nullable: true),
                    Dia = table.Column<string>(type: "text", nullable: true),
                    HoraInicio = table.Column<TimeSpan>(type: "interval", nullable: false),
                    HoraFin = table.Column<TimeSpan>(type: "interval", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horarios", x => x.HorarioId);
                });

            migrationBuilder.CreateTable(
                name: "Inscripciones",
                schema: "academico",
                columns: table => new
                {
                    InscripcionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UsuarioId = table.Column<int>(type: "integer", nullable: false),
                    OfertaAcademicaId = table.Column<int>(type: "integer", nullable: false),
                    FechaInscripcion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Estado = table.Column<bool>(type: "boolean", nullable: false),
                    PeriodoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscripciones", x => x.InscripcionId);
                });

            migrationBuilder.CreateTable(
                name: "OfertasAcademicas",
                schema: "academico",
                columns: table => new
                {
                    OfertaAcademicaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AsignaturaId = table.Column<int>(type: "integer", nullable: false),
                    PeriodoId = table.Column<int>(type: "integer", nullable: false),
                    CuposMaximos = table.Column<int>(type: "integer", nullable: false),
                    CuposDisponibles = table.Column<int>(type: "integer", nullable: false),
                    Estado = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfertasAcademicas", x => x.OfertaAcademicaId);
                });

            migrationBuilder.CreateTable(
                name: "Periodos",
                schema: "academico",
                columns: table => new
                {
                    PeriodoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NombrePeriodo = table.Column<string>(type: "text", nullable: true),
                    Estado = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periodos", x => x.PeriodoId);
                });

            migrationBuilder.CreateTable(
                name: "Programas",
                schema: "academico",
                columns: table => new
                {
                    ProgramaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NombrePrograma = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programas", x => x.ProgramaId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asignaturas",
                schema: "academico");

            migrationBuilder.DropTable(
                name: "Calificaciones",
                schema: "academico");

            migrationBuilder.DropTable(
                name: "Docentes",
                schema: "academico");

            migrationBuilder.DropTable(
                name: "Estudiantes",
                schema: "academico");

            migrationBuilder.DropTable(
                name: "Grupos",
                schema: "academico");

            migrationBuilder.DropTable(
                name: "HistorialAcademicos",
                schema: "academico");

            migrationBuilder.DropTable(
                name: "Horarios",
                schema: "academico");

            migrationBuilder.DropTable(
                name: "Inscripciones",
                schema: "academico");

            migrationBuilder.DropTable(
                name: "OfertasAcademicas",
                schema: "academico");

            migrationBuilder.DropTable(
                name: "Periodos",
                schema: "academico");

            migrationBuilder.DropTable(
                name: "Programas",
                schema: "academico");
        }
    }
}
