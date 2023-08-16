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
        public DbSet<Comment> Comments{ get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new Role {Id=1, RoleName = "Admin" }, new Role {Id=2,RoleName = "Doctor"},new Role {Id = 3, RoleName= "User"});
            var hashPassword = BCrypt.Net.BCrypt.HashPassword("admin");
            modelBuilder.Entity<User>().HasData(new User{Id=1, UserName = "admin", HashedPassword = hashPassword, Email = "admin@gmail.com",CreateDate = DateTime.Now, RoleId = 1, FirstName= "Toan", LastName="Le Nguyen"  });
            modelBuilder.Entity<Comment>()
          .HasOne(c => c.Post)
          .WithMany(p => p.Comments)
          .HasForeignKey(c => c.PostId)
          .OnDelete(DeleteBehavior.ClientSetNull); // Or use DeleteBehavior.Cascade if needed

            modelBuilder.Entity<Post>()
                .HasOne(p => p.User)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull); // Or use DeleteBehavior.Cascade if needed

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull); // Or use DeleteBehavior.Cascade if needed
            modelBuilder.Entity<Message>()
                .HasOne(m => m.User)
                .WithMany(m => m.messages)
                .HasForeignKey(m => m.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
