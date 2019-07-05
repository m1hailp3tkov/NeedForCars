﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NeedForCars.Data;

namespace NeedForCars.Data.Migrations
{
    [DbContext(typeof(NeedForCarsDbContext))]
    [Migration("20190705223322_AddedValidationToEntities")]
    partial class AddedValidationToEntities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("NeedForCars.Models.Car", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AlternativeFuel");

                    b.Property<string>("Color")
                        .IsRequired();

                    b.Property<int?>("Currency");

                    b.Property<string>("Description");

                    b.Property<bool>("ForSale");

                    b.Property<bool>("IsPerformanceModified");

                    b.Property<bool>("IsPublic");

                    b.Property<bool>("IsVisuallyModified");

                    b.Property<int>("Mileage");

                    b.Property<string>("ModelId")
                        .IsRequired();

                    b.Property<string>("OwnerId")
                        .IsRequired();

                    b.Property<string>("PerformanceModificationsDescription");

                    b.Property<int?>("Price");

                    b.Property<DateTime>("ProductionDate");

                    b.Property<string>("VisualModificationsDescription");

                    b.HasKey("Id");

                    b.HasIndex("ModelId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("NeedForCars.Models.Engine", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Aspiration");

                    b.Property<decimal?>("CylinderBore");

                    b.Property<string>("Description");

                    b.Property<int?>("Displacement");

                    b.Property<int?>("EngineConfiguration");

                    b.Property<int>("FuelType");

                    b.Property<int>("MaxHP");

                    b.Property<int?>("MaxHPAtRpm");

                    b.Property<int?>("MaxTorque");

                    b.Property<int?>("MaxTorqueAtRpm");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int?>("NumberOfCylinders");

                    b.Property<decimal?>("PistonStroke");

                    b.Property<int?>("ValvesPerCylinder");

                    b.Property<int?>("ValvetrainType");

                    b.HasKey("Id");

                    b.ToTable("Engines");
                });

            modelBuilder.Entity("NeedForCars.Models.Make", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Makes");
                });

            modelBuilder.Entity("NeedForCars.Models.Message", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<bool>("Read");

                    b.Property<string>("ReceiverId")
                        .IsRequired();

                    b.Property<string>("SenderId")
                        .IsRequired();

                    b.Property<DateTime>("SentOn");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("NeedForCars.Models.Model", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("BeginningOfProduction");

                    b.Property<int>("BodyType");

                    b.Property<int?>("DriveWheel");

                    b.Property<DateTime?>("EndOfProduction");

                    b.Property<bool?>("HasABS");

                    b.Property<bool?>("HasESP");

                    b.Property<bool?>("HasTSC");

                    b.Property<string>("MakeId")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int?>("NumberOfGears");

                    b.Property<int?>("Seats");

                    b.Property<string>("TiresSize");

                    b.Property<int?>("TopSpeed");

                    b.Property<int?>("Transmission");

                    b.HasKey("Id");

                    b.HasIndex("MakeId");

                    b.ToTable("Models");
                });

            modelBuilder.Entity("NeedForCars.Models.ModelEngines", b =>
                {
                    b.Property<string>("EngineId");

                    b.Property<string>("ModelId");

                    b.HasKey("EngineId", "ModelId");

                    b.HasIndex("ModelId");

                    b.ToTable("ModelEngines");
                });

            modelBuilder.Entity("NeedForCars.Models.NeedForCarsUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("NeedForCars.Models.NeedForCarsUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("NeedForCars.Models.NeedForCarsUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NeedForCars.Models.NeedForCarsUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("NeedForCars.Models.NeedForCarsUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NeedForCars.Models.Car", b =>
                {
                    b.HasOne("NeedForCars.Models.Model", "Model")
                        .WithMany()
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NeedForCars.Models.NeedForCarsUser", "Owner")
                        .WithMany("Cars")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("NeedForCars.Models.Owned.Acceleration", "ModifiedAcceleration", b1 =>
                        {
                            b1.Property<string>("CarId");

                            b1.Property<decimal?>("_0_200");

                            b1.Property<decimal?>("_0_300");

                            b1.Property<decimal?>("_O_100");

                            b1.HasKey("CarId");

                            b1.ToTable("Cars");

                            b1.HasOne("NeedForCars.Models.Car")
                                .WithOne("ModifiedAcceleration")
                                .HasForeignKey("NeedForCars.Models.Owned.Acceleration", "CarId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("NeedForCars.Models.Owned.FuelConsumption", "ModifiedFuelConsumption", b1 =>
                        {
                            b1.Property<string>("CarId");

                            b1.Property<decimal?>("Combined");

                            b1.Property<decimal?>("ExtraUrban");

                            b1.Property<decimal?>("Urban");

                            b1.HasKey("CarId");

                            b1.ToTable("Cars");

                            b1.HasOne("NeedForCars.Models.Car")
                                .WithOne("ModifiedFuelConsumption")
                                .HasForeignKey("NeedForCars.Models.Owned.FuelConsumption", "CarId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("NeedForCars.Models.Message", b =>
                {
                    b.HasOne("NeedForCars.Models.NeedForCarsUser", "Receiver")
                        .WithMany("SentMessages")
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("NeedForCars.Models.NeedForCarsUser", "Sender")
                        .WithMany("ReceivedMessages")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("NeedForCars.Models.Model", b =>
                {
                    b.HasOne("NeedForCars.Models.Make", "Make")
                        .WithMany("Models")
                        .HasForeignKey("MakeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("NeedForCars.Models.Owned.Acceleration", "Acceleration", b1 =>
                        {
                            b1.Property<string>("ModelId");

                            b1.Property<decimal?>("_0_200");

                            b1.Property<decimal?>("_0_300");

                            b1.Property<decimal?>("_O_100");

                            b1.HasKey("ModelId");

                            b1.ToTable("Models");

                            b1.HasOne("NeedForCars.Models.Model")
                                .WithOne("Acceleration")
                                .HasForeignKey("NeedForCars.Models.Owned.Acceleration", "ModelId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("NeedForCars.Models.Owned.FuelConsumption", "FuelConsumption", b1 =>
                        {
                            b1.Property<string>("ModelId");

                            b1.Property<decimal?>("Combined");

                            b1.Property<decimal?>("ExtraUrban");

                            b1.Property<decimal?>("Urban");

                            b1.HasKey("ModelId");

                            b1.ToTable("Models");

                            b1.HasOne("NeedForCars.Models.Model")
                                .WithOne("FuelConsumption")
                                .HasForeignKey("NeedForCars.Models.Owned.FuelConsumption", "ModelId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("NeedForCars.Models.ModelEngines", b =>
                {
                    b.HasOne("NeedForCars.Models.Engine", "Engine")
                        .WithMany("ModelEngines")
                        .HasForeignKey("EngineId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("NeedForCars.Models.Model", "Model")
                        .WithMany("ModelEngines")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
