using PediGuard.Models;

namespace PediGuard.Repository.IRepository
{
    public interface IEmergencyRepository : IRepository<Emergency>
    {
        void Update(Emergency obj);
    }
}
