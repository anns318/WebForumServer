using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoctorWebForum.Data
{
    public class Post : BaseEntity
    {
        [Required]
        public string? Title { get; set; }
        public string? ImageUrl { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }
        public int UserId { get; set; }
        public bool isHidden { get; set; } = false;
        public ICollection<Comment>? Comments { get; set; }
    }
}