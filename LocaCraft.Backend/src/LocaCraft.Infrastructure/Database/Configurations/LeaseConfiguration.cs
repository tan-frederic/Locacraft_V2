using LocaCraft.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocaCraft.Infrastructure.Database.Configurations
{
    internal class LeaseConfiguration : IEntityTypeConfiguration<Lease>
    {
        public void Configure(EntityTypeBuilder<Lease> builder)
        {
            builder.HasKey(l => l.Id);

            builder.Property(l => l.Name)
                .IsRequired();
            builder.Property(l => l.MonthlyRent)
                .HasColumnType("decimal(18,2)")
                .IsRequired();
            builder.Property(l => l.MonthlyCharges)
                .HasColumnType("decimal(18,2)")
                .IsRequired();
            builder.Property(l => l.StartDate)
                .IsRequired();
            builder.Property(l => l.EndDate)
                .IsRequired(false);
            builder.Property(l => l.RealEstateId)
                .IsRequired();
        }
    }
}
