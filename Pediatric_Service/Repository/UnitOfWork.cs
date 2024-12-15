using Pediatric_Service.Models;
using Pediatric_Service.Repository.IRepository;

namespace Pediatric_Service.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public IDoctorRepository Doctor { get; private set; }
        public IDepartmentRepository Department { get; private set; }
        public IAssistantRepository Assistant { get; private set; }
        public INobetRepository Nobet { get; private set; }
        public IAssistantNobetRepository AssistantNobet { get; private set; }
        public IEmergencyRepository Emergency { get; private set; }

        public IAppointmentRepository Appointment { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Doctor = new DoctorRepository(_db);
            Department = new DepartmentRepository(_db);
            Assistant = new AssistantRepository(_db);
            Nobet = new NobetRepository(_db);
            AssistantNobet = new AssistantNobetRepository(_db);
            Emergency = new EmergencyRepository(_db);
            Appointment = new AppointmentRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
