namespace PediGuard.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IDepartmentRepository Department { get; }
        IAssistantRepository Assistant { get; }
        INobetRepository Nobet { get; }
        void Save();
    }
}
