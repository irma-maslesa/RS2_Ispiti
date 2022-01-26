using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eProdaja.Migrations
{
    public partial class ProizvodKomentari : Migration
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
                name: "ProizvodKomentari",
                columns: table => new
                {
                    ProizvodKomentarID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProizvodID = table.Column<int>(type: "int", nullable: false),
                    KupacID = table.Column<int>(type: "int", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Komentar = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProizvodKomentari", x => x.ProizvodKomentarID);
                    table.ForeignKey(
                        name: "FK_ProizvodKomentari_Kupci",
                        column: x => x.KupacID,
                        principalTable: "Kupci",
                        principalColumn: "KupacID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProizvodKomentari_Proizvodi",
                        column: x => x.ProizvodID,
                        principalTable: "Proizvodi",
                        principalColumn: "ProizvodID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "CS_Email",
                table: "Korisnici",
                column: "Email",
                unique: true,
                filter: "([Email] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_ProizvodKomentari_KupacID",
                table: "ProizvodKomentari",
                column: "KupacID");

            migrationBuilder.CreateIndex(
                name: "IX_ProizvodKomentari_ProizvodID",
                table: "ProizvodKomentari",
                column: "ProizvodID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProizvodKomentari");

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
