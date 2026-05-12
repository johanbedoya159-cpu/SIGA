using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ms_academico_siga;

namespace SIGAPrincipal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HorariosController : ControllerBase
    {
        // CONSULTAR HORARIOS
        [HttpGet]
        [Authorize(Roles = RolesSistema.ComunidadAcademica)]
        public IActionResult ObtenerHorarios()
        {
            return Ok("Horarios");
        }

        // CREAR HORARIO
        [HttpPost]
        [Authorize(Policy = "AdministrativosAcademicos")]
        public IActionResult CrearHorario()
        {
            return Ok("Horario creado");
        }
    }
}