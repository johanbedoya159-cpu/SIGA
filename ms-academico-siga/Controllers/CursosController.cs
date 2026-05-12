using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ms_academico_siga;

namespace SIGAPrincipal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CursosController : ControllerBase
    {
        // CONSULTAR CURSOS
        [HttpGet]
        [Authorize(Roles = RolesSistema.ComunidadAcademica)]
        public IActionResult ObtenerCursos()
        {
            return Ok("Lista de cursos");
        }

        // CREAR CURSO
        [HttpPost]
        [Authorize(Policy = "AdministrativosAcademicos")]
        public IActionResult CrearCurso()
        {
            return Ok("Curso creado");
        }

        // EDITAR CURSO
        [HttpPut]
        [Authorize(Policy = "AdministrativosAcademicos")]
        public IActionResult EditarCurso()
        {
            return Ok("Curso editado");
        }

        // ELIMINAR CURSO
        [HttpDelete]
        [Authorize(Policy = "AdministrativosAcademicos")]
        public IActionResult EliminarCurso()
        {
            return Ok("Curso eliminado");
        }
    }
}