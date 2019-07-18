using Microsoft.EntityFrameworkCore.Migrations;

namespace GarageManager.Data.Migrations
{
    public partial class Car_IdInService_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsInService",
                table: "Cars",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsInService",
                table: "Cars");
        }
    }
}
