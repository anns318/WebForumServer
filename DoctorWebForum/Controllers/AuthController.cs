using AutoMapper;
using Azure.Core;
using DoctorWebForum.Data;
using DoctorWebForum.Models;
using Microsoft.AspNetCore.Cors;
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
        public async Task<ActionResult> Login(UserVM User)
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
            dynamic tokenObject = new System.Dynamic.ExpandoObject();
            tokenObject.jwt = token;
            return Ok(tokenObject);
        }

        [HttpPost]
        [Route("Register")]

        public async Task<ActionResult<User>> Register(RegisterDto user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            if (_context.Users.Any(x => x.UserName == user.Username))
            {
                return BadRequest(new {message = "Username is exits!" });
            }
            if (_context.Users.Any(x => x.Email == user.Email))
            {
                return BadRequest(new { message = "Email is exits!" });
            }
            var hashPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.Password = hashPassword;
            User user1 = new User { UserName = user.Username, Email = user.Email,HashedPassword = user.Password,FirstName = user.FirstName,LastName = user.LastName,RoleId = user.RoleId };
            _context.Users.Add(user1);

            await _context.SaveChangesAsync();

            return Ok(user);
        }

        private string CreateToken(User user,string role)
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


public class TokenVM {
    public string JWT { get; set; }
}