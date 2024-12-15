using System.Linq.Expressions;

namespace Pediatric_Service.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? Filter = null, string? includeProperties = null);
        T Get(Expression<Func<T, bool>> Filter, string? includeProperties = null, bool tracked = false);
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);

    }
}
