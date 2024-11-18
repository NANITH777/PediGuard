namespace PediGuard.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IDepartmentRepository Department { get; }
        IAssistantRepository Assistant { get; }
        void Save();
    }
}
