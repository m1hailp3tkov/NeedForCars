using Microsoft.EntityFrameworkCore.Migrations;

namespace NeedForCars.Data.Migrations
{
    public partial class FixedAccelerationModelTypo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Acceleration__O_100",
                table: "Models",
                newName: "Acceleration__0_100");

            migrationBuilder.RenameColumn(
                name: "ModifiedAcceleration__O_100",
                table: "Cars",
                newName: "ModifiedAcceleration__0_100");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Acceleration__0_100",
                table: "Models",
                newName: "Acceleration__O_100");

            migrationBuilder.RenameColumn(
                name: "ModifiedAcceleration__0_100",
                table: "Cars",
                newName: "ModifiedAcceleration__O_100");
        }
    }
}
