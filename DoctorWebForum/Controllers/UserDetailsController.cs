using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoctorWebForum.Data;
using DoctorWebForum.Models;

namespace DoctorWebForum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/UserDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDetail>>> GetUserDetails()
        {
          if (_context.UserDetails == null)
          {
              return NotFound();
          }
            return await _context.UserDetails.ToListAsync();
        }

        // GET: api/UserDetails/5
        [HttpGet("{userId}")]
        public async Task<ActionResult<UserDetail>> GetUserDetail(int userId)
        {
          if (_context.UserDetails == null)
          {
              return NotFound();
          }
            var userDetail = await _context.UserDetails.FirstOrDefaultAsync(x => x.UserId == userId);

            if (userDetail == null)
            {
                var newUserDetail = new UserDetail { UserId = userId };
                _context.UserDetails.Add(newUserDetail);
                _context.SaveChanges();

                return newUserDetail;
            }

            return userDetail;
        }

        // PUT: api/UserDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{userId}")]
        public async Task<IActionResult> PutUserDetail(int userId, UserDetailDTO userDetailDto)
        {

            var userDetail = await _context.UserDetails.FirstOrDefaultAsync(x => x.UserId == userId);

            if (userDetail == null)
            {
                var newUserDetail = new UserDetail { UserId = userId, WorkAt = userDetailDto.WorkAt,
                    LiveAt = userDetailDto.LiveAt,
                    StudyAt = userDetailDto.StudyAt,
                    From = userDetailDto.From
            };
                
                _context.UserDetails.Add(newUserDetail);
                _context.SaveChanges();

            }

            userDetail.WorkAt = userDetailDto.WorkAt;
            userDetail.LiveAt = userDetailDto.LiveAt;
            userDetail.StudyAt = userDetailDto.StudyAt;
            userDetail.From = userDetailDto.From;

            _context.Entry(userDetail).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return NoContent();

        }

        [HttpPut("intro/{userId}")]
        public async Task<IActionResult> PutUserDetailIntro(int userId, UserDetailDTO userDetailDto)
        {


            var userDetail = await _context.UserDetails.FirstOrDefaultAsync(x => x.UserId == userId);

            userDetail.Intro = userDetailDto.Intro;
            _context.Entry(userDetail).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/UserDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserDetail>> PostUserDetail(UserDetail userDetail)
        {
          if (_context.UserDetails == null)
          {
              return Problem("Entity set 'ApplicationDbContext.UserDetails'  is null.");
          }
            _context.UserDetails.Add(userDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserDetail", new { id = userDetail.Id }, userDetail);
        }

        // DELETE: api/UserDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserDetail(int id)
        {
            if (_context.UserDetails == null)
            {
                return NotFound();
            }
            var userDetail = await _context.UserDetails.FindAsync(id);
            if (userDetail == null)
            {
                return NotFound();
            }

            _context.UserDetails.Remove(userDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserDetailExists(int id)
        {
            return (_context.UserDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
