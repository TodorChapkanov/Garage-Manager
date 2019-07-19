using GarageManager.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManager.Data.Configurations
{
    public class ServiceConfig : IEntityTypeConfiguration<ServiceIntervention>
    {
        public void Configure(EntityTypeBuilder<ServiceIntervention> builder)
        {
            builder
                .HasOne(service => service.Car)
                .WithOne(car => car.Services)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(service => service.Parts)
                .WithOne(part => part.Service)
                .HasForeignKey(service => service.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(service => service.Repairs)
                .WithOne(part => part.Service)
                .HasForeignKey(service => service.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
