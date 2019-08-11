using Microsoft.EntityFrameworkCore.Migrations;

namespace GarageManager.Data.Migrations
{
    public partial class Changet_Name_On_FuelType_And_TransmissionType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "TransmissionTypes",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "FuelTypes",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "TransmissionTypes",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "FuelTypes",
                newName: "Type");
        }
    }
}
