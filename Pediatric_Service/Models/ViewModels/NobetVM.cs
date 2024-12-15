using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Pediatric_Service.Models.ViewModels
{
    public class NobetVM
    {
        public Nobet Nobet { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> DoctorList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> DepartmentList { get; set; }
    }
}
