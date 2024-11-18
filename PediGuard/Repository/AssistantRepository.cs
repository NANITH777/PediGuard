using PediGuard.Models;
using PediGuard.Repository.IRepository;

namespace PediGuard.Repository
{
    public class AssistantRepository : Repository<Assistant>, IAssistantRepository
    {
        private ApplicationDbContext _db;
        public AssistantRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Assistant obj)
        {
            _db.Assistants.Update(obj);
        }
    }
}
