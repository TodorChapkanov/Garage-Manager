using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GarageManager.Data.Migrations
{
    public partial class Delet_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceParts");

            migrationBuilder.DropTable(
                name: "ServiceRepairs");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "RepairTypes",
                newName: "ServiceId");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Part",
                newName: "ServiceId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "VehicleManufacturers",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ServiceId",
                table: "RepairTypes",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ServiceId",
                table: "Part",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Customers",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Customers",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 40);

            migrationBuilder.CreateIndex(
                name: "IX_RepairTypes_ServiceId",
                table: "RepairTypes",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Part_ServiceId",
                table: "Part",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Part_ServiceInterventions_ServiceId",
                table: "Part",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Part_ServiceInterventions_ServiceId",
                table: "Part");

            migrationBuilder.DropForeignKey(
                name: "FK_RepairTypes_ServiceInterventions_ServiceId",
                table: "RepairTypes");

            migrationBuilder.DropIndex(
                name: "IX_RepairTypes_ServiceId",
                table: "RepairTypes");

            migrationBuilder.DropIndex(
                name: "IX_Part_ServiceId",
                table: "Part");

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "RepairTypes",
                newName: "DepartmentId");

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "Part",
                newName: "DepartmentId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "VehicleManufacturers",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "DepartmentId",
                table: "RepairTypes",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DepartmentId",
                table: "Part",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Customers",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Customers",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.CreateTable(
                name: "ServiceParts",
                columns: table => new
                {
                    PartId = table.Column<string>(nullable: false),
                    ServiceId = table.Column<string>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceParts", x => new { x.PartId, x.ServiceId });
                    table.ForeignKey(
                        name: "FK_ServiceParts_Part_PartId",
                        column: x => x.PartId,
                        principalTable: "Part",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceParts_ServiceInterventions_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "ServiceInterventions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceRepairs",
                columns: table => new
                {
                    RepairId = table.Column<string>(nullable: false),
                    ServiceId = table.Column<string>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRepairs", x => new { x.RepairId, x.ServiceId });
                    table.ForeignKey(
                        name: "FK_ServiceRepairs_RepairTypes_RepairId",
                        column: x => x.RepairId,
                        principalTable: "RepairTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceRepairs_ServiceInterventions_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "ServiceInterventions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceParts_ServiceId",
                table: "ServiceParts",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRepairs_ServiceId",
                table: "ServiceRepairs",
                column: "ServiceId");
        }
    }
}
