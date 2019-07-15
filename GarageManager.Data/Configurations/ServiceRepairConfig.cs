using GarageManager.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManager.Data.Configurations
{
    public class ServiceRepairConfig : IEntityTypeConfiguration<ServiceRepair>
    {
        public void Configure(EntityTypeBuilder<ServiceRepair> builder)
        {
            builder
                .HasKey(sr => new { sr.RepairId, sr.ServiceId });

            builder
                .HasOne(sr => sr.Service)
                .WithMany(service => service.Repairs)
                .HasForeignKey(sr => sr.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(sr => sr.Repair)
                .WithMany(repair => repair.Services)
                .HasForeignKey(sr => sr.RepairId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
