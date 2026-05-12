using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SIGAPrincipal.Controllers
{
    /// <summary>
    /// Estadísticas generales del sistema.
    ///
    /// Permisos:
    /// - Gestión → estadísticas globales
    /// - Administrativos → estadísticas académicas
    /// </summary>
    [ApiController]
    [Route("api/estadisticas")]
    [Authorize]
    public class EstadisticasController : ControllerBase
    {
        // ESTADÍSTICAS ACADÉMICAS
        [HttpGet("academicas")]
        [Authorize(Roles = "Admin-Coordinador,Admin-Secretaria,Decano")]
        public IActionResult EstadisticasAcademicas()
        {
            return Ok(new
            {
                mensaje = "Estadísticas académicas"
            });
        }

        // ESTADÍSTICAS GLOBALES
        [HttpGet("globales")]
        [Authorize(Roles = "Gestion")]
        public IActionResult EstadisticasGlobales()
        {
            return Ok(new
            {
                mensaje = "Estadísticas globales"
            });
        }
    }
}