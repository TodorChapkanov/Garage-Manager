﻿using GM.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GM.Data.Configurations
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .HasMany(customer => customer.Cars)
                .WithOne(car => car.Customer)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
