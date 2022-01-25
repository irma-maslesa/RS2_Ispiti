using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eProdaja.Migrations
{
    public partial class CovidPasos : Migration
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
                name: "CovidPasosi",
                columns: table => new
                {
                    CovidPasosId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KupacId = table.Column<int>(type: "int", nullable: true),
                    DatumIzdavanja = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DatumVazenja = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CovidPasosi", x => x.CovidPasosId);
                    table.ForeignKey(
                        name: "FK_CovidPasosi_Kupci",
                        column: x => x.KupacId,
                        principalTable: "Kupci",
                        principalColumn: "KupacID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "CS_Email",
                table: "Korisnici",
                column: "Email",
                unique: true,
                filter: "([Email] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_CovidPasosi_KupacId",
                table: "CovidPasosi",
                column: "KupacId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CovidPasosi");

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
