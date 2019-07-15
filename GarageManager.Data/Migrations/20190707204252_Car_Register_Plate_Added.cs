using Microsoft.EntityFrameworkCore.Migrations;

namespace GarageManager.Data.Migrations
{
    public partial class Car_Register_Plate_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_VehicleManufacturers_ManufactureID",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "ManufactureID",
                table: "Cars",
                newName: "ManufactureId");

            migrationBuilder.RenameColumn(
                name: "ISFinished",
                table: "Cars",
                newName: "IsFinished");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_ManufactureID",
                table: "Cars",
                newName: "IX_Cars_ManufactureId");

            migrationBuilder.AddColumn<string>(
                name: "RegistrationPlate",
                table: "Cars",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_VehicleManufacturers_ManufactureId",
                table: "Cars",
                column: "ManufactureId",
                principalTable: "VehicleManufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_VehicleManufacturers_ManufactureId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "RegistrationPlate",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "ManufactureId",
                table: "Cars",
                newName: "ManufactureID");

            migrationBuilder.RenameColumn(
                name: "IsFinished",
                table: "Cars",
                newName: "ISFinished");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_ManufactureId",
                table: "Cars",
                newName: "IX_Cars_ManufactureID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_VehicleManufacturers_ManufactureID",
                table: "Cars",
                column: "ManufactureID",
                principalTable: "VehicleManufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
