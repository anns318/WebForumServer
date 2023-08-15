using DoctorWebForum.Data;

namespace DoctorWebForum.Models
{
    public class PostVM : Post
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserAvatar { get; set; } 

    }
}
