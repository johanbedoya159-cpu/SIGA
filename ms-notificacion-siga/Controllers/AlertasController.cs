using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SIGAPrincipal.Controllers
{
    /// <summary>
    /// Alertas del sistema.
    /// Solo roles administrativos pueden crearlas; todos las pueden leer.
    /// </summary>
    [ApiController]
    [Route("api/alertas")]
    [Authorize]
    public class AlertasController : ControllerBase
    {
        [HttpGet]
        [Authorize(Roles = "Estudiante,Docente,Egresado,Admin-Coordinador,Admin-Secretaria,Decano,Gestion,Apoyo-Gestion")]
        public IActionResult GetAll() => Ok("Listado de alertas");

        [HttpPost]
        [Authorize(Roles = "Gestion,Admin-Coordinador,Decano")]
        public IActionResult Create() => Ok("Alerta creada");
    }

    /// <summary>
    /// Envío de correos transaccionales.
    /// Solo roles con permisos de comunicación.
    /// </summary>
    [ApiController]
    [Route("api/correo")]
    [Authorize]
    public class CorreoController : ControllerBase
    {
        [HttpPost("enviar")]
        [Authorize(Roles = "Gestion,Admin-Coordinador,Admin-Secretaria,Decano")]
        public IActionResult Enviar() => Ok("Correo enviado");
    }
}