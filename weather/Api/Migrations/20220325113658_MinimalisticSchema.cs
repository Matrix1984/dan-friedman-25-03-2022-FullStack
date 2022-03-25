using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    public partial class MinimalisticSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Favourites_FavouriteId",
                table: "Cities");

            migrationBuilder.DropTable(
                name: "Favourites");

            migrationBuilder.DropTable(
                name: "Weathers");

            migrationBuilder.DropIndex(
                name: "IX_Cities_FavouriteId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "FavouriteId",
                table: "Cities");

            migrationBuilder.AddColumn<decimal>(
                name: "CelsiusTemperature",
                table: "Cities",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "CityKey",
                table: "Cities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsFavourite",
                table: "Cities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "WeatherText",
                table: "Cities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CelsiusTemperature",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "CityKey",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "IsFavourite",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "WeatherText",
                table: "Cities");

            migrationBuilder.AddColumn<int>(
                name: "FavouriteId",
                table: "Cities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Favourites",
                columns: table => new
                {
                    FavouriteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favourites", x => x.FavouriteId);
                });

            migrationBuilder.CreateTable(
                name: "Weathers",
                columns: table => new
                {
                    WeatherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    CelsiusTemperature = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WeatherText = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weathers", x => x.WeatherId);
                    table.ForeignKey(
                        name: "FK_Weathers_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_FavouriteId",
                table: "Cities",
                column: "FavouriteId");

            migrationBuilder.CreateIndex(
                name: "IX_Weathers_CityId",
                table: "Weathers",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Favourites_FavouriteId",
                table: "Cities",
                column: "FavouriteId",
                principalTable: "Favourites",
                principalColumn: "FavouriteId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
