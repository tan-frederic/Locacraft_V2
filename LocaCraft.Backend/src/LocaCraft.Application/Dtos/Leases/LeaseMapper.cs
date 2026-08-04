using LocaCraft.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocaCraft.Application.Dtos.Leases
{
    public static class LeaseMapper
    {
        public static LeaseResponseDto ToResponseDto(Lease lease)
        {
            return new LeaseResponseDto
            {
                Name = lease.Name,
                MonthlyRent = lease.MonthlyRent,
                MonthlyCharges = lease.MonthlyCharges,
                StartDate = lease.StartDate,
                EndDate = lease.EndDate
            };
        }

        public static Lease ToEntity(CreateLeaseDto dto)
        {
            return new Lease()
            {
                RealEstateId = dto.RealEstateId,
                Name = dto.Name,
                MonthlyRent = dto.MonthlyRent,
                MonthlyCharges = dto.MonthlyCharges,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate
            };
        }

        public static void ApplyUpdate(UpdateLeaseDto dto, Lease lease)
        {
            lease.RealEstateId = dto.RealEstateId;
            lease.Name = dto.Name;
            lease.MonthlyRent = dto.MonthlyRent;
            lease.MonthlyCharges = dto.MonthlyCharges;
            lease.StartDate = dto.StartDate;
            lease.EndDate = dto.EndDate;
        }
    }
}
