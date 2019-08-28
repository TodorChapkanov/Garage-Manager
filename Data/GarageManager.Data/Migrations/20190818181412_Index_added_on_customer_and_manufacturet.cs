using Microsoft.EntityFrameworkCore.Migrations;

namespace GarageManager.Data.Migrations
{
    public partial class Index_added_on_customer_and_manufacturet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_VehicleManufacturers_Name",
                table: "VehicleManufacturers",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_FirstName",
                table: "Customers",
                column: "FirstName");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_LastName",
                table: "Customers",
                column: "LastName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_VehicleManufacturers_Name",
                table: "VehicleManufacturers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_FirstName",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_LastName",
                table: "Customers");
        }
    }
}
