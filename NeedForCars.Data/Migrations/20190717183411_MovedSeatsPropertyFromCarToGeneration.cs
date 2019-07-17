using Microsoft.EntityFrameworkCore.Migrations;

namespace NeedForCars.Data.Migrations
{
    public partial class MovedSeatsPropertyFromCarToGeneration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Seats",
                table: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "Seats",
                table: "Generations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Seats",
                table: "Generations");

            migrationBuilder.AddColumn<int>(
                name: "Seats",
                table: "Cars",
                nullable: true);
        }
    }
}
