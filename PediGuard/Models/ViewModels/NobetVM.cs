using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PediGuard.Models.ViewModels
{
    public class NobetVM
    {
        public Nobet Nobet { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> AssistantList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> DepartmentList { get; set; }
    }
}
