using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SIGAPrincipal.Controllers
{
    /// <summary>
    /// Exportación de reportes.
    ///
    /// Permisos:
    /// - Administrativos → exportaciones académicas
    /// - Gestión → exportaciones globales
    /// </summary>
    [ApiController]
    [Route("api/exportaciones")]
    [Authorize]
    public class ExportacionesController : ControllerBase
    {
        // EXPORTAR REPORTE ACADÉMICO
        [HttpGet("academico")]
        [Authorize(Roles = "Admin-Coordinador,Admin-Secretaria,Decano")]
        public IActionResult ExportarAcademico()
        {
            return Ok(new
            {
                mensaje = "Reporte académico exportado"
            });
        }

        // EXPORTAR REPORTE GLOBAL
        [HttpGet("global")]
        [Authorize(Roles = "Gestion")]
        public IActionResult ExportarGlobal()
        {
            return Ok(new
            {
                mensaje = "Reporte global exportado"
            });
        }
    }
}