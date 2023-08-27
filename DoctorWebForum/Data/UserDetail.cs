using System.ComponentModel.DataAnnotations.Schema;

namespace DoctorWebForum.Data
{
    public class UserDetail : BaseEntity
    {
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int UserId { get; set; }
        public string? CoverUrl { get; set; } = string.Empty;
        public string? Intro { get; set; } = string.Empty;
        public string? WorkAt { get; set; } = string.Empty;
        public string? StudyAt { get; set; } = string.Empty;
        public string? LiveAt { get; set; } = string.Empty;
        public string? From { get; set; } = string.Empty;
    }
}
