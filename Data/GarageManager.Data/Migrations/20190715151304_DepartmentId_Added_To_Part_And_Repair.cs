using Microsoft.EntityFrameworkCore.Migrations;

namespace GarageManager.Data.Migrations
{
    public partial class DepartmentId_Added_To_Part_And_Repair : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceParts_ServiceInterventions_ServiceId",
                table: "ServiceParts");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceRepairs_ServiceInterventions_ServiceId",
                table: "ServiceRepairs");

            migrationBuilder.DropTable(
                name: "ServiceInterventions");

            migrationBuilder.AddColumn<string>(
                name: "DepartmentId",
                table: "RepairTypes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DepartmentId",
                table: "Part",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ServiceIntervention",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CarId = table.Column<string>(nullable: false),
                    IsFinished = table.Column<bool>(nullable: false),
                    TotalCost = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceIntervention", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceIntervention_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceIntervention_CarId",
                table: "ServiceIntervention",
                column: "CarId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceParts_ServiceIntervention_ServiceId",
                table: "ServiceParts",
                column: "ServiceId",
                principalTable: "ServiceIntervention",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceRepairs_ServiceIntervention_ServiceId",
                table: "ServiceRepairs",
                column: "ServiceId",
                principalTable: "ServiceIntervention",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceParts_ServiceIntervention_ServiceId",
                table: "ServiceParts");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceRepairs_ServiceIntervention_ServiceId",
                table: "ServiceRepairs");

            migrationBuilder.DropTable(
                name: "ServiceIntervention");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "RepairTypes");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Part");

            migrationBuilder.CreateTable(
                name: "ServiceInterventions",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CarId = table.Column<string>(nullable: false),
                    IsFinished = table.Column<bool>(nullable: false),
                    TotalCost = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceInterventions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceInterventions_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceInterventions_CarId",
                table: "ServiceInterventions",
                column: "CarId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceParts_ServiceInterventions_ServiceId",
                table: "ServiceParts",
                column: "ServiceId",
                principalTable: "ServiceInterventions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceRepairs_ServiceInterventions_ServiceId",
                table: "ServiceRepairs",
                column: "ServiceId",
                principalTable: "ServiceInterventions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
