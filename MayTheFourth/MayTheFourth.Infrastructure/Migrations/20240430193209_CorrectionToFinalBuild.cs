using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MayTheFourth.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CorrectionToFinalBuild : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    CharacterId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    height = table.Column<string>(type: "TEXT", nullable: false),
                    weight = table.Column<string>(type: "TEXT", nullable: false),
                    hairColor = table.Column<string>(type: "TEXT", nullable: false),
                    skinColor = table.Column<string>(type: "TEXT", nullable: false),
                    eyeColor = table.Column<string>(type: "TEXT", nullable: false),
                    birthYear = table.Column<string>(type: "TEXT", nullable: false),
                    gender = table.Column<string>(type: "TEXT", nullable: false),
                    planet = table.Column<string>(type: "TEXT", nullable: false),
                    movies = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.CharacterId);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    MovieId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    title = table.Column<string>(type: "TEXT", nullable: true),
                    episode = table.Column<int>(type: "INTEGER", nullable: false),
                    openingCrawl = table.Column<string>(type: "TEXT", nullable: true),
                    director = table.Column<string>(type: "TEXT", nullable: true),
                    producer = table.Column<string>(type: "TEXT", nullable: true),
                    releaseDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    characters = table.Column<string>(type: "TEXT", nullable: true),
                    planets = table.Column<string>(type: "TEXT", nullable: false),
                    vehicles = table.Column<string>(type: "TEXT", nullable: false),
                    starShips = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.MovieId);
                });

            migrationBuilder.CreateTable(
                name: "Planet",
                columns: table => new
                {
                    PlanetId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    rotationPeriod = table.Column<string>(type: "TEXT", nullable: false),
                    orbitalPeriod = table.Column<string>(type: "TEXT", nullable: false),
                    diameter = table.Column<string>(type: "TEXT", nullable: false),
                    climate = table.Column<string>(type: "TEXT", nullable: false),
                    gravity = table.Column<string>(type: "TEXT", nullable: false),
                    terrain = table.Column<string>(type: "TEXT", nullable: false),
                    surfaceWater = table.Column<string>(type: "TEXT", nullable: false),
                    population = table.Column<string>(type: "TEXT", nullable: false),
                    characters = table.Column<string>(type: "TEXT", nullable: false),
                    movies = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planet", x => x.PlanetId);
                });

            migrationBuilder.CreateTable(
                name: "StarShip",
                columns: table => new
                {
                    StarShipId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    model = table.Column<string>(type: "TEXT", nullable: false),
                    manufacturer = table.Column<string>(type: "TEXT", nullable: false),
                    costInCredits = table.Column<long>(type: "INTEGER", nullable: false),
                    length = table.Column<string>(type: "TEXT", nullable: false),
                    maxSpeed = table.Column<string>(type: "TEXT", nullable: false),
                    crew = table.Column<int>(type: "INTEGER", nullable: false),
                    passangers = table.Column<int>(type: "INTEGER", nullable: false),
                    cargoCapacity = table.Column<string>(type: "TEXT", nullable: false),
                    hyperdriveRating = table.Column<double>(type: "REAL", nullable: false),
                    mglt = table.Column<double>(type: "REAL", nullable: false),
                    consumables = table.Column<string>(type: "TEXT", nullable: false),
                    @class = table.Column<string>(name: "class", type: "TEXT", nullable: false),
                    movies = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StarShip", x => x.StarShipId);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    VehicleId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    cargoCapacity = table.Column<string>(type: "TEXT", nullable: false),
                    passangers = table.Column<int>(type: "INTEGER", nullable: false),
                    crew = table.Column<int>(type: "INTEGER", nullable: false),
                    maxSpeed = table.Column<string>(type: "TEXT", nullable: false),
                    length = table.Column<string>(type: "TEXT", nullable: false),
                    costInCredits = table.Column<double>(type: "REAL", nullable: false),
                    manufacturer = table.Column<string>(type: "TEXT", nullable: false),
                    model = table.Column<int>(type: "INTEGER", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    consumables = table.Column<string>(type: "TEXT", nullable: false),
                    movies = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.VehicleId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropTable(
                name: "Planet");

            migrationBuilder.DropTable(
                name: "StarShip");

            migrationBuilder.DropTable(
                name: "Vehicle");
        }
    }
}
