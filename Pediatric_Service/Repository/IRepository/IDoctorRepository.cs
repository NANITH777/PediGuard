using Pediatric_Service.Models;

namespace Pediatric_Service.Repository.IRepository
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        void Update(Doctor obj);
    }
}
