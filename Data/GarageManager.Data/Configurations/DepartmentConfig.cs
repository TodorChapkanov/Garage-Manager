using GarageManager.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GarageManager.Data.Configurations
{
    class DepartmentConfig : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder
                 .HasMany(department => department.Employees)
                 .WithOne(employee => employee.Department)
                 .OnDelete(DeleteBehavior.SetNull);

            builder
                .HasMany(department => department.Cars)
                .WithOne(car => car.Department)
                .HasForeignKey(department => department.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
