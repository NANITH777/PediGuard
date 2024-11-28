using PediGuard.Models;

namespace PediGuard.Repository.IRepository
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        void Update(Appointment obj);
    }
}
