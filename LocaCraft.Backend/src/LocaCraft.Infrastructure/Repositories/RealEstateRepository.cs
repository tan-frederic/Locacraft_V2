using LocaCraft.API.Entities;
using LocaCraft.Infrastructure.Bases;
using LocaCraft.Infrastructure.Database;

namespace LocaCraft.Infrastructure.Repositories
{
    public class RealEstateRepository : BaseRepository<RealEstate, AppDbContext>, IRealEstateRepository
    {
        public RealEstateRepository(AppDbContext context) : base(context)
        {
        }

        public async Task CreateRealEstateAsync(RealEstate realEstate)
        {
            await _context.AddAsync(realEstate);
        }
    }
}
