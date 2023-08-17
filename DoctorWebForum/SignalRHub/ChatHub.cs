using DoctorWebForum.Data;
using Microsoft.AspNetCore.SignalR;

namespace DoctorWebForum.SignalRHub
{
    public class ChatHub : Hub
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public ChatHub(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        private ApplicationDbContext GetDbContext()
        {
            return _contextAccessor.HttpContext.RequestServices.GetRequiredService<ApplicationDbContext>();
        }

        public async Task SendMessage(string userId,string user, string message)
        {
            using (var context = GetDbContext())
            {
                await context.Messages.AddAsync(new Message { UserId = int.Parse(userId), Messages = message });
                await context.SaveChangesAsync();
            }
            await Clients.All.SendAsync("ReceiveMessage", userId, user, message);
        }
    }
}
