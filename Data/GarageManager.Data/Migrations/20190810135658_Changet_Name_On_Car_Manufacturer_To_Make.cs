using Microsoft.EntityFrameworkCore.Migrations;

namespace GarageManager.Data.Migrations
{
    public partial class Changet_Name_On_Car_Manufacturer_To_Make : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_FuelTypes_FuelTypeId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_VehicleManufacturers_ManufacturerId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_RepairTypes_AspNetUsers_EmployeeId",
                table: "RepairTypes");

            migrationBuilder.RenameColumn(
                name: "ManufacturerId",
                table: "Cars",
                newName: "MakeId");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_ManufacturerId",
                table: "Cars",
                newName: "IX_Cars_MakeId");

            migrationBuilder.AlterColumn<string>(
                name: "ServiceId",
                table: "RepairTypes",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "RepairTypes",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ServiceId",
                table: "Parts",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "Parts",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Parts",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FuelTypeId",
                table: "Cars",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CurrentServiceId",
                table: "Cars",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_FuelTypes_FuelTypeId",
                table: "Cars",
                column: "FuelTypeId",
                principalTable: "FuelTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_VehicleManufacturers_MakeId",
                table: "Cars",
                column: "MakeId",
                principalTable: "VehicleManufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RepairTypes_AspNetUsers_EmployeeId",
                table: "RepairTypes",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_FuelTypes_FuelTypeId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_VehicleManufacturers_MakeId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_RepairTypes_AspNetUsers_EmployeeId",
                table: "RepairTypes");

            migrationBuilder.RenameColumn(
                name: "MakeId",
                table: "Cars",
                newName: "ManufacturerId");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_MakeId",
                table: "Cars",
                newName: "IX_Cars_ManufacturerId");

            migrationBuilder.AlterColumn<string>(
                name: "ServiceId",
                table: "RepairTypes",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "RepairTypes",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ServiceId",
                table: "Parts",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "Parts",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Parts",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "FuelTypeId",
                table: "Cars",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "CurrentServiceId",
                table: "Cars",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_FuelTypes_FuelTypeId",
                table: "Cars",
                column: "FuelTypeId",
                principalTable: "FuelTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_VehicleManufacturers_ManufacturerId",
                table: "Cars",
                column: "ManufacturerId",
                principalTable: "VehicleManufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RepairTypes_AspNetUsers_EmployeeId",
                table: "RepairTypes",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
