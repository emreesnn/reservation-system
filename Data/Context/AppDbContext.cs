using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RandevuYonetimSistemi.Data.Configurations;
using RandevuYonetimSistemi.Helpers;
using RandevuYonetimSistemi.Models;
using System.Reflection;

namespace RandevuYonetimSistemi.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                Name = "Admin User",
                Email = "admin@example.com",
                PasswordHash = PasswordHasher.HashPassword("Admin123"), // Hashlenmiş şifre
                Role = UserRole.Admin
            },
            new User
            {
                Id = 2,
                Name = "Test User",
                Email = "user@example.com",
                PasswordHash = PasswordHasher.HashPassword("User123"),
                Role = UserRole.User
            }
        );

            // Seed Data - Randevular
            modelBuilder.Entity<Appointment>().HasData(
                new Appointment
                {
                    Id = 1,
                    UserId = 2,
                    AppointmentDate = new DateTime(2024, 02, 15, 10, 0, 0), // Sabit tarih
                    Status = AppointmentStatus.Active
                },
                new Appointment
                {
                    Id = 2,
                    UserId = 2,
                    AppointmentDate = new DateTime(2024, 02, 17, 14, 30, 0), // Sabit tarih
                    Status = AppointmentStatus.Cancelled
                }
            );

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
