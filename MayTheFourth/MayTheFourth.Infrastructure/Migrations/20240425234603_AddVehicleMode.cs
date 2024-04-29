using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MayTheFourth.Migrations
{
  /// <inheritdoc />
  public partial class AddVehicleMode : Migration
  {
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
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
          name: "Vehicle");
    }
  }
}
