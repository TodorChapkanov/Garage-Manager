using GarageManager.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManager.Data.Configurations
{
    public class VehicleManufacturerConfig : IEntityTypeConfiguration<VehicleManufacturer>
    {
        public void Configure(EntityTypeBuilder<VehicleManufacturer> builder)
        {
            builder
                .HasMany(manufacturer => manufacturer.Cars)
                .WithOne(car => car.Make)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(manufacturer => manufacturer.VehicleModels)
                .WithOne(model => model.Manufacturer)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasIndex(manufacturer => manufacturer.Name);
        }
    }
}
