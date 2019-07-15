using GarageManager.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManager.Data.Configurations
{
    public class CarConfig : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder
                 .HasOne(car => car.Manufacturer)
                 .WithMany(manufactor => manufactor.Cars)
                 .HasForeignKey(car => car.ManufactureId)
                 .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(car => car.Model)
                .WithMany(model => model.Cars)
                .HasForeignKey(car => car.ModelId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(car => car.Customer)
                .WithMany(customer => customer.Cars)
                .HasForeignKey(car => car.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
