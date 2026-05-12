using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ms_administrativo_siga.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Policy = "AdministrativosAcademicos")]
    public class ProgramasController : ControllerBase
    {
        // CONSULTAR PROGRAMAS
        [HttpGet]
        public IActionResult ObtenerProgramas()
        {
            return Ok(new
            {
                mensaje = "Lista de programas"
            });
        }

        // CREAR PROGRAMA
        [HttpPost]
        public IActionResult CrearPrograma()
        {
            return Ok(new
            {
                mensaje = "Programa creado correctamente"
            });
        }

        // MODIFICAR PROGRAMA
        [HttpPut("{id}")]
        public IActionResult EditarPrograma(int id)
        {
            return Ok(new
            {
                mensaje = $"Programa {id} editado"
            });
        }

        // DESACTIVAR PROGRAMA
        [HttpDelete("{id}")]
        public IActionResult DesactivarPrograma(int id)
        {
            return Ok(new
            {
                mensaje = $"Programa {id} desactivado"
            });
        }
    }
}