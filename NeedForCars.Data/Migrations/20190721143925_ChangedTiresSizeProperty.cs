using Microsoft.EntityFrameworkCore.Migrations;

namespace NeedForCars.Data.Migrations
{
    public partial class ChangedTiresSizeProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TiresSize",
                table: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "TireInfo_AspectRatio",
                table: "Cars",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TireInfo_TireWidth",
                table: "Cars",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TireInfo_WheelDiameter",
                table: "Cars",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TireInfo_AspectRatio",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "TireInfo_TireWidth",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "TireInfo_WheelDiameter",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "TiresSize",
                table: "Cars",
                nullable: true);
        }
    }
}
