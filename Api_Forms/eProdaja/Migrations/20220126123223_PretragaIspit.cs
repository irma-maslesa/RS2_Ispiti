using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eProdaja.Migrations
{
    public partial class PretragaIspit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "CS_Email",
                table: "Korisnici");

            migrationBuilder.DeleteData(
                table: "VrsteProizvoda",
                keyColumn: "VrstaID",
                keyValue: 20);

            migrationBuilder.CreateTable(
                name: "PretragaIspit",
                columns: table => new
                {
                    PretragaIspitID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VrstaProizvodaID = table.Column<int>(type: "int", nullable: false),
                    KorisnikID = table.Column<int>(type: "int", nullable: false),
                    MinIznos = table.Column<double>(type: "float", nullable: false),
                    DatumOd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DaumDo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Iznos = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PretragaIspit", x => x.PretragaIspitID);
                    table.ForeignKey(
                        name: "FK_PretragaIspit_Korisnici",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnici",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PretragaIspit_VrsteProizvoda",
                        column: x => x.VrstaProizvodaID,
                        principalTable: "VrsteProizvoda",
                        principalColumn: "VrstaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "CS_Email",
                table: "Korisnici",
                column: "Email",
                unique: true,
                filter: "([Email] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_PretragaIspit_KorisnikID",
                table: "PretragaIspit",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_PretragaIspit_VrstaProizvodaID",
                table: "PretragaIspit",
                column: "VrstaProizvodaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PretragaIspit");

            migrationBuilder.DropIndex(
                name: "CS_Email",
                table: "Korisnici");

            migrationBuilder.InsertData(
                table: "VrsteProizvoda",
                columns: new[] { "VrstaID", "Naziv" },
                values: new object[] { 20, "Prehrambeni" });

            migrationBuilder.CreateIndex(
                name: "CS_Email",
                table: "Korisnici",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");
        }
    }
}
