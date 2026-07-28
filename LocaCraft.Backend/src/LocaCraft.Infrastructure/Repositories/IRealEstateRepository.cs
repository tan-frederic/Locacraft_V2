using LocaCraft.API.Entities;
using LocaCraft.Infrastructure.Bases;
using LocaCraft.Infrastructure.Database;

namespace LocaCraft.Infrastructure.Repositories
{
    public interface IRealEstateRepository : IBaseRepository<RealEstate>
    {
        public Task CreateRealEstate(RealEstate realEstate);
    }
}
