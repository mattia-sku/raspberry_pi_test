using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebServerCloud.Migrations
{
    public partial class initia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
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
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tenant",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    RagioneSociale = table.Column<string>(nullable: true),
                    Cellulare = table.Column<string>(nullable: true),
                    Mail = table.Column<string>(nullable: true),
                    stampante = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Spedizioni",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Indirizzo = table.Column<string>(nullable: true),
                    CAP = table.Column<string>(nullable: true),
                    Citta = table.Column<string>(nullable: true),
                    Provincia = table.Column<string>(nullable: true),
                    tenantId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spedizioni", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Spedizioni_Tenant_tenantId",
                        column: x => x.tenantId,
                        principalTable: "Tenant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ordini",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    AudioProtesistaId = table.Column<Guid>(nullable: false),
                    SpedizioneId = table.Column<Guid>(nullable: false),
                    VideoName = table.Column<string>(nullable: true),
                    DataCaricamento = table.Column<DateTime>(nullable: false),
                    Cliente_Iniziali = table.Column<string>(nullable: true),
                    Cliente_PrimoPortatore = table.Column<bool>(nullable: false),
                    Cliente_DataNascita = table.Column<DateTime>(nullable: false),
                    Ventilazione = table.Column<string>(nullable: false),
                    Normale = table.Column<string>(nullable: false),
                    Cedevole = table.Column<string>(nullable: false),
                    Molle = table.Column<string>(nullable: false),
                    MiniFit_Lato = table.Column<string>(nullable: false),
                    MiniFit_Fitting = table.Column<int>(nullable: false),
                    MiniFit_Mould = table.Column<string>(nullable: true),
                    MiniFit_Tip = table.Column<string>(nullable: true),
                    PFM_Lato = table.Column<string>(nullable: false),
                    PFM_Fitting = table.Column<int>(nullable: false),
                    PFM_Versione = table.Column<string>(nullable: true),
                    PFM_Wire = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ordini", x => x.Id);
                    table.CheckConstraint("CK_DATI_Ventilazione", "Ventilazione in ('D','S','E','N')");
                    table.CheckConstraint("CK_Utente_Molle", "Molle in ('D','S','E','N')");
                    table.CheckConstraint("CK_Utente_Cedevole", "Cedevole in ('D','S','E','N')");
                    table.CheckConstraint("CK_Utente_Normale", "Normale in ('D','S','E','N')");
                    table.ForeignKey(
                        name: "FK_ordini_Tenant_AudioProtesistaId",
                        column: x => x.AudioProtesistaId,
                        principalTable: "Tenant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ordini_Spedizioni_SpedizioneId",
                        column: x => x.SpedizioneId,
                        principalTable: "Spedizioni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_Spedizioni_tenantId",
                table: "Spedizioni",
                column: "tenantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "ordini");

            migrationBuilder.DropTable(
                name: "Spedizioni");

            migrationBuilder.DropTable(
                name: "Tenant");
        }
    }
}
