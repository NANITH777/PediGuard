using Pediatric_Service.Models;

namespace Pediatric_Service.Repository.IRepository
{
    public interface INobetRepository : IRepository<Nobet>
    {
        void Update(Nobet obj);
        //IEnumerable<Nobet> GetAllAvailableNobets();
    }
}
