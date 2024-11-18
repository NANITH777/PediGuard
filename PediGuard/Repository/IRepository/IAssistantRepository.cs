using PediGuard.Models;

namespace PediGuard.Repository.IRepository
{
    public interface IAssistantRepository : IRepository<Assistant>
    {
        void Update(Assistant obj);
    }
}
