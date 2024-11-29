using PediGuard.Models;

namespace PediGuard.Repository.IRepository
{
    public interface INobetRepository : IRepository<Nobet>
    {
        void Update(Nobet obj);
        IEnumerable<Nobet> GetAllAvailableNobets();
    }
}
