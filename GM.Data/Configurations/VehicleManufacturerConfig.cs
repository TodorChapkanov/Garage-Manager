using GM.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GM.Data.Configurations
{
    public class VehicleManufacturerConfig : IEntityTypeConfiguration<VehicleManufacturer>
    {
        public void Configure(EntityTypeBuilder<VehicleManufacturer> builder)
        {
            builder
                .HasMany(manufacturer => manufacturer.Cars)
                .WithOne(car => car.Manufacturer)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(manufacturer => manufacturer.VehicleModels)
                .WithOne(model => model.Manufacturer)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
