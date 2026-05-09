using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SIGAPrincipal.Controllers
{
    [ApiController]
    [Route("api/test")]
    public class TestController : ControllerBase
    {
        
        [Authorize(Roles = "Estudiante")]
        [HttpGet("estudiante")]
        public IActionResult Estudiante()
        {
            return Ok("Hola estudiante 👨‍🎓");
        }

        [Authorize(Roles = "Docente")]
        [HttpGet("docente")]
        public IActionResult Docente()
        {
            return Ok("Hola docente 👨‍🏫");
        }

        
        [Authorize]
        [HttpGet("general")]
        public IActionResult General()
        {
            return Ok("Acceso con token válido");
        }
    }
}