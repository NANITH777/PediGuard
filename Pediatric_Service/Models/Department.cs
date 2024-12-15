using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pediatric_Service.Models
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

        [Range(1, 50, ErrorMessage = "Capacity must be between 0 and 50")]
        [Display(Name = "Current Capacity")]
        public int CurrentCapacity { get; set; } // Available beds in the department
        public int DoctorId { get; set; }

        [ForeignKey(nameof(DoctorId))]
        [Display(Name = "Doctor Name")]
        [ValidateNever]
        public Doctor Doctor { get; set; }
    }
}
