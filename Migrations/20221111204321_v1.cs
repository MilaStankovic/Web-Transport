using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_Transport.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kompanija",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProsecnaZarada = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kompanija", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Vozila",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cena = table.Column<int>(type: "int", nullable: false),
                    TezinaPaketa = table.Column<int>(type: "int", nullable: false),
                    Zapremina = table.Column<int>(type: "int", nullable: false),
                    KompanijaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vozila", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Vozila_Kompanija_KompanijaID",
                        column: x => x.KompanijaID,
                        principalTable: "Kompanija",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Isporuke",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KompanijaID = table.Column<int>(type: "int", nullable: true),
                    PrevozID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Isporuke", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Isporuke_Kompanija_KompanijaID",
                        column: x => x.KompanijaID,
                        principalTable: "Kompanija",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Isporuke_Vozila_PrevozID",
                        column: x => x.PrevozID,
                        principalTable: "Vozila",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Isporuke_KompanijaID",
                table: "Isporuke",
                column: "KompanijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Isporuke_PrevozID",
                table: "Isporuke",
                column: "PrevozID");

            migrationBuilder.CreateIndex(
                name: "IX_Vozila_KompanijaID",
                table: "Vozila",
                column: "KompanijaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Isporuke");

            migrationBuilder.DropTable(
                name: "Vozila");

            migrationBuilder.DropTable(
                name: "Kompanija");
        }
    }
}
