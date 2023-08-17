using DoctorWebForum.Data;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace DoctorWebForum.SignalRHub
{
    public class Notification : Hub
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public Notification(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        private ApplicationDbContext GetDbContext()
        {
            return _contextAccessor.HttpContext.RequestServices.GetRequiredService<ApplicationDbContext>();
        }
        public override Task OnConnectedAsync()
        {
            string userId = Context.GetHttpContext().Request.Query["userId"];

            Groups.AddToGroupAsync(Context.ConnectionId, userId);
            Console.WriteLine(Groups);
            return base.OnConnectedAsync();
        }
        public async Task SendNotification(string postId, string notification, string datetime)
        {
            string userToNotify;
            using (var context = GetDbContext())
            {
                var post = await context.Posts.FindAsync(Int32.Parse(postId));
                userToNotify = post.UserId.ToString();
            }
            await Clients.Groups(userToNotify).SendAsync("HaveNewNotification", postId, notification,datetime);
        }
    }
}
