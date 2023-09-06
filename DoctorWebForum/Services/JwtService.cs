using DoctorWebForum.Data;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DoctorWebForum.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        public string CreateToken(User user, string role)
        {
            List<Claim> claims = new List<Claim> {
                new Claim("userId", user.Id.ToString()),
                new Claim("username", user.UserName),
                new Claim(ClaimTypes.Role,role),
                new Claim("role",role),
                new Claim("email",user.Email),
                new Claim("firstName",user.FirstName),
                new Claim("lastName",user.LastName),
                new Claim("avatar",user.avatarPath ?? "null")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Appsettings:Jwt").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(5),
                signingCredentials: creds

                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
