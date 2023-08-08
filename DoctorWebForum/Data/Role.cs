using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DoctorWebForum.Data
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string? RoleName { get; set; }

    }
}
