using BattleRap.API.Context;
using BattleRap.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BattleRap.API.Migrations
{
    public partial class InsertIntoStateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Country (Name) VALUES ('Brasil')");

            var statesString = "Acre - AC\r\nAlagoas - AL\r\nAmapá - AP\r\nAmazonas - AM\r\nBahia - BA\r\nCeará - CE\r\nDistrito Federal - DF\r\nEspírito Santo - ES\r\nGoiás - GO\r\nMaranhão - MA\r\nMato Grosso - MT\r\nMato Grosso do Sul - MS\r\nMinas Gerais - MG\r\nPará - PA\r\nParaíba - PB\r\nParaná - PR\r\nPernambuco - PE\r\nPiauí - PI\r\nRio de Janeiro - RJ\r\nRio Grande do Norte - RN\r\nRio Grande do Sul - RS\r\nRondônia - RO\r\nRoraima - RR\r\nSanta Catarina - SC\r\nSão Paulo - SP\r\nSergipe - SE\r\nTocantins - TO\r\n";
            var states = statesString.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);

            foreach (var state in states)
            {
                var info = state.Split(" - ");
                migrationBuilder.Sql($"INSERT INTO {nameof(State)} (Abbreviation, Name, CountryID) VALUES ('{info[1]}', '{info[0]}', 1)");
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"DELETE FROM {nameof(State)}");
        }
    }
}
