using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using BCrypt.Net;

namespace LogIn.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<User>()
                .Property(u => u.Id)
                .ValueGeneratedOnAdd(); 

            
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1, 
                    Username = "admin",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("1234"),
                }
            );
        }
    }

    public class User
    {
        public int Id { get; set; } 
        public string? Username { get; set; }
        public string? PasswordHash { get; set; }
    }
}
