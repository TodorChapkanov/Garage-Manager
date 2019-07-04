using GM.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GM.Data.Configurations
{
    public class ServiceConfig : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder
                .HasOne(service => service.Car)
                .WithMany(car => car.Services)
                .HasForeignKey(service => service.CarId)
                .OnDelete(DeleteBehavior.Restrict);

            
        }
    }
}
