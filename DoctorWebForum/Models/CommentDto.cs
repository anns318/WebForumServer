namespace DoctorWebForum.Models
{
    public class CommentDto
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string comment { get; set; }
    }
}
