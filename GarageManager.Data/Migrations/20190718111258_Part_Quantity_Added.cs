using Microsoft.EntityFrameworkCore.Migrations;

namespace GarageManager.Data.Migrations
{
    public partial class Part_Quantity_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quatity",
                table: "Part",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quatity",
                table: "Part");
        }
    }
}
