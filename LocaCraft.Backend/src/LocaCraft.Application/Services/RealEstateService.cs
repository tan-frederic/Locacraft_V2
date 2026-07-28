using LocaCraft.API.Entities;
using LocaCraft.Application.Bases;
using LocaCraft.Infrastructure.Repositories;

namespace LocaCraft.Application.Services
{
    public class RealEstateService : BaseService<IRealEstateRepository, RealEstate>, IRealEstateService
    {
        public RealEstateService(IRealEstateRepository repository) : base(repository)
        {
        }
    }
}
