using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Pediatric_Service.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Nobet> Nobets { get; set; }
        public DbSet<AssistantNobet> AssistantNobets { get; set; }
        public DbSet<Assistant> Assistants { get; set; }
        public DbSet<Emergency> Emergencies { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Nobet>()
            .HasOne(n => n.Doctor)
            .WithMany()
            .HasForeignKey(n => n.DoctorID)
            .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Nobet>()
                .HasOne(n => n.Department)
                .WithMany()
                .HasForeignKey(n => n.DepartmentID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    Id = 1,
                    FullName = "Dr. John Smith",
                    PhoneNumber = "123-456-7890",
                    Email = "john.smith@example.com",
                    Address = "123 Main St, Anytown, USA",
                    Gender = "Male"
                },
                new Doctor
                {
                    Id = 2,
                    FullName = "Dr. Jane Doe",
                    PhoneNumber = "098-765-4321",
                    Email = "jane.doe@example.com",
                    Address = "456 Elm St, Othertown, USA",
                    Gender = "Female"
                },
                new Doctor
                {
                    Id = 3,
                    FullName = "Dr. Emily Johnson",
                    PhoneNumber = "555-123-4567",
                    Email = "emily.johnson@example.com",
                    Address = "789 Oak St, Sometown, USA",
                    Gender = "Female"
                }
            );

            // Seed data for Departments
            modelBuilder.Entity<Department>().HasData(
                new Department
                {
                    Id = 1,
                    Name = "Pediatric Emergency",
                    NumberOfBeds = 20,
                    CurrentCapacity = 15,
                    DoctorId = 1 
                },
                new Department
                {
                    Id = 2,
                    Name = "Pediatric Intensive Care",
                    NumberOfBeds = 10,
                    CurrentCapacity = 5,
                    DoctorId = 3 
                },
                new Department
                {
                    Id = 3,
                    Name = "Pediatric Hematology and Oncology",
                    NumberOfBeds = 15,
                    CurrentCapacity = 12,
                    DoctorId = 4 
                }
            );

            // Seed data for Assistants
            modelBuilder.Entity<Assistant>().HasData(
                new Assistant
                {
                    Id = 1,
                    FullName = "John Doe",
                    PhoneNumber = "123-456-7890",
                    Email = "john.doe@example.com",
                    Password = "Password123", 
                    Address = "123 Main St, Anytown, USA",
                    Gender = "Male"
                },
                new Assistant
                {
                    Id = 2,
                    FullName = "Jane Smith",
                    PhoneNumber = "098-765-4321",
                    Email = "jane.smith@example.com",
                    Password = "Password123",
                    Address = "456 Elm St, Othertown, USA",
                    Gender = "Female"
                },
                new Assistant
                {
                    Id = 3,
                    FullName = "Morgan Alex",
                    PhoneNumber = "555-123-4567",
                    Email = "alice.johnson@example.com",
                    Password = "Password123",
                    Address = "789 Oak St, Sometown, USA",
                    Gender = "Female"
                }
            );
        }
    }
}
