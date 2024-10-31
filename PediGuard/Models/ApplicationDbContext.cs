using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PediGuard.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Department> Departments { get; set; }

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
        }



    }


}
