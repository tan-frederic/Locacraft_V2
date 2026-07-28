using LocaCraft.API.Entities;
using LocaCraft.Application.Bases;
using LocaCraft.Application.Dtos.RealEstates;
using LocaCraft.Infrastructure.Repositories;

namespace LocaCraft.Application.Services
{
    public class RealEstateService : BaseService<IRealEstateRepository, RealEstate>, IRealEstateService
    {
        public RealEstateService(IRealEstateRepository repository) : base(repository)
        {
        }

        public async Task<RealEstateResponseDto> CreateRealEstate(RealEstate realEstate)
        {
            await _repository.CreateRealEstateAsync(realEstate);
            return RealEstateDtoMapper.ToResponseDto(realEstate);
        }
    }
}
