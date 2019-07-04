using GM.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GM.Data.Configurations
{
    class DepartmentConfig : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder
                 .HasMany(department => department.Employees)
                 .WithOne(employee => employee.Department)
                 .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
