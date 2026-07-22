using LocaCraft.Domain.Bases;
using LocaCraft.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LocaCraft.Infrastructure.Bases
{
    public class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity>
        where TEntity : BaseEntity
        where TContext : AppDbContext
    {
        #region ATTRIBUTES
        private readonly TContext _context;
        #endregion

        #region CONSTRUCTOR
        public BaseRepository(TContext context)
        {
            _context = context;
        }
        #endregion

        public async Task<TEntity> GetByIdAsync(int id)
        {
            var result = await _context.Set<TEntity>().FindAsync(id);
            if (result == null)
                throw new KeyNotFoundException($"Item with ID {id} not found.");
            return result;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> where)
        {
            return await _context.Set<TEntity>().Where(where).AsNoTracking().ToListAsync();
        }
    }
}
