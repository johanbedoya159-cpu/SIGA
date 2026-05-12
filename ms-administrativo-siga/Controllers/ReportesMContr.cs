using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ms_administrativo_siga.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportesMContr : ControllerBase
    {
        // REPORTES ACADÉMICOS
        [HttpGet("academicos")]
        [Authorize(Policy = "AdministrativosAcademicos")]
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