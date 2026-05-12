using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

<<<<<<< HEAD
namespace ms_academico_siga
=======
namespace SIGAPrincipal
>>>>>>> c80eabf6817f70b31baafaa58ab5833a2c24b543
{
    public class JwtServiceAcademico
    {
        private readonly IConfiguration _config;

        public JwtServiceAcademico(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateToken(string correo, string rol)
        {
            var jwt = _config.GetSection("Jwt");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt["Key"]));

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, correo),
                new Claim(ClaimTypes.Role, rol)
            };

            var token = new JwtSecurityToken(
                issuer: jwt["Issuer"],
                audience: jwt["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(double.Parse(jwt["DurationInMinutes"])),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}