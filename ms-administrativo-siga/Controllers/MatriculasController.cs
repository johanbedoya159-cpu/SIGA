using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ms_administrativo_siga.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Policy = "AdministrativosAcademicos")]
    public class MatriculasController : ControllerBase
    {
        // CONSULTAR MATRÍCULAS
        [HttpGet]
        public IActionResult ObtenerMatriculas()
        {
            return Ok(new
            {
                mensaje = "Lista de matrículas"
            });
        }

        // CREAR MATRÍCULA
        [HttpPost]
        public IActionResult CrearMatricula()
        {
            return Ok(new
            {
                mensaje = "Matrícula creada correctamente"
            });
        }

        // MODIFICAR MATRÍCULA
        [HttpPut("{id}")]
        public IActionResult EditarMatricula(int id)
        {
            return Ok(new
            {
                mensaje = $"Matrícula {id} modificada"
            });
        }

        // CANCELAR MATRÍCULA
        [HttpDelete("{id}")]
        public IActionResult CancelarMatricula(int id)
        {
            return Ok(new
            {
                mensaje = $"Matrícula {id} cancelada"
            });
        }
    }
}