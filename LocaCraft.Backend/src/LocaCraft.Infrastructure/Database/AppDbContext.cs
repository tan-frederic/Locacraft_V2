using LocaCraft.API.Entities;
using Microsoft.EntityFrameworkCore;

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
            modelBuilder.Entity<RealEstate>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Address).IsRequired();
                entity.Property(e => e.PostalCode).IsRequired();
            });
        }
    }
}
