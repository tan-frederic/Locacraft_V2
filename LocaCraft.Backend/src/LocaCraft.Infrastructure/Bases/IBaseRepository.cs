using LocaCraft.Domain.Bases;
using System.Linq.Expressions;

namespace LocaCraft.Infrastructure.Bases
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> where);
    }
}
