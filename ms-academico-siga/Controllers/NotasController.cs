using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SIGAPrincipal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotasController : ControllerBase
    {
        // CONSULTAR NOTAS
        [HttpGet]
        [Authorize(Roles = "Estudiante,Egresado")]
        public IActionResult ConsultarNotas()
        {
            return Ok("Notas");
        }

        // DOCENTE REGISTRA NOTAS
        [HttpPost]
        [Authorize(Roles = "Docente")]
        public IActionResult RegistrarNotas()
        {
            return Ok("Notas registradas");
        }

        // DOCENTE MODIFICA NOTAS
        [HttpPut]
        [Authorize(Roles = "Docente")]
        public IActionResult ModificarNotas()
        {
            return Ok("Notas modificadas");
        }
    }
}