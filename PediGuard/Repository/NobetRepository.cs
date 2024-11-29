using Microsoft.EntityFrameworkCore;
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
            var objFromDb = _db.Nobets.FirstOrDefault(u => u.ID == obj.ID);

            if (objFromDb != null)
            {
                objFromDb.Date = obj.Date;
                objFromDb.StartTime = obj.StartTime;
                objFromDb.EndTime = obj.EndTime;
                objFromDb.AssistantID = obj.AssistantID;
                objFromDb.DepartmentID = obj.DepartmentID;

                if (obj.Assistant != null)
                {
                    objFromDb.Assistant = obj.Assistant;
                }
                if (obj.Department != null)
                {
                    objFromDb.Department = obj.Department;
                }
            }
        }

        public IEnumerable<Nobet> GetAllAvailableNobets()
        {
            return _db.Nobets
                .Include(n => n.Assistant)
                .Include(n => n.Department)
                .Where(n => !n.Appointments.Any())
                .OrderBy(n => n.Date)
                .ToList();
        }

    }
}
