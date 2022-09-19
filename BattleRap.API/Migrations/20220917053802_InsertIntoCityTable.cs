using BattleRap.API.Models;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Text;

#nullable disable

namespace BattleRap.API.Migrations
{
    public partial class InsertIntoCityTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var statesString = "Acre - AC\r\nAlagoas - AL\r\nAmapá - AP\r\nAmazonas - AM\r\nBahia - BA\r\nCeará - CE\r\nDistrito Federal - DF\r\nEspírito Santo - ES\r\nGoiás - GO\r\nMaranhão - MA\r\nMato Grosso - MT\r\nMato Grosso do Sul - MS\r\nMinas Gerais - MG\r\nPará - PA\r\nParaíba - PB\r\nParaná - PR\r\nPernambuco - PE\r\nPiauí - PI\r\nRio de Janeiro - RJ\r\nRio Grande do Norte - RN\r\nRio Grande do Sul - RS\r\nRondônia - RO\r\nRoraima - RR\r\nSanta Catarina - SC\r\nSão Paulo - SP\r\nSergipe - SE\r\nTocantins - TO\r\n";
            var states = new Dictionary<string, int>();

            foreach (var (state, id) in statesString.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Select((state, id) => (state, id)))
            {
                var info = state.Split(" - ");
                states.Add(info[1], id + 1);
            }

            var url = "http://blog.mds.gov.br/redesuas/wp-content/uploads/2018/06/Lista_Munic%C3%ADpios_com_IBGE_Brasil_Versao_CSV.csv";

            var httpClient = new HttpClient();
            var response = httpClient.GetAsync(url).GetAwaiter().GetResult();

            response.EnsureSuccessStatusCode();

            var csv = response.Content.ReadAsStreamAsync().GetAwaiter().GetResult();
            var reader = new StreamReader(csv, Encoding.Latin1);
            
            // skip header
            reader.ReadLine();

            string line = null;

            while ((line = reader.ReadLine()) != null)
            {
                var info = line.Split(';');
                migrationBuilder.Sql($"INSERT INTO {nameof(City)} (Name, StateID) VALUES ('{info[4]}', {states[info[3]]})");
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"DELETE FROM {nameof(City)}");
        }
    }
}
