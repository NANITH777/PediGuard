using Pediatric_Service.Models;

namespace Pediatric_Service.Repository.IRepository
{
    public interface IAssistantNobetRepository : IRepository<AssistantNobet>
    {
        void Update(AssistantNobet obj);
    }
}
