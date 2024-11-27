using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PediGuard.Models
{
    public class Emergency
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [Display(Name = "Description")]
        [MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Location is required")]
        [Display(Name = "Location")]
        [MaxLength(200, ErrorMessage = "Location cannot exceed 200 characters")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Status is required")]
        [Display(Name = "Status")]
        [MaxLength(100, ErrorMessage = "Status cannot exceed 100 characters")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Department is required")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        [ValidateNever]
        public Department Department { get; set; }

        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Display(Name = "Updated At")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
