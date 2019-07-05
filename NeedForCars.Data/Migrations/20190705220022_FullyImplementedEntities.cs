using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NeedForCars.Data.Migrations
{
    public partial class FullyImplementedEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BeginningOfProduction",
                table: "Models",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BodyType",
                table: "Models",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DriveWheel",
                table: "Models",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndOfProduction",
                table: "Models",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasABS",
                table: "Models",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasESP",
                table: "Models",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasTSC",
                table: "Models",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfGears",
                table: "Models",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TiresSize",
                table: "Models",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TopSpeed",
                table: "Models",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Transmission",
                table: "Models",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WheelRimsSize",
                table: "Models",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Acceleration__0_200",
                table: "Models",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Acceleration__0_300",
                table: "Models",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Acceleration__O_100",
                table: "Models",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FuelConsumption_Combined",
                table: "Models",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FuelConsumption_ExtraUrban",
                table: "Models",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FuelConsumption_Urban",
                table: "Models",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Aspiration",
                table: "Engines",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CylinderBore",
                table: "Engines",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EngineConfiguration",
                table: "Engines",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxHPAtRpm",
                table: "Engines",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxTorque",
                table: "Engines",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxTorqueAtRpm",
                table: "Engines",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfCylinders",
                table: "Engines",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PistonStroke",
                table: "Engines",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ValvesPerCylinder",
                table: "Engines",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ValvetrainType",
                table: "Engines",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AlternativeFuel",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPerformanceModified",
                table: "Cars",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVisuallyModified",
                table: "Cars",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PerformanceModificationsDescription",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VisualModificationsDescription",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ModifiedAcceleration__0_200",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ModifiedAcceleration__0_300",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ModifiedAcceleration__O_100",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ModifiedFuelConsumption_Combined",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ModifiedFuelConsumption_ExtraUrban",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ModifiedFuelConsumption_Urban",
                table: "Cars",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BeginningOfProduction",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "BodyType",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "DriveWheel",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "EndOfProduction",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "HasABS",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "HasESP",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "HasTSC",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "NumberOfGears",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "TiresSize",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "TopSpeed",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "Transmission",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "WheelRimsSize",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "Acceleration__0_200",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "Acceleration__0_300",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "Acceleration__O_100",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "FuelConsumption_Combined",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "FuelConsumption_ExtraUrban",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "FuelConsumption_Urban",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "Aspiration",
                table: "Engines");

            migrationBuilder.DropColumn(
                name: "CylinderBore",
                table: "Engines");

            migrationBuilder.DropColumn(
                name: "EngineConfiguration",
                table: "Engines");

            migrationBuilder.DropColumn(
                name: "MaxHPAtRpm",
                table: "Engines");

            migrationBuilder.DropColumn(
                name: "MaxTorque",
                table: "Engines");

            migrationBuilder.DropColumn(
                name: "MaxTorqueAtRpm",
                table: "Engines");

            migrationBuilder.DropColumn(
                name: "NumberOfCylinders",
                table: "Engines");

            migrationBuilder.DropColumn(
                name: "PistonStroke",
                table: "Engines");

            migrationBuilder.DropColumn(
                name: "ValvesPerCylinder",
                table: "Engines");

            migrationBuilder.DropColumn(
                name: "ValvetrainType",
                table: "Engines");

            migrationBuilder.DropColumn(
                name: "AlternativeFuel",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "IsPerformanceModified",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "IsVisuallyModified",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "PerformanceModificationsDescription",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "VisualModificationsDescription",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "ModifiedAcceleration__0_200",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "ModifiedAcceleration__0_300",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "ModifiedAcceleration__O_100",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "ModifiedFuelConsumption_Combined",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "ModifiedFuelConsumption_ExtraUrban",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "ModifiedFuelConsumption_Urban",
                table: "Cars");
        }
    }
}
