using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BattleRap.API.Migrations
{
    public partial class InsertIntoSocialMediaPlatformTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var baseUrl = "https://teste.organizesuarotina.com.br/images";

            var platforms = new Dictionary<string, string>
            {
                { "Youtube", $"{baseUrl}/youtube.png" },
                { "Instagram", $"{baseUrl}/instagram.png" },
                { "Facebook", $"{baseUrl}/facebook.png" },
                { "TikTok", $"{baseUrl}/tiktok.png" },
            };

            foreach (var platform in platforms)
            {
                migrationBuilder.Sql($"INSERT INTO" +
                    $" SocialMediaPlatform (Name, Logo)" +
                    $" VALUES ('{platform.Key}', '{platform.Value}')");
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM SocialMediaPlatform");
        }
    }
}
