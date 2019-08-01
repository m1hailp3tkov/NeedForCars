using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NeedForCars.Data.Migrations
{
    public partial class RemadeProductionDatesForCars : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BeginningOfProduction",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "EndOfProduction",
                table: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "BeginningOfProductionMonth",
                table: "Cars",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BeginningOfProductionYear",
                table: "Cars",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EndOfProductionMonth",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EndOfProductionYear",
                table: "Cars",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BeginningOfProductionMonth",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "BeginningOfProductionYear",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "EndOfProductionMonth",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "EndOfProductionYear",
                table: "Cars");

            migrationBuilder.AddColumn<DateTime>(
                name: "BeginningOfProduction",
                table: "Cars",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EndOfProduction",
                table: "Cars",
                nullable: true);
        }
    }
}
