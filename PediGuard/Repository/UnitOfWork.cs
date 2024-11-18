using PediGuard.Models;
using PediGuard.Repository.IRepository;

namespace PediGuard.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public IDepartmentRepository Department { get; private set; }
        public IAssistantRepository Assistant { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Department = new DepartmentRepository(_db);
            Assistant = new AssistantRepository(_db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
