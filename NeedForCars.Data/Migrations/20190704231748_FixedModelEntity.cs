using Microsoft.EntityFrameworkCore.Migrations;

namespace NeedForCars.Data.Migrations
{
    public partial class FixedModelEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Models_Makes_MakeId1",
                table: "Models");

            migrationBuilder.DropIndex(
                name: "IX_Models_MakeId1",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "MakeId1",
                table: "Models");

            migrationBuilder.AlterColumn<string>(
                name: "MakeId",
                table: "Models",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Models_MakeId",
                table: "Models",
                column: "MakeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Makes_MakeId",
                table: "Models",
                column: "MakeId",
                principalTable: "Makes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Models_Makes_MakeId",
                table: "Models");

            migrationBuilder.DropIndex(
                name: "IX_Models_MakeId",
                table: "Models");

            migrationBuilder.AlterColumn<int>(
                name: "MakeId",
                table: "Models",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "MakeId1",
                table: "Models",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Models_MakeId1",
                table: "Models",
                column: "MakeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Makes_MakeId1",
                table: "Models",
                column: "MakeId1",
                principalTable: "Makes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
