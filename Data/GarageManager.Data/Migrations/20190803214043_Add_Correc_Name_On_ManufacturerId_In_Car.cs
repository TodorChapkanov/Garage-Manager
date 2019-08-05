using Microsoft.EntityFrameworkCore.Migrations;

namespace GarageManager.Data.Migrations
{
    public partial class Add_Correc_Name_On_ManufacturerId_In_Car : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_VehicleManufacturers_ManufactureId",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "ManufactureId",
                table: "Cars",
                newName: "ManufacturerId");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_ManufactureId",
                table: "Cars",
                newName: "IX_Cars_ManufacturerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_VehicleManufacturers_ManufacturerId",
                table: "Cars",
                column: "ManufacturerId",
                principalTable: "VehicleManufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_VehicleManufacturers_ManufacturerId",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "ManufacturerId",
                table: "Cars",
                newName: "ManufactureId");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_ManufacturerId",
                table: "Cars",
                newName: "IX_Cars_ManufactureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_VehicleManufacturers_ManufactureId",
                table: "Cars",
                column: "ManufactureId",
                principalTable: "VehicleManufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
