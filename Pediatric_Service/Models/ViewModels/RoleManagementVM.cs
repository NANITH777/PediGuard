using Microsoft.AspNetCore.Mvc.Rendering;

namespace Pediatric_Service.Models.ViewModels
{
    public class RoleManagementVM
    {
        public ApplicationUser ApplicationUser { get; set; }
        public IEnumerable<SelectListItem> RoleList { get; set; }
    }
}
