﻿// <auto-generated />
using System;
using MayTheFourth.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MayTheFourth.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240430230114_FinalTestingBuild")]
    partial class FinalTestingBuild
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("MayTheFourth.Models.Character", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("CharacterId");

                    b.Property<string>("BirthYear")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("birthYear");

                    b.Property<string>("EyeColor")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("eyeColor");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("gender");

                    b.Property<string>("HairColor")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("hairColor");

                    b.Property<string>("Height")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("height");

                    b.Property<string>("Movies")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("movies");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.Property<string>("Planet")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("planet");

                    b.Property<string>("SkinColor")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("skinColor");

                    b.Property<string>("Weight")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("weight");

                    b.HasKey("Id");

                    b.ToTable("Character");
                });

            modelBuilder.Entity("MayTheFourth.Models.Movie", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("MovieId");

                    b.Property<string>("Characters")
                        .HasColumnType("TEXT")
                        .HasColumnName("characters");

                    b.Property<string>("Director")
                        .HasColumnType("TEXT")
                        .HasColumnName("director");

                    b.Property<int>("Episode")
                        .HasColumnType("INTEGER")
                        .HasColumnName("episode");

                    b.Property<string>("OpeningCrawl")
                        .HasColumnType("TEXT")
                        .HasColumnName("openingCrawl");

                    b.Property<string>("Planets")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("planets");

                    b.Property<string>("Producer")
                        .HasColumnType("TEXT")
                        .HasColumnName("producer");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("TEXT")
                        .HasColumnName("releaseDate");

                    b.Property<string>("StarShips")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("starShips");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT")
                        .HasColumnName("title");

                    b.Property<string>("Vehicles")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("vehicles");

                    b.HasKey("Id");

                    b.ToTable("Movie");
                });

            modelBuilder.Entity("MayTheFourth.Models.Planet", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("PlanetId");

                    b.Property<string>("Characters")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("characters");

                    b.Property<string>("Climate")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("climate");

                    b.Property<string>("Diameter")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("diameter");

                    b.Property<string>("Gravity")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("gravity");

                    b.Property<string>("Movies")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("movies");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.Property<string>("OrbitalPeriod")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("orbitalPeriod");

                    b.Property<string>("Population")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("population");

                    b.Property<string>("RotationPeriod")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("rotationPeriod");

                    b.Property<string>("SurfaceWater")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("surfaceWater");

                    b.Property<string>("Terrain")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("terrain");

                    b.HasKey("Id");

                    b.ToTable("Planet");
                });

            modelBuilder.Entity("MayTheFourth.Models.StarShip", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("StarShipId");

                    b.Property<string>("CargoCapacity")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("cargoCapacity");

                    b.Property<string>("Class")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("class");

                    b.Property<string>("Consumables")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("consumables");

                    b.Property<long>("CostInCredits")
                        .HasColumnType("INTEGER")
                        .HasColumnName("costInCredits");

                    b.Property<int>("Crew")
                        .HasColumnType("INTEGER")
                        .HasColumnName("crew");

                    b.Property<double>("HyperdriveRating")
                        .HasColumnType("REAL")
                        .HasColumnName("hyperdriveRating");

                    b.Property<string>("Length")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("length");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("manufacturer");

                    b.Property<string>("MaxSpeed")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("maxSpeed");

                    b.Property<double>("Mglt")
                        .HasColumnType("REAL")
                        .HasColumnName("mglt");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("model");

                    b.Property<string>("Movies")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("movies");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.Property<int>("Passangers")
                        .HasColumnType("INTEGER")
                        .HasColumnName("passangers");

                    b.HasKey("Id");

                    b.ToTable("StarShip");
                });

            modelBuilder.Entity("MayTheFourth.Models.Vehicle", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("VehicleId");

                    b.Property<string>("CargoCapacity")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("cargoCapacity");

                    b.Property<string>("Consumables")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("consumables");

                    b.Property<double>("CostInCredits")
                        .HasColumnType("REAL")
                        .HasColumnName("costInCredits");

                    b.Property<int>("Crew")
                        .HasColumnType("INTEGER")
                        .HasColumnName("crew");

                    b.Property<string>("Length")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("length");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("manufacturer");

                    b.Property<string>("MaxSpeed")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("maxSpeed");

                    b.Property<int>("Model")
                        .HasColumnType("INTEGER")
                        .HasColumnName("model");

                    b.Property<string>("Movies")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("movies");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.Property<int>("Passangers")
                        .HasColumnType("INTEGER")
                        .HasColumnName("passangers");

                    b.HasKey("Id");

                    b.ToTable("Vehicle");
                });
#pragma warning restore 612, 618
        }
    }
}
