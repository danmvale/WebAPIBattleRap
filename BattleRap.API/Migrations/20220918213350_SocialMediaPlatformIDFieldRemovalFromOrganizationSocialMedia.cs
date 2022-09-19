using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BattleRap.API.Migrations
{
    public partial class SocialMediaPlatformIDFieldRemovalFromOrganizationSocialMedia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SocialMediaPlatformID",
                table: "OrganizationSocialMedia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SocialMediaPlatformID",
                table: "OrganizationSocialMedia",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
