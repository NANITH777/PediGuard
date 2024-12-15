using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Pediatric_Service.Models
{
    public class Appointment
    {
        [Key]
        public int ID { get; set; }

        public int NobetID { get; set; }
        [ForeignKey(nameof(NobetID))]
        [Display(Name = "Nobet Shift")]
        [ValidateNever]
        public Nobet Nobet { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public string ApplicationUserId { get; set; }

        //Additional properties to track appointment status
        public AppointmentStatus Status { get; set; }

        // Optional: Additional notes or description
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }

    }

    public enum AppointmentStatus
    {
        Pending,
        Confirmed,
        Cancelled,
        Completed
    }
}
