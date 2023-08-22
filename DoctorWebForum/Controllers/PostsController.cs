using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoctorWebForum.Data;
using DoctorWebForum.Models;
using System.Drawing;
using System.Drawing.Imaging;
using System.Dynamic;

namespace DoctorWebForum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PostsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Posts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostVM>>> GetPosts()
        {
            if (_context.Posts == null)
            {
                return NotFound();
            }
            return await _context.Posts.Include(p => p.User).Include(p => p.Comments)
                .Select(p => new PostVM
                {
                    Id = p.Id,
                    Title = p.Title,
                    ImageUrl = p.ImageUrl,
                    Username = p.User.UserName,
                    FirstName = p.User.FirstName,
                    LastName = p.User.LastName,
                    UserAvatar = p.User.avatarPath,
                    CreateDate = p.CreateDate,
                    Comments = p.Comments
                }
            ).OrderByDescending(p => p.CreateDate).ToListAsync();
        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostVM>> GetPost(int id)
        {
            if (_context.Posts == null)
            {
                return NotFound();
            }
            var post = await _context.Posts.Include(p => p.User).Select(p => new PostVM
            {
                Id = p.Id,
                Title = p.Title,
                ImageUrl = p.ImageUrl,
                Username = p.User.UserName,
                FirstName = p.User.FirstName,
                LastName = p.User.LastName,
                UserAvatar = p.User.avatarPath == null ? "/images/users/0.png" : p.User.avatarPath,
                CreateDate = p.CreateDate
            }).FirstOrDefaultAsync(p => p.Id == id);

            if (post == null)
            {
                return NotFound();
            }

            return post;
        }

        [HttpGet("comment/{id}")]
        public async Task<ActionResult<IEnumerable<CommentVM>>> GetCommentByPost(int id)
        {
            if (_context.Posts == null)
            {
                return NotFound();
            }
            var listComment = await _context.Comments.Include(c => c.User).Include(c => c.Post).Where(p=>p.PostId == id)
            .Select(cp => new CommentVM
            {
                PostId = cp.PostId,
                UserId = cp.User.Id,
                UserName = cp.User.UserName,
                UserAvatarPath = cp.User.avatarPath == null ? "/images/users/0.png" : cp.User.avatarPath,
                UserFirstName = cp.User.FirstName,
                UserLastName = cp.User.LastName,
                Comment = cp.comment,
                CommentCreateDate = cp.CreateDate
            }).ToListAsync();

            return listComment;
        }


        // PUT: api/Posts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost(int id, Post post)
        {
            if (id != post.Id)
            {
                return BadRequest();
            }

            _context.Entry(post).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
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

        // POST: api/Posts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Post>> PostPost(Post post)
        {
            if (_context.Posts == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Posts'  is null.");
            }



            var imageUrl = post.ImageUrl?.Split(",");
         

            post.ImageUrl = null;
            post.CreateDate = DateTime.Now;
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            if (imageUrl != null)
            {
                byte[] bytes  = Convert.FromBase64String(imageUrl[1]);
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

                    
                    string imageFileName = post.Id + "." + imageFormat.ToString();
                    string imagePath = Path.Combine("wwwroot/images/posts", imageFileName);
                    string imageUrlPath = "/images/posts/" + imageFileName;

                    image.Save(imagePath, imageFormat);

                    
                    post.ImageUrl = imageUrlPath;

                    
                    await _context.SaveChangesAsync();
                }
            }
           

         

            var postVM = await _context.Posts.Include(p => p.User).Include(p=>p.Comments).Select(p => new PostVM
            {
                Id = p.Id,
                Title = p.Title,
                ImageUrl = p.ImageUrl,
                Username = p.User.UserName,
                FirstName = p.User.FirstName,
                LastName = p.User.LastName,
                UserAvatar = p.User.avatarPath,
                CreateDate = p.CreateDate,
                Comments = p.Comments
            }).FirstOrDefaultAsync(p => p.Id == post.Id);

            return CreatedAtAction(nameof(GetPost), new { id = post.Id }, postVM);
        }

   
        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            if (_context.Posts == null)
            {
                return NotFound();
            }
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PostExists(int id)
        {
            return (_context.Posts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
