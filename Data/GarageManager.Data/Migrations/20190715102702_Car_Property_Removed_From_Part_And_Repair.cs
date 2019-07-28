using Microsoft.EntityFrameworkCore.Migrations;

namespace GarageManager.Data.Migrations
{
    public partial class Car_Property_Removed_From_Part_And_Repair : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Part_Cars_CarId",
                table: "Part");

            migrationBuilder.DropForeignKey(
                name: "FK_RepairTypes_Cars_CarId",
                table: "RepairTypes");

            migrationBuilder.DropIndex(
                name: "IX_RepairTypes_CarId",
                table: "RepairTypes");

            migrationBuilder.DropIndex(
                name: "IX_Part_CarId",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "RepairTypes");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Part");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CarId",
                table: "RepairTypes",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CarId",
                table: "Part",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RepairTypes_CarId",
                table: "RepairTypes",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Part_CarId",
                table: "Part",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Part_Cars_CarId",
                table: "Part",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RepairTypes_Cars_CarId",
                table: "RepairTypes",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
