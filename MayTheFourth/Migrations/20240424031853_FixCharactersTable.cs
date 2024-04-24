using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MayTheFourth.Migrations
{
    /// <inheritdoc />
    public partial class FixCharactersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // https://stackoverflow.com/questions/64670235/ef-core-table-name-already-exists-when-trying-to-update-database
            //    migrationBuilder.CreateTable(
            //        name: "Character",
            //        columns: table => new
            //        {
            //            CharacterId = table.Column<long>(type: "INTEGER", nullable: false)
            //                .Annotation("Sqlite:Autoincrement", true),
            //            name = table.Column<string>(type: "TEXT", nullable: false),
            //            height = table.Column<string>(type: "TEXT", nullable: false),
            //            weight = table.Column<string>(type: "TEXT", nullable: false),
            //            hairColor = table.Column<string>(type: "TEXT", nullable: false),
            //            skinColor = table.Column<string>(type: "TEXT", nullable: false),
            //            eyeColor = table.Column<string>(type: "TEXT", nullable: false),
            //            birthYear = table.Column<string>(type: "TEXT", nullable: false),
            //            gender = table.Column<string>(type: "TEXT", nullable: false),
            //            planet = table.Column<string>(type: "TEXT", nullable: false),
            //            movies = table.Column<string>(type: "TEXT", nullable: false)
            //        },
            //        constraints: table =>
            //        {
            //            table.PrimaryKey("PK_Character", x => x.CharacterId);
            //        });

            //    migrationBuilder.CreateTable(
            //        name: "Planet",
            //        columns: table => new
            //        {
            //            PlanetId = table.Column<long>(type: "INTEGER", nullable: false)
            //                .Annotation("Sqlite:Autoincrement", true),
            //            name = table.Column<string>(type: "TEXT", nullable: false),
            //            rotationPeriod = table.Column<string>(type: "TEXT", nullable: false),
            //            orbitalPeriod = table.Column<string>(type: "TEXT", nullable: false),
            //            diameter = table.Column<string>(type: "TEXT", nullable: false),
            //            climate = table.Column<string>(type: "TEXT", nullable: false),
            //            gravity = table.Column<string>(type: "TEXT", nullable: false),
            //            terrain = table.Column<string>(type: "TEXT", nullable: false),
            //            surfaceWater = table.Column<string>(type: "TEXT", nullable: false),
            //            population = table.Column<string>(type: "TEXT", nullable: false),
            //            characters = table.Column<string>(type: "TEXT", nullable: false),
            //            movies = table.Column<string>(type: "TEXT", nullable: false)
            //        },
            //        constraints: table =>
            //        {
            //            table.PrimaryKey("PK_Planet", x => x.PlanetId);
            //        });

            //    migrationBuilder.CreateTable(
            //        name: "StarShip",
            //        columns: table => new
            //        {
            //            StarShipId = table.Column<long>(type: "INTEGER", nullable: false)
            //                .Annotation("Sqlite:Autoincrement", true),
            //            Name = table.Column<string>(type: "TEXT", nullable: false)
            //        },
            //        constraints: table =>
            //        {
            //            table.PrimaryKey("PK_StarShip", x => x.StarShipId);
            //        });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropTable(
                name: "Planet");

            migrationBuilder.DropTable(
                name: "StarShip");
        }
    }
}
