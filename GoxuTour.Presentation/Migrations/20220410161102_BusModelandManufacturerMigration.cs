using Microsoft.EntityFrameworkCore.Migrations;

namespace GoxuTour.Persistence.Migrations
{
    public partial class BusModelandManufacturerMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "busManufacturers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_busManufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "busModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    BusManufacturerId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    SeatCapacity = table.Column<int>(type: "int", nullable: false),
                    HasToilet = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_busModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_busModels_busManufacturers_BusManufacturerId",
                        column: x => x.BusManufacturerId,
                        principalTable: "busManufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "busManufacturers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Mercedes" },
                    { 2, "Wolksvagen" },
                    { 3, "BMW" },
                    { 4, "FIAT" },
                    { 5, "MAN" }
                });

            migrationBuilder.InsertData(
                table: "busModels",
                columns: new[] { "Id", "BusManufacturerId", "HasToilet", "Name", "SeatCapacity", "Type" },
                values: new object[,]
                {
                    { 1, 1, true, "Travego", 44, 2 },
                    { 2, 2, true, "Neoplan", 44, 2 },
                    { 3, 3, false, "Connecto", 44, 2 },
                    { 4, 4, true, "Travego", 44, 2 },
                    { 5, 5, false, "Travego", 44, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_busModels_BusManufacturerId",
                table: "busModels",
                column: "BusManufacturerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "busModels");

            migrationBuilder.DropTable(
                name: "busManufacturers");
        }
    }
}
