using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DoctorWebForum.Data
{
    public class Notification : BaseEntity
    {
        public Notification(int userId,int fromUserId ,int postId, string notificationContent)
        {
            UserId = userId;
            FromUserId = fromUserId;
            PostId = postId;
            NotificationContent = notificationContent;
        }

        [ForeignKey("UserId")]
        public User User { get; set; }
        public int UserId { get; set; }
        [ForeignKey("FromUserId")]
        [JsonIgnore]
        public User FromUser { get; set; }
        public int FromUserId { get; set; }
        [ForeignKey("PostId")]
        public Post Post { get; set; }
        public int PostId { get; set; }
        [Required]
        public string NotificationContent { get; set; }
    }
}
