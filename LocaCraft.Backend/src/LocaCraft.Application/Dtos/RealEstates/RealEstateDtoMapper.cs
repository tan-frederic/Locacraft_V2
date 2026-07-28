using LocaCraft.API.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocaCraft.Application.Dtos.RealEstates
{
    public static class RealEstateDtoMapper
    {
        public static RealEstateResponseDto ToResponseDto(RealEstate realEstate)
        {
            return new RealEstateResponseDto()
            {
                Name = realEstate.Name,
                Address = realEstate.Address,
                PostalCode = realEstate.PostalCode
            };
        }

        public static RealEstate ToEntity(CreateRealEstateDto dto)
        {
            return new RealEstate()
            {
                Name = dto.Name,
                Address = dto.Address,
                PostalCode = dto.PostalCode
            };
        }

        public static void ApplyUpdate(UpdateRealEstateDto dto, RealEstate realEstate)
        {
            realEstate.Name = dto.Name;
            realEstate.Address = dto.Address;
            realEstate.PostalCode = dto.PostalCode;
        }
    }
}
