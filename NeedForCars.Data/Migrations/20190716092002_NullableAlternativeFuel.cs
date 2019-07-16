using Microsoft.EntityFrameworkCore.Migrations;

namespace NeedForCars.Data.Migrations
{
    public partial class NullableAlternativeFuel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AlternativeFuel",
                table: "Engines",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AlternativeFuel",
                table: "Engines",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
