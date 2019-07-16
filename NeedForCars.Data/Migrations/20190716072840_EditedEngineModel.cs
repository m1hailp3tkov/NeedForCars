using Microsoft.EntityFrameworkCore.Migrations;

namespace NeedForCars.Data.Migrations
{
    public partial class EditedEngineModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Creator",
                table: "Engines",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "CreatorInfoUrl",
                table: "Engines",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatorInfoUrl",
                table: "Engines");

            migrationBuilder.AlterColumn<string>(
                name: "Creator",
                table: "Engines",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
