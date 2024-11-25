using NuGet.DependencyResolver;

namespace PediGuard.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        public int AssistantId { get; set; }
        public Assistant Assistant { get; set; } 

        public int DepartmentId { get; set; }
        public Department Department { get; set; } 
        public string Description { get; set; }

        public DateTime Date { get; set; }

        public DateTime Time { get; set; }

        public int Duration { get; set; }

        public string Status { get; set; } 
    }

}
