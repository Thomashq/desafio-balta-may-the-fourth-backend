using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MayTheFourth.Migrations
{
    /// <inheritdoc />
    public partial class AddPlanetModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Planet",
                columns: table => new
                {
                    PlanetId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    RotationPeriod = table.Column<string>(type: "TEXT", nullable: false),
                    OrbitalPeriod = table.Column<string>(type: "TEXT", nullable: false),
                    Diameter = table.Column<string>(type: "TEXT", nullable: false),
                    Climate = table.Column<string>(type: "TEXT", nullable: false),
                    Gravity = table.Column<string>(type: "TEXT", nullable: false),
                    Terrain = table.Column<string>(type: "TEXT", nullable: false),
                    SurfaceWater = table.Column<string>(type: "TEXT", nullable: false),
                    Population = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planet", x => x.PlanetId);
                });

            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    CharacterId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlanetId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.CharacterId);
                    table.ForeignKey(
                        name: "FK_Character_Planet_PlanetId",
                        column: x => x.PlanetId,
                        principalTable: "Planet",
                        principalColumn: "PlanetId");
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    MovieId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlanetId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.MovieId);
                    table.ForeignKey(
                        name: "FK_Movie_Planet_PlanetId",
                        column: x => x.PlanetId,
                        principalTable: "Planet",
                        principalColumn: "PlanetId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Character_PlanetId",
                table: "Character",
                column: "PlanetId");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_PlanetId",
                table: "Movie",
                column: "PlanetId");
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
        }
    }
}
