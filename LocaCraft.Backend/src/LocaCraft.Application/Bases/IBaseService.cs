using LocaCraft.Domain.Bases;
using System.Linq.Expressions;

namespace LocaCraft.Application.Bases
{
    public interface IBaseService<T> where T : BaseEntity 
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> where);

        Task SaveAsync();
    }
}
