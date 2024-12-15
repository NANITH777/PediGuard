using Microsoft.EntityFrameworkCore;
using Pediatric_Service.Models;
using Pediatric_Service.Repository.IRepository;

namespace Pediatric_Service.Repository
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
                objFromDb.DoctorID = obj.DoctorID;
                objFromDb.DepartmentID = obj.DepartmentID;

                if (obj.Doctor != null)
                {
                    objFromDb.Doctor = obj.Doctor;
                }
                if (obj.Department != null)
                {
                    objFromDb.Department = obj.Department;
                }
            }
        }

        //public IEnumerable<Nobet> GetAllAvailableNobets()
        //{
        //    return _db.Nobets
        //        .Include(n => n.Doctor)
        //        .Include(n => n.Department)
        //        .Where(n => !n.Appointments.Any())
        //        .OrderBy(n => n.Date)
        //        .ToList();
        //}

    }
}
