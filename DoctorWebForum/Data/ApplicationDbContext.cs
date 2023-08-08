using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace DoctorWebForum.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) 
        {
            
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> comments{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new Role {Id=1, RoleName = "Admin" }, new Role {Id=2,RoleName = "Doctor"},new Role {Id = 3, RoleName= "User"});
        }
    }
}
