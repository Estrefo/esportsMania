using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace esportsMania.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Juegos",
                columns: table => new
                {
                    IdJuego = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreJuego = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Juegos", x => x.IdJuego);
                });

            migrationBuilder.CreateTable(
                name: "Ganadores",
                columns: table => new
                {
                    IdGanador = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreGanador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Puntos = table.Column<int>(type: "int", nullable: false),
                    IdJuego = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ganadores", x => x.IdGanador);
                    table.ForeignKey(
                        name: "FK_Ganadores_Juegos_IdJuego",
                        column: x => x.IdJuego,
                        principalTable: "Juegos",
                        principalColumn: "IdJuego",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Jugadores",
                columns: table => new
                {
                    IdJugador = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FotoJugador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kills = table.Column<int>(type: "int", nullable: false),
                    Muertes = table.Column<int>(type: "int", nullable: false),
                    Asistencias = table.Column<int>(type: "int", nullable: false),
                    IdJuego = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jugadores", x => x.IdJugador);
                    table.ForeignKey(
                        name: "FK_Jugadores_Juegos_IdJuego",
                        column: x => x.IdJuego,
                        principalTable: "Juegos",
                        principalColumn: "IdJuego",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ganadores_IdJuego",
                table: "Ganadores",
                column: "IdJuego");

            migrationBuilder.CreateIndex(
                name: "IX_Jugadores_IdJuego",
                table: "Jugadores",
                column: "IdJuego");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ganadores");

            migrationBuilder.DropTable(
                name: "Jugadores");

            migrationBuilder.DropTable(
                name: "Juegos");
        }
    }
}
