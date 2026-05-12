using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SIGAPrincipal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InscripcionesController : ControllerBase
    {
        // ESTUDIANTE INSCRIBE
        [HttpPost("inscribir")]
        [Authorize(Roles = "Estudiante")]
        public IActionResult Inscribir()
        {
            return Ok("Materia inscrita");
        }

        // ESTUDIANTE CANCELA
        [HttpDelete("cancelar")]
        [Authorize(Roles = "Estudiante")]
        public IActionResult Cancelar()
        {
            return Ok("Materia cancelada");
        }

        // ADMINISTRATIVOS
        [HttpGet("admin")]
        [Authorize(Policy = "AdministrativosAcademicos")]
        public IActionResult GestionInscripciones()
        {
            return Ok("Gestión administrativa");
        }
    }
}