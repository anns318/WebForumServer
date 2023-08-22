using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoctorWebForum.Data
{
    public class User : BaseEntity
    {
        [Required(ErrorMessage ="User name is required")]
        public string? UserName { get; set; }
        [Required]
        public string? HashedPassword { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        public string? avatarPath { get; set; }
        [ForeignKey("RoleId")]        
        public Role? Role { get; set; }
        public int RoleId { get; set; }
        public IEnumerable<Post> Posts { get; set; } = new List<Post>();
        public IEnumerable<Comment> Comments { get; set; } = new List<Comment>();
        public IEnumerable<Message> messages{ get; set; } = new List<Message>();
        public IEnumerable<Notification> Notifications{ get; set; } = new List<Notification>();
    }

}