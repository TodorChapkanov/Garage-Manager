using Microsoft.EntityFrameworkCore.Migrations;

namespace GarageManager.Data.Migrations
{
    public partial class Missing_Parts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                table: "RepairTypes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RepairTypes_EmployeeId",
                table: "RepairTypes",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RepairTypes_AspNetUsers_EmployeeId",
                table: "RepairTypes",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepairTypes_AspNetUsers_EmployeeId",
                table: "RepairTypes");

            migrationBuilder.DropIndex(
                name: "IX_RepairTypes_EmployeeId",
                table: "RepairTypes");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "RepairTypes");
        }
    }
}
