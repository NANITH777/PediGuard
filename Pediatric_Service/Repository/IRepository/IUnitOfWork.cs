namespace Pediatric_Service.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IDoctorRepository Doctor { get; }
        IDepartmentRepository Department { get; }
        IAssistantRepository Assistant { get; }
        INobetRepository Nobet { get; }
        IAssistantNobetRepository AssistantNobet { get; }
        IEmergencyRepository Emergency { get; }
        IAppointmentRepository Appointment { get; }
        IApplicationUserRepository ApplicationUser { get; }
        void Save();
    }
}
