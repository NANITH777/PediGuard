using Microsoft.AspNetCore.Identity;

namespace PediGuard.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string Name { get; set; }
    }
}
