using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PediGuard.Models
{
    public class ApplicationUser: IdentityUser
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string TCno { get; set; }
        public string? PhoneNumber { get; set; }
        public string? StressAdress { get; set; }
        public string? City { get; set; }
    }
}
