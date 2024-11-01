using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PediGuard.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

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
        }



    }


}
