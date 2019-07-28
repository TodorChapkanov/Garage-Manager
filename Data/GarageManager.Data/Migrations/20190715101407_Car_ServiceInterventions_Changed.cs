using Microsoft.EntityFrameworkCore.Migrations;

namespace GarageManager.Data.Migrations
{
    public partial class Car_ServiceInterventions_Changed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ServiceInterventions_CarId",
                table: "ServiceInterventions");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceInterventions_CarId",
                table: "ServiceInterventions",
                column: "CarId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ServiceInterventions_CarId",
                table: "ServiceInterventions");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceInterventions_CarId",
                table: "ServiceInterventions",
                column: "CarId");
        }
    }
}
