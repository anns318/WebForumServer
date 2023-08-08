using AutoMapper;
using Azure.Core;
using DoctorWebForum.Data;
using DoctorWebForum.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DoctorWebForum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AuthController(ApplicationDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<string>> Login(UserVM User)
        {

            var u = await _context.Users.FirstOrDefaultAsync(x => x.UserName == User.UserName);


            if (u == null)
            {
                return Unauthorized();
            }

            if (!BCrypt.Net.BCrypt.Verify(User.Password, u.HashedPassword))
            {
                return Unauthorized();

            }
            var role = await _context.Roles.FirstOrDefaultAsync(x => x.Id == u.RoleId);

            var token = CreateToken(u,role.RoleName);

            return token;
        }

        [HttpPost]
        [Route("Register")]

        public async Task<ActionResult<User>> Register(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            var hashPassword = BCrypt.Net.BCrypt.HashPassword(user.HashedPassword);
            user.HashedPassword = hashPassword;
            user.CreateDate = DateTime.Now;
            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return user;
        }

        private string CreateToken(User user,string role)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim("username", user.UserName),
                new Claim(ClaimTypes.Role,role),
                new Claim("email",user.Email)
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
