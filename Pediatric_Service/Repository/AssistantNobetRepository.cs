using Microsoft.EntityFrameworkCore;
using Pediatric_Service.Models;
using Pediatric_Service.Repository.IRepository;

namespace Pediatric_Service.Repository
{
    public class AssistantNobetRepository : Repository<AssistantNobet>, IAssistantNobetRepository
    {
        private ApplicationDbContext _db;
        public AssistantNobetRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(AssistantNobet obj)
        {
            var objFromDb = _db.AssistantNobets.FirstOrDefault(u => u.ID == obj.ID);

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

    }
}
