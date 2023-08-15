using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoctorWebForum.Data;
using DoctorWebForum.Models;
using System.Dynamic;
using AutoMapper;

namespace DoctorWebForum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MessagesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Messages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Message>>> GetMessages()
        {
          if (_context.Messages == null)
          {
              return NotFound();
          }
            return await _context.Messages.ToListAsync();
        }

        // GET: api/Messages/5
        [HttpGet("{user1Id}/{user2Id}")]
        public async Task<ActionResult<MessageVM>> GetMessage(int user1Id,int user2Id)
        {
          if (_context.Messages == null)
          {
              return NotFound();
          }

            var message = await _context.Messages.Where(m =>
                (m.FromUser == user1Id && m.ToUser == user2Id) ||
                (m.ToUser == user1Id && m.FromUser == user2Id)).OrderBy(m => m.CreateDate).Select(m=> new message { Messages = m.Messages,CreatedDate = m.CreateDate}).ToListAsync();

            var user1 = await _context.Users.FindAsync(user1Id);
            var user2 = await _context.Users.FindAsync(user2Id);

            var messageVM = new MessageVM();
            messageVM.User1 = _mapper.Map<UserMessageVm>(user1);
            messageVM.User2 = _mapper.Map<UserMessageVm>(user2);
            messageVM.Messages = message;
            if (message == null)
            {
                return NotFound();
            }

            return messageVM;
        }


        // PUT: api/Messages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMessage(int id, Message message)
        {
            if (id != message.Id)
            {
                return BadRequest();
            }

            _context.Entry(message).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MessageExists(id))
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

        // POST: api/Messages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Message>> PostMessage(Message message)
        {
          if (_context.Messages == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Messages'  is null.");
          }
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMessage", new { id = message.Id }, message);
        }

        // DELETE: api/Messages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            if (_context.Messages == null)
            {
                return NotFound();
            }
            var message = await _context.Messages.FindAsync(id);
            if (message == null)
            {
                return NotFound();
            }

            _context.Messages.Remove(message);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MessageExists(int id)
        {
            return (_context.Messages?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
