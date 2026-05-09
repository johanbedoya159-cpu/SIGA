using Microsoft.AspNetCore.Mvc;
using SIGAPrincipal.BDAutenticacion;

namespace SIGAPrincipal.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly DataAutenticacion _context;
        private readonly JwtServiceAutenticacion _jwtService;

        public AuthController(DataAutenticacion context, JwtServiceAutenticacion jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel request)
        {
            var usuario = _context.Usuarios
                .FirstOrDefault(u => u.Correo == request.Correo);

            if (usuario == null)
                return Unauthorized("Usuario no existe");

            if (usuario.ContrasenaHash != request.Contrasena)
                return Unauthorized("Contraseña incorrecta");

            var roles = (from ur in _context.UsuarioRoles
                         join r in _context.Roles on ur.RolId equals r.RolId
                         where ur.UsuarioId == usuario.UsuarioId
                         select r.Nombre).ToList();

            if (roles.Count == 0)
                return Unauthorized("Usuario sin roles");

            
            if (roles.Count > 1)
            {
                return Ok(new
                {
                    requiereSeleccionRol = true,
                    roles = roles
                });
            }

            var token = _jwtService.GenerateToken(usuario.Correo, roles.First());

            return Ok(new { token });
        }

        [HttpPost("seleccionar-rol")]
        public IActionResult SeleccionarRol([FromBody] SeleccionRolModel request)
        {
            var token = _jwtService.GenerateToken(request.Correo, request.Rol);

            return Ok(new { token });
        }
    }

    public class LoginModel
    {
        public string Correo { get; set; }
        public string Contrasena { get; set; }
    }

    public class SeleccionRolModel
    {
        public string Correo { get; set; }
        public string Rol { get; set; }
    }
}
