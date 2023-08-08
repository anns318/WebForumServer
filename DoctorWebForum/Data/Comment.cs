using System.ComponentModel.DataAnnotations.Schema;

namespace DoctorWebForum.Data
{
    public class Comment :BaseEntity
    {
        public string comment { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }
        public int UserId { get; set; }
    }
}
