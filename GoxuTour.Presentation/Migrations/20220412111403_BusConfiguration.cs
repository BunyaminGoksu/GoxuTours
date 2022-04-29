using Microsoft.EntityFrameworkCore.Migrations;

namespace GoxuTour.Persistence.Migrations
{
    public partial class BusConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "buses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusModelId = table.Column<int>(type: "int", nullable: false),
                    RegistrationPlate = table.Column<string>(type: "varchar(50)", nullable: false),
                    Year = table.Column<short>(type: "smallint", nullable: false),
                    SeatMapping = table.Column<int>(type: "int", nullable: false),
                    DistanceTraveled = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_buses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_buses_busModels_BusModelId",
                        column: x => x.BusModelId,
                        principalTable: "busModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "buses",
                columns: new[] { "Id", "BusModelId", "DistanceTraveled", "RegistrationPlate", "SeatMapping", "Year" },
                values: new object[,]
                {
                    { 1, 2, 600, "34 GRB 22", 1, (short)1998 },
                    { 2, 2, 600, "34 LTF 22", 3, (short)1999 },
                    { 3, 2, 600, "34 KAYA 22", 2, (short)1997 },
                    { 4, 2, 600, "34 GKS 22", 2, (short)1998 },
                    { 5, 2, 600, "34 UMT 22", 3, (short)1994 },
                    { 6, 2, 600, "34 EMRE 22", 1, (short)1984 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_buses_BusModelId",
                table: "buses",
                column: "BusModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "buses");
        }
    }
}
