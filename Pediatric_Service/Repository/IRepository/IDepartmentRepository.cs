using Pediatric_Service.Models;

namespace Pediatric_Service.Repository.IRepository
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        void Update(Department obj);
    }
}
