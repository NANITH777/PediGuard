using Pediatric_Service.Models;

namespace Pediatric_Service.Repository.IRepository
{
    public interface IAssistantRepository : IRepository<Assistant>
    {
        void Update(Assistant obj);
    }
}
