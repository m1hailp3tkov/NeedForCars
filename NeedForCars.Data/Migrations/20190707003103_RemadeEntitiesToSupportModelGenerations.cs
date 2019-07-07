using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NeedForCars.Data.Migrations
{
    public partial class RemadeEntitiesToSupportModelGenerations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Models_ModelId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_AspNetUsers_OwnerId",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "ModelEngines");

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
                name: "Seats",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "TopSpeed",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "Transmission",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "Acceleration__0_100",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "Acceleration__0_200",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "Acceleration__0_300",
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
                name: "Color",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "ForSale",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "IsPerformanceModified",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "IsVisuallyModified",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Mileage",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "ProductionDate",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "TiresSize",
                table: "Models",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "ModifiedFuelConsumption_Urban",
                table: "Cars",
                newName: "FuelConsumption_Urban");

            migrationBuilder.RenameColumn(
                name: "ModifiedFuelConsumption_ExtraUrban",
                table: "Cars",
                newName: "FuelConsumption_ExtraUrban");

            migrationBuilder.RenameColumn(
                name: "ModifiedFuelConsumption_Combined",
                table: "Cars",
                newName: "FuelConsumption_Combined");

            migrationBuilder.RenameColumn(
                name: "ModifiedAcceleration__0_300",
                table: "Cars",
                newName: "Acceleration__0_300");

            migrationBuilder.RenameColumn(
                name: "ModifiedAcceleration__0_200",
                table: "Cars",
                newName: "Acceleration__0_200");

            migrationBuilder.RenameColumn(
                name: "ModifiedAcceleration__0_100",
                table: "Cars",
                newName: "Acceleration__0_100");

            migrationBuilder.RenameColumn(
                name: "VisualModificationsDescription",
                table: "Cars",
                newName: "TiresSize");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Cars",
                newName: "TopSpeed");

            migrationBuilder.RenameColumn(
                name: "PerformanceModificationsDescription",
                table: "Cars",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Cars",
                newName: "GenerationId");

            migrationBuilder.RenameColumn(
                name: "ModelId",
                table: "Cars",
                newName: "EngineId");

            migrationBuilder.RenameColumn(
                name: "Currency",
                table: "Cars",
                newName: "Seats");

            migrationBuilder.RenameColumn(
                name: "AlternativeFuel",
                table: "Cars",
                newName: "NumberOfGears");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_OwnerId",
                table: "Cars",
                newName: "IX_Cars_GenerationId");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_ModelId",
                table: "Cars",
                newName: "IX_Cars_EngineId");

            migrationBuilder.AddColumn<string>(
                name: "Creator",
                table: "Engines",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "BeginningOfProduction",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BodyType",
                table: "Cars",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DriveWheel",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndOfProduction",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasABS",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasESP",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasTSC",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Transmission",
                table: "Cars",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Generations",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ModelId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Generations_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserCars",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    OwnerId = table.Column<string>(nullable: false),
                    CarId = table.Column<string>(nullable: false),
                    Color = table.Column<string>(nullable: false),
                    ProductionDate = table.Column<DateTime>(nullable: false),
                    Mileage = table.Column<int>(nullable: false),
                    IsPublic = table.Column<bool>(nullable: false),
                    ForSale = table.Column<bool>(nullable: false),
                    IsPerformanceModified = table.Column<bool>(nullable: false),
                    IsVisuallyModified = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    AlternativeFuel = table.Column<int>(nullable: true),
                    Price = table.Column<int>(nullable: true),
                    Currency = table.Column<int>(nullable: true),
                    ModifiedFuelConsumption_Urban = table.Column<decimal>(nullable: true),
                    ModifiedFuelConsumption_ExtraUrban = table.Column<decimal>(nullable: true),
                    ModifiedFuelConsumption_Combined = table.Column<decimal>(nullable: true),
                    ModifiedAcceleration__0_100 = table.Column<decimal>(nullable: true),
                    ModifiedAcceleration__0_200 = table.Column<decimal>(nullable: true),
                    ModifiedAcceleration__0_300 = table.Column<decimal>(nullable: true),
                    PerformanceModificationsDescription = table.Column<string>(nullable: true),
                    VisualModificationsDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCars_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCars_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Generations_ModelId",
                table: "Generations",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCars_CarId",
                table: "UserCars",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCars_OwnerId",
                table: "UserCars",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Engines_EngineId",
                table: "Cars",
                column: "EngineId",
                principalTable: "Engines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Generations_GenerationId",
                table: "Cars",
                column: "GenerationId",
                principalTable: "Generations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Engines_EngineId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Generations_GenerationId",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "Generations");

            migrationBuilder.DropTable(
                name: "UserCars");

            migrationBuilder.DropColumn(
                name: "Creator",
                table: "Engines");

            migrationBuilder.DropColumn(
                name: "BeginningOfProduction",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "BodyType",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "DriveWheel",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "EndOfProduction",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "HasABS",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "HasESP",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "HasTSC",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Transmission",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Models",
                newName: "TiresSize");

            migrationBuilder.RenameColumn(
                name: "FuelConsumption_Urban",
                table: "Cars",
                newName: "ModifiedFuelConsumption_Urban");

            migrationBuilder.RenameColumn(
                name: "FuelConsumption_ExtraUrban",
                table: "Cars",
                newName: "ModifiedFuelConsumption_ExtraUrban");

            migrationBuilder.RenameColumn(
                name: "FuelConsumption_Combined",
                table: "Cars",
                newName: "ModifiedFuelConsumption_Combined");

            migrationBuilder.RenameColumn(
                name: "Acceleration__0_300",
                table: "Cars",
                newName: "ModifiedAcceleration__0_300");

            migrationBuilder.RenameColumn(
                name: "Acceleration__0_200",
                table: "Cars",
                newName: "ModifiedAcceleration__0_200");

            migrationBuilder.RenameColumn(
                name: "Acceleration__0_100",
                table: "Cars",
                newName: "ModifiedAcceleration__0_100");

            migrationBuilder.RenameColumn(
                name: "TopSpeed",
                table: "Cars",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "TiresSize",
                table: "Cars",
                newName: "VisualModificationsDescription");

            migrationBuilder.RenameColumn(
                name: "Seats",
                table: "Cars",
                newName: "Currency");

            migrationBuilder.RenameColumn(
                name: "NumberOfGears",
                table: "Cars",
                newName: "AlternativeFuel");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Cars",
                newName: "PerformanceModificationsDescription");

            migrationBuilder.RenameColumn(
                name: "GenerationId",
                table: "Cars",
                newName: "OwnerId");

            migrationBuilder.RenameColumn(
                name: "EngineId",
                table: "Cars",
                newName: "ModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_GenerationId",
                table: "Cars",
                newName: "IX_Cars_OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_EngineId",
                table: "Cars",
                newName: "IX_Cars_ModelId");

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

            migrationBuilder.AddColumn<int>(
                name: "Seats",
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

            migrationBuilder.AddColumn<decimal>(
                name: "Acceleration__0_100",
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

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Cars",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ForSale",
                table: "Cars",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPerformanceModified",
                table: "Cars",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "Cars",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVisuallyModified",
                table: "Cars",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Mileage",
                table: "Cars",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ProductionDate",
                table: "Cars",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "ModelEngines",
                columns: table => new
                {
                    EngineId = table.Column<string>(nullable: false),
                    ModelId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelEngines", x => new { x.EngineId, x.ModelId });
                    table.ForeignKey(
                        name: "FK_ModelEngines_Engines_EngineId",
                        column: x => x.EngineId,
                        principalTable: "Engines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ModelEngines_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModelEngines_ModelId",
                table: "ModelEngines",
                column: "ModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Models_ModelId",
                table: "Cars",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_AspNetUsers_OwnerId",
                table: "Cars",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
