using Pediatric_Service.Models;
using Pediatric_Service.Repository.IRepository;

namespace Pediatric_Service.Repository
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        private ApplicationDbContext _db;
        public AppointmentRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Appointment obj)
        {
            _db.Appointments.Update(obj);
        }
    }
}
