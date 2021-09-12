using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebServerCloud.Migrations
{
    public partial class DataCaricamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataCaricamento",
                table: "ordini",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataCaricamento",
                table: "ordini");
        }
    }
}
