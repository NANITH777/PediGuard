using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Pediatric_Service.Models
{
    public class Nobet
    {
        [Key]
        public int ID { get; set; }

        public int DoctorID { get; set; }

        [ForeignKey(nameof(DoctorID))]
        [Display(Name = "Doctor")]
        [ValidateNever]
        public Doctor Doctor { get; set; }

        public int DepartmentID { get; set; }

        [ForeignKey(nameof(DepartmentID))]
        [Display(Name = "Department")]
        [ValidateNever]
        public Department Department { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "End Time")]
        public DateTime EndTime { get; set; }

        [ValidateNever]
        public ICollection<Appointment> Appointments { get; set; }
    }
}
