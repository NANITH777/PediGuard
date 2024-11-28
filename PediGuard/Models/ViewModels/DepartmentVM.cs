using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PediGuard.Models.ViewModels
{
    public class DepartmentVM
    {
        public Department Department { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> DoctorList { get; set; }
    }
}
