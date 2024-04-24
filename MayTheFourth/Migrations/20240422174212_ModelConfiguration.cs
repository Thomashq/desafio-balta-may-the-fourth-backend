using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MayTheFourth.Migrations
{
    /// <inheritdoc />
    public partial class ModelConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "StarShip",
                newName: "name");

            migrationBuilder.AddColumn<string>(
                name: "cargoCapacity",
                table: "StarShip",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "class",
                table: "StarShip",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "consumables",
                table: "StarShip",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "costInCredits",
                table: "StarShip",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "crew",
                table: "StarShip",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "hyperdriveRating",
                table: "StarShip",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "length",
                table: "StarShip",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "manufacturer",
                table: "StarShip",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "maxSpeed",
                table: "StarShip",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "mglt",
                table: "StarShip",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "model",
                table: "StarShip",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "passangers",
                table: "StarShip",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    MovieId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.MovieId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropColumn(
                name: "cargoCapacity",
                table: "StarShip");

            migrationBuilder.DropColumn(
                name: "class",
                table: "StarShip");

            migrationBuilder.DropColumn(
                name: "consumables",
                table: "StarShip");

            migrationBuilder.DropColumn(
                name: "costInCredits",
                table: "StarShip");

            migrationBuilder.DropColumn(
                name: "crew",
                table: "StarShip");

            migrationBuilder.DropColumn(
                name: "hyperdriveRating",
                table: "StarShip");

            migrationBuilder.DropColumn(
                name: "length",
                table: "StarShip");

            migrationBuilder.DropColumn(
                name: "manufacturer",
                table: "StarShip");

            migrationBuilder.DropColumn(
                name: "maxSpeed",
                table: "StarShip");

            migrationBuilder.DropColumn(
                name: "mglt",
                table: "StarShip");

            migrationBuilder.DropColumn(
                name: "model",
                table: "StarShip");

            migrationBuilder.DropColumn(
                name: "passangers",
                table: "StarShip");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "StarShip",
                newName: "Name");
        }
    }
}
