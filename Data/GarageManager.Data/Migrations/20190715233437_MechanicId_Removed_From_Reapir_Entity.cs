using Microsoft.EntityFrameworkCore.Migrations;

namespace GarageManager.Data.Migrations
{
    public partial class MechanicId_Removed_From_Reapir_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepairTypes_AspNetUsers_MechanicId",
                table: "RepairTypes");

            migrationBuilder.DropIndex(
                name: "IX_RepairTypes_MechanicId",
                table: "RepairTypes");

            migrationBuilder.DropColumn(
                name: "MechanicId",
                table: "RepairTypes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MechanicId",
                table: "RepairTypes",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_RepairTypes_MechanicId",
                table: "RepairTypes",
                column: "MechanicId");

            migrationBuilder.AddForeignKey(
                name: "FK_RepairTypes_AspNetUsers_MechanicId",
                table: "RepairTypes",
                column: "MechanicId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
