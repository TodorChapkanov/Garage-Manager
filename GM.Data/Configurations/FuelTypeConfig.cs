using GM.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GM.Data.Configurations
{
    public class FuelTypeConfig : IEntityTypeConfiguration<FuelType>
    {
        public void Configure(EntityTypeBuilder<FuelType> builder)
        {
            builder
                .HasMany(fuel => fuel.Cars)
                .WithOne(car => car.FuelType)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
