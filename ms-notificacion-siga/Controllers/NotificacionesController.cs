using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SIGAPrincipal.Controllers
{
    /// <summary>
    /// Notificaciones del sistema.
    ///
    /// Permisos:
    ///   - Ver notificaciones propias → cualquier usuario autenticado
    ///   - Crear notificaciones       → Gestion, Admin-Coordinador, Admin-Secretaria, Decano
    ///   - Eliminar                   → Gestion
    /// </summary>
    [ApiController]
    [Route("api/notificaciones")]
    [Authorize]
    public class NotificacionesController : ControllerBase
    {
        [HttpGet]
        [Authorize(Roles = "Estudiante,Docente,Egresado,Admin-Coordinador,Admin-Secretaria,Decano,Gestion,Apoyo-Gestion")]
        public IActionResult GetAll() => Ok("Listado de notificaciones");

        [HttpPost]
        [Authorize(Roles = "Gestion,Admin-Coordinador,Admin-Secretaria,Decano")]
        public IActionResult Create() => Ok("Notificación creada");

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Gestion")]
        public IActionResult Delete(int id) => Ok($"Notificación {id} eliminada");
    }
}