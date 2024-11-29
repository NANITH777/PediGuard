using PediGuard.Models.ViewModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace PediGuard.Models
{
    //public class Appointment
    //{
    //    [Key]
    //    public int Id { get; set; }

    //    [Required]
    //    public DateTime StartTime { get; set; }

    //    [Required]
    //    public DateTime EndTime { get; set; }

    //    [Required]
    //    [StringLength(100)]
    //    public string Description { get; set; }

    //    [Required]
    //    [StringLength(100)]
    //    public string Location { get; set; }

    //    public ApplicationUser ApplicationUser { get; set; }
    //    [ForeignKey("ApplicationUserId")]
    //    [ValidateNever]
    //    public string ApplicationUserId { get; set; }

    //    [Required]
    //    public int AssistantId { get; set; }

    //    [ForeignKey("AssistantId")]
    //    public Assistant Assistant { get; set; }

    //    [Required]
    //    public int DepartmentId { get; set; }

    //    [ForeignKey("DepartmentId")]
    //    public Department Department { get; set; }
    //}

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
