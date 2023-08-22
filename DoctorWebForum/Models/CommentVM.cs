namespace DoctorWebForum.Models
{
    public class CommentVM
    {
        public int PostId { get;  set; }
        public int UserId { get;  set; }
        public string? UserName { get;  set; }
        public string? UserAvatarPath { get; set; } 
        public string? UserFirstName { get;  set; }
        public string? UserLastName { get;  set; }
        public string Comment { get;  set; }
        public DateTime CommentCreateDate { get;  set; }
    }
}
