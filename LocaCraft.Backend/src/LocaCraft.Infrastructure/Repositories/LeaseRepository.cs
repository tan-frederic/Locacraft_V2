using LocaCraft.Domain.Entities;
using LocaCraft.Infrastructure.Bases;
using LocaCraft.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocaCraft.Infrastructure.Repositories
{
    internal class LeaseRepository : BaseRepository<Lease, AppDbContext>, ILeaseRepository
    {
        public LeaseRepository(AppDbContext context) : base(context)
        {
        }

        public async Task CreateLeaseAsync(Lease lease)
        {
            await _context.AddAsync(lease);
        }
    }
}
