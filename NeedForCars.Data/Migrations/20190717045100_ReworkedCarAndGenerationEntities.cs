using Microsoft.EntityFrameworkCore.Migrations;

namespace NeedForCars.Data.Migrations
{
    public partial class ReworkedCarAndGenerationEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BodyType",
                table: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "BodyType",
                table: "Generations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Transmission",
                table: "Cars",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DriveWheel",
                table: "Cars",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BodyType",
                table: "Generations");

            migrationBuilder.AlterColumn<int>(
                name: "Transmission",
                table: "Cars",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "DriveWheel",
                table: "Cars",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "BodyType",
                table: "Cars",
                nullable: false,
                defaultValue: 0);
        }
    }
}
