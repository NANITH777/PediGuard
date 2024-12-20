﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Pediatric_Service.Models.ViewModels
{
    public class EmergencyVM
    {
        public Emergency Emergency { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> DepartmentList { get; set; }
        public EmergencyVM()
        {
            Emergency = new Emergency
            {
                Status = "Pending"
            };
        }
    }
}
