using LocaCraft.API.Entities;
using LocaCraft.Application.Bases;
using LocaCraft.Application.Dtos.RealEstates;

namespace LocaCraft.Application.Services
{
    public interface IRealEstateService : IBaseService<RealEstate>
    {
        Task<RealEstateResponseDto> CreateRealEstate(RealEstate realEstate);
    }
}
