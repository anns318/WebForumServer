using System.ComponentModel.DataAnnotations;

namespace DoctorWebForum.Data
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
