using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace ms_autenticacion_siga
{
    public class JwtServiceAutenticacion
    {
        private readonly IConfiguration _config;

        public JwtServiceAutenticacion(IConfiguration config)
        {
            _config = config;
        }

        /// <summary>
        /// Genera un JWT con claims de correo, rol y userId.
        /// </summary>
        public string GenerateToken(int usuarioId, string correo, string rol)
        {
            var jwt = _config.GetSection("Jwt");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt["Key"]!));

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, correo),
                new Claim(ClaimTypes.Name, correo),
                new Claim(ClaimTypes.Role, rol),
                new Claim("uid", usuarioId.ToString())   // para que los otros ms puedan identificar al usuario
            };

            var token = new JwtSecurityToken(
                issuer: jwt["Issuer"],
                audience: jwt["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(double.Parse(jwt["DurationInMinutes"]!)),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}