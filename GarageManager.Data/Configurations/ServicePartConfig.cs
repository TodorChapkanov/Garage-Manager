using GarageManager.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManager.Data.Configurations
{
    public class ServicePartConfig : IEntityTypeConfiguration<ServicePart>
    {
        public void Configure(EntityTypeBuilder<ServicePart> builder)
        {
            builder
               .HasKey(sr => new { sr.PartId, sr.ServiceId });

            builder
                .HasOne(sr => sr.Service)
                .WithMany(service => service.Parts)
                .HasForeignKey(sr => sr.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(sr => sr.Part)
                .WithMany(repair => repair.Services)
                .HasForeignKey(sr => sr.PartId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
