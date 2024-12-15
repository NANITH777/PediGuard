using Pediatric_Service.Models;

namespace Pediatric_Service.Repository.IRepository
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        void Update(Appointment obj);
    }
}
