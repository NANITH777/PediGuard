using PediGuard.Models;
using PediGuard.Repository.IRepository;

namespace PediGuard.Repository
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
