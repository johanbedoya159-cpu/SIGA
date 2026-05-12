using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ms_administrativo_siga.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Policy = "AdministrativosAcademicos")]
    public class PeriodoAcController : ControllerBase
    {
        // CONSULTAR PERIODOS
        [HttpGet]
        public IActionResult ObtenerPeriodos()
        {
            return Ok(new
            {
                mensaje = "Lista de períodos académicos"
            });
        }

        // CREAR PERIODO
        [HttpPost]
        public IActionResult CrearPeriodo()
        {
            return Ok(new
            {
                mensaje = "Período creado correctamente"
            });
        }

        // ACTIVAR PERIODO
        [HttpPut("activar/{id}")]
        public IActionResult ActivarPeriodo(int id)
        {
            return Ok(new
            {
                mensaje = $"Período {id} activado"
            });
        }

        // CERRAR PERIODO
        [HttpPut("cerrar/{id}")]
        public IActionResult CerrarPeriodo(int id)
        {
            return Ok(new
            {
                mensaje = $"Período {id} cerrado"
            });
        }
    }
}