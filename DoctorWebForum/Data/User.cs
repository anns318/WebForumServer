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
        [ForeignKey("RoleId")]        
        public Role? Role { get; set; }
        public int RoleId { get; set; }
        
        

    }

}