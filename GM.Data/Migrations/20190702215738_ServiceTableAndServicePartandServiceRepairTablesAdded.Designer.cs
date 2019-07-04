﻿// <auto-generated />
using System;
using GM.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GM.Data.Migrations
{
    [DbContext(typeof(GMDbContext))]
    [Migration("20190702215738_ServiceTableAndServicePartandServiceRepairTablesAdded")]
    partial class ServiceTableAndServicePartandServiceRepairTablesAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GM.Domain.Car", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CustomerId");

                    b.Property<string>("DepartmentId");

                    b.Property<int>("EngineHorsePower");

                    b.Property<string>("EngineModel")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("FuelTypeId");

                    b.Property<string>("ManufactureID")
                        .IsRequired();

                    b.Property<string>("ModelId")
                        .IsRequired();

                    b.Property<string>("TransmissionId")
                        .IsRequired();

                    b.Property<string>("Vin")
                        .IsRequired()
                        .HasMaxLength(17);

                    b.Property<DateTime?>("YearOfManufacture")
                        .IsRequired();

                    b.Property<int>("Кilometers");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("FuelTypeId");

                    b.HasIndex("ManufactureID");

                    b.HasIndex("ModelId");

                    b.HasIndex("TransmissionId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("GM.Domain.Customer", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("PhoneNumber")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("GM.Domain.Department", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("GM.Domain.FuelType", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Type")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("FuelTypes");
                });

            modelBuilder.Entity("GM.Domain.GmUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("DepartmentId");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<int>("FirstName")
                        .HasMaxLength(30);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<DateTime?>("RecruitedOn");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("GM.Domain.Part", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CarId");

                    b.Property<string>("Name");

                    b.Property<string>("Number");

                    b.Property<double>("Price");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("Part");
                });

            modelBuilder.Entity("GM.Domain.Repair", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CarId")
                        .IsRequired();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<double>("Hours");

                    b.Property<string>("MechanicId")
                        .IsRequired();

                    b.Property<double>("PricePerHour");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("MechanicId");

                    b.ToTable("RepairTypes");
                });

            modelBuilder.Entity("GM.Domain.Service", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CarId")
                        .IsRequired();

                    b.Property<bool>("IsFinished");

                    b.Property<decimal>("TotalCost");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("GM.Domain.ServicePart", b =>
                {
                    b.Property<string>("PartId");

                    b.Property<string>("ServiceId");

                    b.HasKey("PartId", "ServiceId");

                    b.HasIndex("ServiceId");

                    b.ToTable("ServiceParts");
                });

            modelBuilder.Entity("GM.Domain.ServiceRepair", b =>
                {
                    b.Property<string>("RepairId");

                    b.Property<string>("ServiceId");

                    b.HasKey("RepairId", "ServiceId");

                    b.HasIndex("ServiceId");

                    b.ToTable("ServiceRepairs");
                });

            modelBuilder.Entity("GM.Domain.TransmissionType", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("TransmissionTypes");
                });

            modelBuilder.Entity("GM.Domain.VehicleManufacturer", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("VehicleManufacturers");
                });

            modelBuilder.Entity("GM.Domain.VehicleModel", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ManufactirerId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.HasIndex("ManufactirerId");

                    b.ToTable("VehicleModels");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("GM.Domain.Car", b =>
                {
                    b.HasOne("GM.Domain.Customer", "Customer")
                        .WithMany("Cars")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GM.Domain.Department")
                        .WithMany("Cars")
                        .HasForeignKey("DepartmentId");

                    b.HasOne("GM.Domain.FuelType", "FuelType")
                        .WithMany("Cars")
                        .HasForeignKey("FuelTypeId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("GM.Domain.VehicleManufacturer", "Manufacturer")
                        .WithMany("Cars")
                        .HasForeignKey("ManufactureID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GM.Domain.VehicleModel", "Model")
                        .WithMany("Cars")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("GM.Domain.TransmissionType", "Transmission")
                        .WithMany("Cars")
                        .HasForeignKey("TransmissionId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("GM.Domain.GmUser", b =>
                {
                    b.HasOne("GM.Domain.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("GM.Domain.Part", b =>
                {
                    b.HasOne("GM.Domain.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId");
                });

            modelBuilder.Entity("GM.Domain.Repair", b =>
                {
                    b.HasOne("GM.Domain.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GM.Domain.GmUser", "Mechanic")
                        .WithMany()
                        .HasForeignKey("MechanicId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GM.Domain.Service", b =>
                {
                    b.HasOne("GM.Domain.Car", "Car")
                        .WithMany("Services")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GM.Domain.ServicePart", b =>
                {
                    b.HasOne("GM.Domain.Part", "Part")
                        .WithMany("Services")
                        .HasForeignKey("PartId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("GM.Domain.Service", "Service")
                        .WithMany("Parts")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("GM.Domain.ServiceRepair", b =>
                {
                    b.HasOne("GM.Domain.Repair", "Repair")
                        .WithMany("Services")
                        .HasForeignKey("RepairId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("GM.Domain.Service", "Service")
                        .WithMany("Repairs")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("GM.Domain.VehicleModel", b =>
                {
                    b.HasOne("GM.Domain.VehicleManufacturer", "Manufacturer")
                        .WithMany("VehicleModels")
                        .HasForeignKey("ManufactirerId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("GM.Domain.GmUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("GM.Domain.GmUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GM.Domain.GmUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("GM.Domain.GmUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
