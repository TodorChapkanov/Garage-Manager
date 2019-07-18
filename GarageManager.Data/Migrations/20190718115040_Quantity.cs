using Microsoft.EntityFrameworkCore.Migrations;

namespace GarageManager.Data.Migrations
{
    public partial class Quantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quatity",
                table: "Part",
                newName: "Quantity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Part",
                newName: "Quatity");
        }
    }
}
