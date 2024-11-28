using Microsoft.AspNetCore.Mvc.Rendering;

namespace PediGuard.Models.ViewModels
{
    public class AppointmentVM
    {
        public Appointment Appointment { get; set; }

        public IEnumerable<SelectListItem> AssistantList { get; set; }
        public IEnumerable<SelectListItem> DepartmentList { get; set; }
    }
}
