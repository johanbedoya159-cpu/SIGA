using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ms_autenticacion_siga.Controllers
{
    [ApiController]
    [Route("api/test")]
    public class TestController : ControllerBase
    {
        
        [Authorize(Roles = "Estudiante")]
        [HttpGet("estudiante")]
        public IActionResult Estudiante()
        {
            return Ok("Hola estudiante ");
        }


        [Authorize(Roles = "Docente")]
        [HttpGet("docente")]
        public IActionResult Docente()
        {
            return Ok("Hola docente ");
        }

        
        [Authorize(Roles = "Egresado")]
        [HttpGet("egresado")]
        public IActionResult Egresado()
        {
            return Ok("Hola Egresado");
        }


        [Authorize(Roles = "Gestion")]
        [HttpGet("gestion")]
        public IActionResult Gestion()
        {
            return Ok("Hola Desarrolladores");
        }

        [Authorize(Roles = "Apoyo-Gestion")]
        [HttpGet("apoyo-gestion")]
        public IActionResult ApoyoGestion()
        {
            return Ok("Hola apoyo de gestion");
        }



        [Authorize(Roles = "Admin-Coordinador")]
        [HttpGet("admin-coordinador")]
        public IActionResult General()
        {
            return Ok("Hola Coordinador");
        }

        [Authorize(Roles = "Admin-Secretaria")]
        [HttpGet("admin-secretaria")]
        public IActionResult AdminSecretaria()
        {
            return Ok("Hola Secretaria");
        }


        [Authorize(Roles = "Decano")]
        [HttpGet("decano")]
        public IActionResult Decano()
        {
            return Ok("Hola Decano");
        }



    }
}