using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BattleRap.API.Migrations
{
    public partial class StateFieldsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Abbreviation",
                table: "State",
                type: "char(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Abbreviation",
                table: "State");
        }
    }
}
