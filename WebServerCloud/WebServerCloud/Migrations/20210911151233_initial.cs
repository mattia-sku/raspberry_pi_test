using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebServerCloud.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "anagrafiche",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RagioneSociale = table.Column<string>(nullable: true),
                    Indirizzo = table.Column<string>(nullable: true),
                    CAP = table.Column<string>(nullable: true),
                    Citta = table.Column<string>(nullable: true),
                    Provincia = table.Column<string>(nullable: true),
                    Cellulare = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_anagrafiche", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "datiProtesi",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Oticon = table.Column<string>(nullable: false),
                    Ventilazione = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_datiProtesi", x => x.Id);
                    table.CheckConstraint("CK_DATI_OTICON", "Oticon in ('D','S','E')");
                    table.CheckConstraint("CK_DATI_Ventilazione", "Ventilazione in ('D','S','E')");
                });

            migrationBuilder.CreateTable(
                name: "utentiProtesi",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Iniziali = table.Column<string>(nullable: true),
                    PrimoPortatore = table.Column<bool>(nullable: false),
                    DataNascita = table.Column<DateTime>(nullable: false),
                    Normale = table.Column<string>(nullable: false),
                    Cedevole = table.Column<string>(nullable: false),
                    Molle = table.Column<string>(nullable: false),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_utentiProtesi", x => x.Id);
                    table.CheckConstraint("CK_Utente_Molle", "Molle in ('D','S','E')");
                    table.CheckConstraint("CK_Utente_Cedevole", "Cedevole in ('D','S','E')");
                    table.CheckConstraint("CK_Utente_Normale", "Normale in ('D','S','E')");
                });

            migrationBuilder.CreateTable(
                name: "ordini",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AudioProtesistaId = table.Column<Guid>(nullable: true),
                    SpedizioneId = table.Column<Guid>(nullable: true),
                    UtenteProtesiId = table.Column<Guid>(nullable: true),
                    Video = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ordini", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ordini_anagrafiche_AudioProtesistaId",
                        column: x => x.AudioProtesistaId,
                        principalTable: "anagrafiche",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ordini_anagrafiche_SpedizioneId",
                        column: x => x.SpedizioneId,
                        principalTable: "anagrafiche",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ordini_utentiProtesi_UtenteProtesiId",
                        column: x => x.UtenteProtesiId,
                        principalTable: "utentiProtesi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ordini_AudioProtesistaId",
                table: "ordini",
                column: "AudioProtesistaId");

            migrationBuilder.CreateIndex(
                name: "IX_ordini_SpedizioneId",
                table: "ordini",
                column: "SpedizioneId");

            migrationBuilder.CreateIndex(
                name: "IX_ordini_UtenteProtesiId",
                table: "ordini",
                column: "UtenteProtesiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "datiProtesi");

            migrationBuilder.DropTable(
                name: "ordini");

            migrationBuilder.DropTable(
                name: "anagrafiche");

            migrationBuilder.DropTable(
                name: "utentiProtesi");
        }
    }
}
