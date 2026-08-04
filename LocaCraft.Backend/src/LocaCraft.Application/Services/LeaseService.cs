using LocaCraft.Application.Bases;
using LocaCraft.Application.Dtos.Leases;
using LocaCraft.Domain.Entities;
using LocaCraft.Infrastructure.Repositories;

namespace LocaCraft.Application.Services
{
    internal class LeaseService : BaseService<ILeaseRepository, Lease>, ILeaseService
    {
        public LeaseService(ILeaseRepository repository) : base(repository)
        {
        }

        public async Task<LeaseResponseDto> CreateLease(Lease lease)
        {
            await _repository.CreateLeaseAsync(lease);
            return LeaseMapper.ToResponseDto(lease);
        }
    }
}
