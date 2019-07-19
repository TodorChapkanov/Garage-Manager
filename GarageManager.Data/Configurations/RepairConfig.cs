using GarageManager.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManager.Data.Configurations
{
    public class RepairConfig : IEntityTypeConfiguration<Repair>
    {
        public void Configure(EntityTypeBuilder<Repair> builder)
        {
            builder
                .HasOne(repair => repair.Service)
                .WithMany(service => service.Repairs)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
