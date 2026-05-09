using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SIGAPrincipal.Migrations.DataAdministrativaMigrations
{
    /// <inheritdoc />
    public partial class InitAdministrativa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "administrativa");

            migrationBuilder.CreateTable(
                name: "Asignaciones",
                schema: "administrativa",
                columns: table => new
                {
                    AsignacionUniversidadColaboradorId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UniversidadId = table.Column<int>(type: "integer", nullable: false),
                    ColaboradorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignaciones", x => x.AsignacionUniversidadColaboradorId);
                });

            migrationBuilder.CreateTable(
                name: "Colaboradores",
                schema: "administrativa",
                columns: table => new
                {
                    ColaboradorId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UsuarioId = table.Column<int>(type: "integer", nullable: false),
                    Cargo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaboradores", x => x.ColaboradorId);
                });

            migrationBuilder.CreateTable(
                name: "ConfiguracionesUniversidad",
                schema: "administrativa",
                columns: table => new
                {
                    ConfiguracionUniversidadId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UniversidadId = table.Column<int>(type: "integer", nullable: false),
                    NombreInstitucional = table.Column<string>(type: "text", nullable: true),
                    Logo = table.Column<string>(type: "text", nullable: true),
                    ColoresTema = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfiguracionesUniversidad", x => x.ConfiguracionUniversidadId);
                });

            migrationBuilder.CreateTable(
                name: "HistorialSolicitudes",
                schema: "administrativa",
                columns: table => new
                {
                    HistorialSolicitudId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SolicitudId = table.Column<int>(type: "integer", nullable: false),
                    Accion = table.Column<string>(type: "text", nullable: true),
                    ColaboradorId = table.Column<int>(type: "integer", nullable: false),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialSolicitudes", x => x.HistorialSolicitudId);
                });

            migrationBuilder.CreateTable(
                name: "Solicitudes",
                schema: "administrativa",
                columns: table => new
                {
                    SolicitudId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UniversidadId = table.Column<int>(type: "integer", nullable: false),
                    TipoSolicitud = table.Column<string>(type: "text", nullable: true),
                    EstadoSolicitud = table.Column<string>(type: "text", nullable: true),
                    Descripcion = table.Column<string>(type: "text", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ColaboradorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitudes", x => x.SolicitudId);
                });

            migrationBuilder.CreateTable(
                name: "Universidades",
                schema: "administrativa",
                columns: table => new
                {
                    UniversidadId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true),
                    Direccion = table.Column<string>(type: "text", nullable: true),
                    Telefono = table.Column<string>(type: "text", nullable: true),
                    Correo = table.Column<string>(type: "text", nullable: true),
                    Estado = table.Column<bool>(type: "boolean", nullable: false),
                    Nit = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universidades", x => x.UniversidadId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asignaciones",
                schema: "administrativa");

            migrationBuilder.DropTable(
                name: "Colaboradores",
                schema: "administrativa");

            migrationBuilder.DropTable(
                name: "ConfiguracionesUniversidad",
                schema: "administrativa");

            migrationBuilder.DropTable(
                name: "HistorialSolicitudes",
                schema: "administrativa");

            migrationBuilder.DropTable(
                name: "Solicitudes",
                schema: "administrativa");

            migrationBuilder.DropTable(
                name: "Universidades",
                schema: "administrativa");
        }
    }
}
