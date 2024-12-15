using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Pediatric_Service.Models.ViewModels
{
    public class AssistantNobetVM
    {
        public AssistantNobet AssistantNobet { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> AssistantList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> DepartmentList { get; set; }
    }
}
