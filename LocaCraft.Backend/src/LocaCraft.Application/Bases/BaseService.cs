using LocaCraft.Domain.Bases;
using LocaCraft.Infrastructure.Bases;
using System.Linq.Expressions;

namespace LocaCraft.Application.Bases
{
    public class BaseService<TRepository, TEntity> : IBaseService<TEntity>
        where TRepository : IBaseRepository<TEntity>
        where TEntity : BaseEntity
    {
        protected readonly TRepository _repository;

        public BaseService(TRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> where)
        {
            return await _repository.GetAllAsync(where);
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
    }
}
