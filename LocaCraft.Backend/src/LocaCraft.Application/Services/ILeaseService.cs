using LocaCraft.Application.Bases;
using LocaCraft.Application.Dtos.Leases;
using LocaCraft.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocaCraft.Application.Services
{
    public interface ILeaseService : IBaseService<Lease>
    {
        Task<LeaseResponseDto> CreateLease(Lease lease);
    }
}
