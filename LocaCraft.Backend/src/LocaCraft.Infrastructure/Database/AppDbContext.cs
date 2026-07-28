using LocaCraft.API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LocaCraft.Infrastructure.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<RealEstate> RealEstates { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
