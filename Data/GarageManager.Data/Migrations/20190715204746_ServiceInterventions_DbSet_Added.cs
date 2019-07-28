using Microsoft.EntityFrameworkCore.Migrations;

namespace GarageManager.Data.Migrations
{
    public partial class ServiceInterventions_DbSet_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceIntervention_Cars_CarId",
                table: "ServiceIntervention");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceParts_ServiceIntervention_ServiceId",
                table: "ServiceParts");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceRepairs_ServiceIntervention_ServiceId",
                table: "ServiceRepairs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceIntervention",
                table: "ServiceIntervention");

            migrationBuilder.RenameTable(
                name: "ServiceIntervention",
                newName: "ServiceInterventions");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceIntervention_CarId",
                table: "ServiceInterventions",
                newName: "IX_ServiceInterventions_CarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceInterventions",
                table: "ServiceInterventions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceInterventions_Cars_CarId",
                table: "ServiceInterventions",
                column: "CarId",
                principalTable: "Cars",
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
                name: "FK_ServiceInterventions_Cars_CarId",
                table: "ServiceInterventions");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceParts_ServiceInterventions_ServiceId",
                table: "ServiceParts");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceRepairs_ServiceInterventions_ServiceId",
                table: "ServiceRepairs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceInterventions",
                table: "ServiceInterventions");

            migrationBuilder.RenameTable(
                name: "ServiceInterventions",
                newName: "ServiceIntervention");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceInterventions_CarId",
                table: "ServiceIntervention",
                newName: "IX_ServiceIntervention_CarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceIntervention",
                table: "ServiceIntervention",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceIntervention_Cars_CarId",
                table: "ServiceIntervention",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
