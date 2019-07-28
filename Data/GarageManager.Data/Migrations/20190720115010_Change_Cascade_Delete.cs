using Microsoft.EntityFrameworkCore.Migrations;

namespace GarageManager.Data.Migrations
{
    public partial class Change_Cascade_Delete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parts_ServiceInterventions_ServiceId",
                table: "Parts");

            migrationBuilder.DropForeignKey(
                name: "FK_RepairTypes_ServiceInterventions_ServiceId",
                table: "RepairTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceInterventions_Cars_CarId",
                table: "ServiceInterventions");

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_ServiceInterventions_ServiceId",
                table: "Parts",
                column: "ServiceId",
                principalTable: "ServiceInterventions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RepairTypes_ServiceInterventions_ServiceId",
                table: "RepairTypes",
                column: "ServiceId",
                principalTable: "ServiceInterventions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceInterventions_Cars_CarId",
                table: "ServiceInterventions",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parts_ServiceInterventions_ServiceId",
                table: "Parts");

            migrationBuilder.DropForeignKey(
                name: "FK_RepairTypes_ServiceInterventions_ServiceId",
                table: "RepairTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceInterventions_Cars_CarId",
                table: "ServiceInterventions");

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_ServiceInterventions_ServiceId",
                table: "Parts",
                column: "ServiceId",
                principalTable: "ServiceInterventions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RepairTypes_ServiceInterventions_ServiceId",
                table: "RepairTypes",
                column: "ServiceId",
                principalTable: "ServiceInterventions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceInterventions_Cars_CarId",
                table: "ServiceInterventions",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
