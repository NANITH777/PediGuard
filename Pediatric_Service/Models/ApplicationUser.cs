using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pediatric_Service.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? StressAdress { get; set; }
        public string? Gender { get; set; }
        [NotMapped]
        public string Role { get; set; }
    }
}
