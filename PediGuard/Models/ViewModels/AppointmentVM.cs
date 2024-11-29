using Microsoft.AspNetCore.Mvc.Rendering;

namespace PediGuard.Models.ViewModels
{
    public class AppointmentVM
    {
        public Appointment Appointment { get; set; }

        public IEnumerable<SelectListItem> NobetList { get; set; }
    }
}
