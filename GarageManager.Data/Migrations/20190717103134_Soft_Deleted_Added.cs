using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GarageManager.Data.Migrations
{
    public partial class Soft_Deleted_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "VehicleModels",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "VehicleModels",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "VehicleManufacturers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "VehicleManufacturers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "TransmissionTypes",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TransmissionTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "ServiceRepairs",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ServiceRepairs",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "ServiceParts",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ServiceParts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "ServiceInterventions",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ServiceInterventions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "RepairTypes",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "RepairTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Part",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Part",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "FuelTypes",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "FuelTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Departments",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Departments",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Customers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Cars",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "VehicleModels");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "VehicleModels");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "VehicleManufacturers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "VehicleManufacturers");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "TransmissionTypes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TransmissionTypes");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "ServiceRepairs");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ServiceRepairs");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "ServiceParts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ServiceParts");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "ServiceInterventions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ServiceInterventions");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "RepairTypes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "RepairTypes");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "FuelTypes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "FuelTypes");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Cars");
        }
    }
}
