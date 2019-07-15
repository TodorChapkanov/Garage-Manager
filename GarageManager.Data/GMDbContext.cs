using GarageManager.Data.Configurations;
using GarageManager.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace GarageManager.Data
{
    public class GMDbContext : IdentityDbContext<GMUser,IdentityRole,string>
    {

        public GMDbContext(DbContextOptions<GMDbContext> options) : base(options)
        {
        }

        //TODO Change user email to be notnulable

        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<Repair> RepairTypes { get; set; }
        public DbSet<TransmissionType> TransmissionTypes { get; set; }
        public DbSet<VehicleManufacturer> VehicleManufacturers { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }
        public DbSet<ServicePart> ServiceParts { get; set; }
        public DbSet<ServiceRepair> ServiceRepairs { get; set; }

       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CarConfig());
            builder.ApplyConfiguration(new CustomerConfig());
            builder.ApplyConfiguration(new DepartmentConfig());
            builder.ApplyConfiguration(new ServicePartConfig());
            builder.ApplyConfiguration(new ServiceRepairConfig());
            builder.ApplyConfiguration(new VehicleManufacturerConfig());
            builder.ApplyConfiguration(new VehicleModelConfig());

            base.OnModelCreating(builder);
        }
    }
}
