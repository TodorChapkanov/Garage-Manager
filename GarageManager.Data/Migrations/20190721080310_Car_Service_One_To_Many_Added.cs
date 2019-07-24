using Microsoft.EntityFrameworkCore.Migrations;

namespace GarageManager.Data.Migrations
{
    public partial class Car_Service_One_To_Many_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ServiceInterventions_CarId",
                table: "ServiceInterventions");

            migrationBuilder.AddColumn<string>(
                name: "CurrentServiceId",
                table: "Cars",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceInterventions_CarId",
                table: "ServiceInterventions",
                column: "CarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ServiceInterventions_CarId",
                table: "ServiceInterventions");

            migrationBuilder.DropColumn(
                name: "CurrentServiceId",
                table: "Cars");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceInterventions_CarId",
                table: "ServiceInterventions",
                column: "CarId",
                unique: false);
        }
    }
}
