using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SIGAPrincipal.Controllers
{
    /// <summary>
    /// Reportes del sistema.
    ///
    /// Permisos:
    /// - Estudiantes → historial propio
    /// - Docentes → reportes de cursos
    /// - Administrativos → reportes académicos
    /// - Gestión → reportes globales
    /// </summary>
    [ApiController]
    [Route("api/reportes")]
    [Authorize]
    public class reportesController : ControllerBase
    {
        // REPORTE PERSONAL DEL ESTUDIANTE
        [HttpGet("historial")]
        [Authorize(Roles = "Estudiante,Egresado")]
        public IActionResult Historial()
        {
            return Ok(new
            {
                mensaje = "Historial académico"
            });
        }

        // REPORTES DOCENTE
        [HttpGet("docente")]
        [Authorize(Roles = "Docente")]
        public IActionResult ReporteDocente()
        {
            return Ok(new
            {
                mensaje = "Reporte docente"
            });
        }

        // REPORTES ACADÉMICOS
        [HttpGet("academicos")]
        [Authorize(Roles = "Admin-Coordinador,Admin-Secretaria,Decano")]
        public IActionResult ReportesAcademicos()
        {
            return Ok(new
            {
                mensaje = "Reportes académicos"
            });
        }

        // REPORTES GLOBALES
        [HttpGet("globales")]
        [Authorize(Roles = "Gestion")]
        public IActionResult ReportesGlobales()
        {
            return Ok(new
            {
                mensaje = "Reportes globales"
            });
        }
    }
}