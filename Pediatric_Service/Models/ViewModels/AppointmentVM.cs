using Microsoft.AspNetCore.Mvc.Rendering;

namespace Pediatric_Service.Models.ViewModels
{
    public class AppointmentVM
    {
        public Appointment Appointment { get; set; }

        public IEnumerable<SelectListItem> NobetList { get; set; }
    }
}
