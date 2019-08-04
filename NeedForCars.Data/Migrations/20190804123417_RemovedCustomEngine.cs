using Microsoft.EntityFrameworkCore.Migrations;

namespace NeedForCars.Data.Migrations
{
    public partial class RemovedCustomEngine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCars_Engines_CustomEngineId",
                table: "UserCars");

            migrationBuilder.DropIndex(
                name: "IX_UserCars_CustomEngineId",
                table: "UserCars");

            migrationBuilder.RenameColumn(
                name: "CustomEngineId",
                table: "UserCars",
                newName: "CustomMaxHP");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomMaxHP",
                table: "UserCars",
                newName: "CustomEngineId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCars_CustomEngineId",
                table: "UserCars",
                column: "CustomEngineId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCars_Engines_CustomEngineId",
                table: "UserCars",
                column: "CustomEngineId",
                principalTable: "Engines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
