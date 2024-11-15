using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PediGuard.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Assistant> Assistants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Department>().HasData(
                new Department
                {
                    Id = 1,
                    Name = "Pediatric Emergency",
                    NumberOfBeds = 10,
                    CurrentCapacity = 8,
                    ResponsibleDoctorName = "Ahmet Özkan" 
                },
                new Department
                {
                    Id = 2,
                    Name = "Pediatric Intensive Care",
                    NumberOfBeds = 12,
                    CurrentCapacity = 10,
                    ResponsibleDoctorName = "Nani Fulchany" 
                },
                new Department
                {
                    Id = 3,
                    Name = "Pediatric Hematology and Oncology",
                    NumberOfBeds = 15,
                    CurrentCapacity = 13,
                    ResponsibleDoctorName = "Luss Huguette" 
                }
            );

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { 
                    Id = 1, LastName = "Smith", 
                    FirstName = "John", Phone = "123-456-7890", 
                    Email = "john.smith@example.com", 
                    Address = "123 Main St", IsActive = true 
                },
                new Doctor { 
                    Id = 2, LastName = "Doe", 
                    FirstName = "Jane", 
                    Phone = "987-654-3210", 
                    Email = "jane.doe@example.com", 
                    Address = "456 Maple Ave", 
                    IsActive = false 
                },
                new Doctor { 
                    Id = 3, 
                    LastName = "Brown", 
                    FirstName = "Alice", 
                    Phone = "555-555-5555", 
                    Email = "alice.brown@example.com", 
                    Address = "789 Oak Dr", 
                    IsActive = true 
                }
            );

            // Seed data for Assistants
            modelBuilder.Entity<Assistant>().HasData(
                new Assistant
                {
                    Id = 1,
                    FullName = "John Doe",
                    PhoneNumber = "+905340000003",
                    Email = "john.doe@example.com",
                    Address = "123 Main St, City A",
                    Gender = "Male"
                },
                new Assistant
                {
                    Id = 2,
                    FullName = "Jane Smith",
                    PhoneNumber = "+905340000002",
                    Email = "jane.smith@example.com",
                    Address = "456 Elm St, City B",
                    Gender = "Female"
                },
                new Assistant
                {
                    Id = 3,
                    FullName = "Alice Johnson",
                    PhoneNumber = "+905340000001",
                    Email = "alice.johnson@example.com",
                    Address = "789 Oak St, City C",
                    Gender = "Female"
                },
                new Assistant
                {
                    Id = 4,
                    FullName = "Robert Brown",
                    PhoneNumber = "+905340000000",
                    Email = "robert.brown@example.com",
                    Address = "321 Pine St, City D",
                    Gender = "Male"
                }
            );
        }



    }


}
