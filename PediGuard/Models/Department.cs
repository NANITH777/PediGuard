using NuGet.DependencyResolver;
using System.ComponentModel.DataAnnotations;

namespace PediGuard.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Department name is required")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Number of Beds")]
        public int NumberOfBeds { get; set; } 

        [Display(Name = "Current Capacity")]
        public int CurrentCapacity { get; set; } // Available beds in the department

        [Required]
        [Display(Name = "Responsible Doctor")]
        public int ResponsibleDoctorId { get; set; }
    }
}
