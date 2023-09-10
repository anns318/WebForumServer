using DoctorWebForum.Data;
using Microsoft.AspNetCore.SignalR;

namespace DoctorWebForum.SignalRHub
{
    public class ChatHub : Hub
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ApplicationDbContext _context;
        public ChatHub(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
            _context = _contextAccessor.HttpContext.RequestServices.GetRequiredService<ApplicationDbContext>();
        }

        //private ApplicationDbContext GetDbContext()
        //{
        //    return _contextAccessor.HttpContext.RequestServices.GetRequiredService<ApplicationDbContext>();
        //}

        public async Task SendMessage(string userId,string user, string message)
        {
            //var context = GetDbContext();
            await _context.Messages.AddAsync(new Message { UserId = int.Parse(userId), Messages = message });
            await _context.SaveChangesAsync();
            
            await Clients.All.SendAsync("ReceiveMessage", userId, user, message);
        }
    }
}
