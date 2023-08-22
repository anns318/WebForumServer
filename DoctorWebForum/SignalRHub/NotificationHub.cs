using DoctorWebForum.Data;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace DoctorWebForum.SignalRHub
{
    public class NotificationHub : Hub
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public NotificationHub(IHttpContextAccessor contextAccessor)
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
            return base.OnConnectedAsync();
        }
        public async Task SendNotification(string postId, string userId,string userFullname,string userAvatar, string notification, string datetime)
        {
            string userToNotify;
            var context = GetDbContext();
            
            var post = await context.Posts.FindAsync(Int32.Parse(postId));
            userToNotify = post.UserId.ToString();
            var notificationModel = new Notification(int.Parse(userToNotify), int.Parse(userId), int.Parse(postId), notification);
            context.Notifications.Add(notificationModel);
            await context.SaveChangesAsync();
            if (userId == userToNotify)
            {
                return;
            }

            var htmlNotification = "<img src='" + userAvatar + "' alt='" + userId + "'> <div class='notification-content'> <h3>" + userFullname + " comment on your post</h3> <p id='notificationTime'>Just Now</p> </div>";

            await Clients.Groups(userToNotify).SendAsync("HaveNewNotification", postId, htmlNotification);
        }
    }
}
