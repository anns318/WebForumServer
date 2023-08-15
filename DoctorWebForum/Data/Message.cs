using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoctorWebForum.Data
{
    public class Message : BaseEntity
    {
        [ForeignKey("FromUser")]
        public User FUser { get; set; }
        [Required]
        public int FromUser { get; set; }

        [ForeignKey("ToUser")]
        public User TUser { get; set; }
        [Required]
        public int ToUser { get; set; }

        [Required]
        public string Messages { get; set; }

    }
}
