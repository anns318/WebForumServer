using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoctorWebForum.Data;
using Microsoft.AspNetCore.Authorization;
using System.Drawing;
using Microsoft.Extensions.Hosting;
using System.Drawing.Imaging;
using DoctorWebForum.Models;
using System.Data;
using DoctorWebForum.Services;

namespace DoctorWebForum.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IJwtService _jwtService;
        public UsersController(ApplicationDbContext context,IJwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
        [HttpGet("profile/{username}")]
        public async Task<ActionResult<User>> GetUserProfileByUsername(string username)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.Include(x => x.UserDetails).FirstOrDefaultAsync(x => x.UserName == username);
           
            if (user == null)
            {
                return NotFound();
            }
            user.HashedPassword = null;
            if (string.IsNullOrEmpty(user.avatarPath))
            {
                user.avatarPath = "/images/users/0.png";
            }
            return user;
        }
        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost("avatar/{id}")]
        public async Task<ActionResult> PutUserAvatar(int id, UserAvatarDTO userAvatarDTO)
        {
            if(id != userAvatarDTO.UserId)
            {
                return BadRequest();
            }
            try
            {
                var user = await _context.Users.Include(x => x.Role).FirstOrDefaultAsync(x=>x.Id == id);

                if (user == null)
                {
                    return NotFound();
                }

                var spilitBase64 = userAvatarDTO.base64Image.Split(",");

                byte[] bytes = Convert.FromBase64String(spilitBase64[1]);
                Image image;

                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    ms.Seek(0, SeekOrigin.Begin);

                    image = Image.FromStream(ms);


                    ImageFormat imageFormat = ImageFormat.Jpeg;
                    if (image.RawFormat.Equals(ImageFormat.Png))
                    {
                        imageFormat = ImageFormat.Png;
                    }


                    string imageFileName = id + "." + imageFormat.ToString();
                    string imagePath = Path.Combine("wwwroot/images/users", imageFileName);
                    string imageUrlPath = "/images/users/" + imageFileName;

                    image.Save(imagePath, imageFormat);


                    user.avatarPath = imageUrlPath;
                    _context.Entry(user).State = EntityState.Modified;

                }
                await _context.SaveChangesAsync();

                var token = _jwtService.CreateToken(user, user.Role.RoleName);
                dynamic tokenObject = new System.Dynamic.ExpandoObject();
                tokenObject.jwt = token;
                return Ok(tokenObject);

            }
            catch (Exception)
            {
                return BadRequest();

            }

            
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Users'  is null.");
            }

            if (_context.Users.Any(x => x.UserName == user.UserName))
            {
                return BadRequest("Username is exits!");
            }
            if (_context.Users.Any(x => x.Email == user.Email))
            {
                return BadRequest("Email is exits!");
            }
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
