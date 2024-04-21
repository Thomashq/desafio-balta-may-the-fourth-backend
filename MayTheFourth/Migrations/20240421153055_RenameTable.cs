using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MayTheFourth.Migrations
{
    /// <inheritdoc />
    public partial class RenameTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StarShips",
                table: "StarShips");

            migrationBuilder.RenameTable(
                name: "StarShips",
                newName: "StarShip");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StarShip",
                table: "StarShip",
                column: "StarShipId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StarShip",
                table: "StarShip");

            migrationBuilder.RenameTable(
                name: "StarShip",
                newName: "StarShips");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StarShips",
                table: "StarShips",
                column: "StarShipId");
        }
    }
}
