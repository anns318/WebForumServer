using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoctorWebForum.Data
{
    public class Message : BaseEntity
    {
        [ForeignKey("UserId")]
        public User User { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Messages { get; set; }

    }
}
