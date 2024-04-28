using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MayTheFourth.Migrations
{
    /// <inheritdoc />
    public partial class ChangePlanetModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Terrain",
                table: "Planet",
                newName: "terrain");

            migrationBuilder.RenameColumn(
                name: "SurfaceWater",
                table: "Planet",
                newName: "surfaceWater");

            migrationBuilder.RenameColumn(
                name: "RotationPeriod",
                table: "Planet",
                newName: "rotationPeriod");

            migrationBuilder.RenameColumn(
                name: "Population",
                table: "Planet",
                newName: "population");

            migrationBuilder.RenameColumn(
                name: "OrbitalPeriod",
                table: "Planet",
                newName: "orbitalPeriod");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Planet",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Gravity",
                table: "Planet",
                newName: "gravity");

            migrationBuilder.RenameColumn(
                name: "Diameter",
                table: "Planet",
                newName: "diameter");

            migrationBuilder.RenameColumn(
                name: "Climate",
                table: "Planet",
                newName: "climate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "terrain",
                table: "Planet",
                newName: "Terrain");

            migrationBuilder.RenameColumn(
                name: "surfaceWater",
                table: "Planet",
                newName: "SurfaceWater");

            migrationBuilder.RenameColumn(
                name: "rotationPeriod",
                table: "Planet",
                newName: "RotationPeriod");

            migrationBuilder.RenameColumn(
                name: "population",
                table: "Planet",
                newName: "Population");

            migrationBuilder.RenameColumn(
                name: "orbitalPeriod",
                table: "Planet",
                newName: "OrbitalPeriod");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Planet",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "gravity",
                table: "Planet",
                newName: "Gravity");

            migrationBuilder.RenameColumn(
                name: "diameter",
                table: "Planet",
                newName: "Diameter");

            migrationBuilder.RenameColumn(
                name: "climate",
                table: "Planet",
                newName: "Climate");
        }
    }
}
