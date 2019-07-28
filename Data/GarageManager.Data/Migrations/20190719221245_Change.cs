using Microsoft.EntityFrameworkCore.Migrations;

namespace GarageManager.Data.Migrations
{
    public partial class Change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Departments_DepartmentId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Customers_CustomerId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_VehicleManufacturers_ManufactureId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_TransmissionTypes_TransmissionId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Part_ServiceInterventions_ServiceId",
                table: "Part");

            migrationBuilder.DropForeignKey(
                name: "FK_RepairTypes_ServiceInterventions_ServiceId",
                table: "RepairTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceInterventions_Cars_CarId",
                table: "ServiceInterventions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Part",
                table: "Part");

            migrationBuilder.RenameTable(
                name: "Part",
                newName: "Parts");

            migrationBuilder.RenameIndex(
                name: "IX_Part_ServiceId",
                table: "Parts",
                newName: "IX_Parts_ServiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parts",
                table: "Parts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Departments_DepartmentId",
                table: "AspNetUsers",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Customers_CustomerId",
                table: "Cars",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_VehicleManufacturers_ManufactureId",
                table: "Cars",
                column: "ManufactureId",
                principalTable: "VehicleManufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_TransmissionTypes_TransmissionId",
                table: "Cars",
                column: "TransmissionId",
                principalTable: "TransmissionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_ServiceInterventions_ServiceId",
                table: "Parts",
                column: "ServiceId",
                principalTable: "ServiceInterventions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RepairTypes_ServiceInterventions_ServiceId",
                table: "RepairTypes",
                column: "ServiceId",
                principalTable: "ServiceInterventions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceInterventions_Cars_CarId",
                table: "ServiceInterventions",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Departments_DepartmentId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Customers_CustomerId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_VehicleManufacturers_ManufactureId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_TransmissionTypes_TransmissionId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Parts_ServiceInterventions_ServiceId",
                table: "Parts");

            migrationBuilder.DropForeignKey(
                name: "FK_RepairTypes_ServiceInterventions_ServiceId",
                table: "RepairTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceInterventions_Cars_CarId",
                table: "ServiceInterventions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parts",
                table: "Parts");

            migrationBuilder.RenameTable(
                name: "Parts",
                newName: "Part");

            migrationBuilder.RenameIndex(
                name: "IX_Parts_ServiceId",
                table: "Part",
                newName: "IX_Part_ServiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Part",
                table: "Part",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Departments_DepartmentId",
                table: "AspNetUsers",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Customers_CustomerId",
                table: "Cars",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_VehicleManufacturers_ManufactureId",
                table: "Cars",
                column: "ManufactureId",
                principalTable: "VehicleManufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_TransmissionTypes_TransmissionId",
                table: "Cars",
                column: "TransmissionId",
                principalTable: "TransmissionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Part_ServiceInterventions_ServiceId",
                table: "Part",
                column: "ServiceId",
                principalTable: "ServiceInterventions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RepairTypes_ServiceInterventions_ServiceId",
                table: "RepairTypes",
                column: "ServiceId",
                principalTable: "ServiceInterventions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceInterventions_Cars_CarId",
                table: "ServiceInterventions",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
