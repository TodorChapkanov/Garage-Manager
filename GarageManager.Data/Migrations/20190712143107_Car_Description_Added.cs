using Microsoft.EntityFrameworkCore.Migrations;

namespace GarageManager.Data.Migrations
{
    public partial class Car_Description_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_FuelTypes_FuelTypeId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_TransmissionTypes_TransmissionId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceParts_Service_ServiceId",
                table: "ServiceParts");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceRepairs_Service_ServiceId",
                table: "ServiceRepairs");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Cars",
                maxLength: 500,
                nullable: true);

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
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_FuelTypes_FuelTypeId",
                table: "Cars",
                column: "FuelTypeId",
                principalTable: "FuelTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_TransmissionTypes_TransmissionId",
                table: "Cars",
                column: "TransmissionId",
                principalTable: "TransmissionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_FuelTypes_FuelTypeId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_TransmissionTypes_TransmissionId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceParts_ServiceInterventions_ServiceId",
                table: "ServiceParts");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceRepairs_ServiceInterventions_ServiceId",
                table: "ServiceRepairs");

            migrationBuilder.DropTable(
                name: "ServiceInterventions");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Cars");

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

            migrationBuilder.CreateIndex(
                name: "IX_Service_CarId",
                table: "Service",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_FuelTypes_FuelTypeId",
                table: "Cars",
                column: "FuelTypeId",
                principalTable: "FuelTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_TransmissionTypes_TransmissionId",
                table: "Cars",
                column: "TransmissionId",
                principalTable: "TransmissionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceParts_Service_ServiceId",
                table: "ServiceParts",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceRepairs_Service_ServiceId",
                table: "ServiceRepairs",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
