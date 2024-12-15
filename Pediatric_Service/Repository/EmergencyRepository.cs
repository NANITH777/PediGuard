using Pediatric_Service.Models;
using Pediatric_Service.Repository.IRepository;

namespace Pediatric_Service.Repository
{
    public class EmergencyRepository : Repository<Emergency>, IEmergencyRepository
    {
        private ApplicationDbContext _db;
        public EmergencyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Emergency obj)
        {
            _db.Emergencies.Update(obj);
        }
    }
}
