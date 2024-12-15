using Pediatric_Service.Models;

namespace Pediatric_Service.Repository.IRepository
{
    public interface IEmergencyRepository : IRepository<Emergency>
    {
        void Update(Emergency obj);
    }
}
