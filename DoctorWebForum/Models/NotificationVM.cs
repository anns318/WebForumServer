namespace DoctorWebForum.Models
{
    public class NotificationVM
    {
        public int PostId { get; set; }
        public string NotificationContent { get; set; }
        public string FromUserAvatar { get; set; }
        public string FromUserFullName { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
