using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Horsey.Data.Migrations
{
    public partial class addPrimaryKeyStandings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Standings",
                table: "Standings");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Horses");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Standings",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Standings",
                table: "Standings",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Standings_RaceId",
                table: "Standings",
                column: "RaceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Standings",
                table: "Standings");

            migrationBuilder.DropIndex(
                name: "IX_Standings_RaceId",
                table: "Standings");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Standings");

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Horses",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Standings",
                table: "Standings",
                columns: new[] { "RaceId", "HorseId" });
        }
    }
}
