using PediGuard.Models;
using PediGuard.Repository.IRepository;

namespace PediGuard.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public IDepartmentRepository Department { get; private set; }
        public IAssistantRepository Assistant { get; private set; }
        public INobetRepository Nobet { get; private set; }
        public IEmergencyRepository Emergency { get; private set; }
        public IDoctorRepository Doctor { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Department = new DepartmentRepository(_db);
            Assistant = new AssistantRepository(_db);
            Nobet = new NobetRepository(_db);
            Emergency = new EmergencyRepository(_db);
            Doctor = new DoctorRepository(_db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
