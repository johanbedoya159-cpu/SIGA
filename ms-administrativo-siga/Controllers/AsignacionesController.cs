using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ms_administrativo_siga.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Policy = "AdministrativosAcademicos")]
    public class AsignacionesController : ControllerBase
    {
        // ASIGNAR DOCENTES
        [HttpPost("docente")]
        public IActionResult AsignarDocente()
        {
            return Ok(new
            {
                mensaje = "Docente asignado correctamente"
            });
        }

        // ASIGNAR GRUPOS
        [HttpPost("grupo")]
        public IActionResult AsignarGrupo()
        {
            return Ok(new
            {
                mensaje = "Grupo asignado correctamente"
            });
        }

        // CONSULTAR ASIGNACIONES
        [HttpGet]
        public IActionResult ObtenerAsignaciones()
        {
            return Ok(new
            {
                mensaje = "Lista de asignaciones"
            });
        }
    }
}