using Microsoft.EntityFrameworkCore.Migrations;

namespace GarageManager.Data.Migrations
{
    public partial class ServiceTableAndServicePartandServiceRepairTablesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepairTypes_Cars_CarId",
                table: "RepairTypes");

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CarId = table.Column<string>(nullable: false),
                    IsFinished = table.Column<bool>(nullable: false),
                    TotalCost = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Service_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceParts",
                columns: table => new
                {
                    ServiceId = table.Column<string>(nullable: false),
                    PartId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceParts", x => new { x.PartId, x.ServiceId });
                    table.ForeignKey(
                        name: "FK_ServiceParts_Part_PartId",
                        column: x => x.PartId,
                        principalTable: "Part",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceParts_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceRepairs",
                columns: table => new
                {
                    ServiceId = table.Column<string>(nullable: false),
                    RepairId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRepairs", x => new { x.RepairId, x.ServiceId });
                    table.ForeignKey(
                        name: "FK_ServiceRepairs_RepairTypes_RepairId",
                        column: x => x.RepairId,
                        principalTable: "RepairTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceRepairs_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Service_CarId",
                table: "Service",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceParts_ServiceId",
                table: "ServiceParts",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRepairs_ServiceId",
                table: "ServiceRepairs",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_RepairTypes_Cars_CarId",
                table: "RepairTypes",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepairTypes_Cars_CarId",
                table: "RepairTypes");

            migrationBuilder.DropTable(
                name: "ServiceParts");

            migrationBuilder.DropTable(
                name: "ServiceRepairs");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.AddForeignKey(
                name: "FK_RepairTypes_Cars_CarId",
                table: "RepairTypes",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
