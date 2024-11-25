using PediGuard.Models;
using PediGuard.Repository.IRepository;

namespace PediGuard.Repository
{
    public class NobetRepository : Repository<Nobet>, INobetRepository
    {
        private ApplicationDbContext _db;
        public NobetRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Nobet obj)
        {
            _db.Nobets.Update(obj);
        }
    }
}
