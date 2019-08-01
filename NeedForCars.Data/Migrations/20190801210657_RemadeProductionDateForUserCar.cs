using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NeedForCars.Data.Migrations
{
    public partial class RemadeProductionDateForUserCar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductionDate",
                table: "UserCars");

            migrationBuilder.AddColumn<int>(
                name: "ProductionDateMonth",
                table: "UserCars",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductionDateYear",
                table: "UserCars",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductionDateMonth",
                table: "UserCars");

            migrationBuilder.DropColumn(
                name: "ProductionDateYear",
                table: "UserCars");

            migrationBuilder.AddColumn<DateTime>(
                name: "ProductionDate",
                table: "UserCars",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
