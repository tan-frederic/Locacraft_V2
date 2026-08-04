using LocaCraft.Domain.Entities;
using LocaCraft.Infrastructure.Bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocaCraft.Infrastructure.Repositories
{
    public interface ILeaseRepository : IBaseRepository<Lease>
    {
        public Task CreateLeaseAsync(Lease lease);
    }
}
