using System.ComponentModel.DataAnnotations;

namespace PediGuard.Models
{
    public class Assistant
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the assistant's full name.")]
        [Display(Name = "Full Name")]
        [StringLength(100, ErrorMessage = "The full name cannot exceed 100 characters.")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter the phone number.")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(15, ErrorMessage = "The phone number cannot exceed 15 characters.")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter the email.")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter the address.")]
        [Display(Name = "Address")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select the gender.")]
        [Display(Name = "Gender")]
        public string Gender { get; set; } = string.Empty; 
    }
}
