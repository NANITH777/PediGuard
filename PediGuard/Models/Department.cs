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
        [Range(1, 50, ErrorMessage = "Capacity must be between 0 and 50")]
        [Display(Name = "Number of Beds")]
        public int NumberOfBeds { get; set; }

        [Range(1, 50, ErrorMessage ="Capacity must be between 0 and 50")]
        [Display(Name = "Current Capacity")]
        public int CurrentCapacity { get; set; } // Available beds in the department

        [Required]
        [MaxLength(40)]
        [Display(Name = "Responsible Doctor")]
        public string ResponsibleDoctorName { get; set; }
    }
}
