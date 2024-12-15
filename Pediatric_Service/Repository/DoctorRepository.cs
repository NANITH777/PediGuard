using Pediatric_Service.Models;
using Pediatric_Service.Repository.IRepository;

namespace Pediatric_Service.Repository
{
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        private ApplicationDbContext _db;
        public DoctorRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Doctor obj)
        {
            _db.Doctors.Update(obj);
        }
    }
}
