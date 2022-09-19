using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BattleRap.API.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SocialMediaPlatform",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Logo = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMediaPlatform", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CountryID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.ID);
                    table.ForeignKey(
                        name: "FK_State_Country_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Country",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SocialMediaProfile",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SocialMediaPlatformID = table.Column<int>(type: "int", nullable: false),
                    URL = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMediaProfile", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SocialMediaProfile_SocialMediaPlatform_SocialMediaPlatformID",
                        column: x => x.SocialMediaPlatformID,
                        principalTable: "SocialMediaPlatform",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StateID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.ID);
                    table.ForeignKey(
                        name: "FK_City_State_StateID",
                        column: x => x.StateID,
                        principalTable: "State",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CityID = table.Column<int>(type: "int", nullable: false),
                    ZipCode = table.Column<string>(type: "char(9)", maxLength: 9, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddressLine1 = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Neighborhood = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddressLine2 = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Latitude = table.Column<double>(type: "double", nullable: true),
                    Longitude = table.Column<double>(type: "double", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Address_City_CityID",
                        column: x => x.CityID,
                        principalTable: "City",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OrganizationInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AddressID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    Logo = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationInfo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrganizationInfo_Address_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Address",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OrganizationSocialMedia",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrganizationID = table.Column<int>(type: "int", nullable: false),
                    SocialMediaPlatformID = table.Column<int>(type: "int", nullable: false),
                    SocialMediaProfileID = table.Column<int>(type: "int", nullable: false),
                    OrganizationInfoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationSocialMedia", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrganizationSocialMedia_OrganizationInfo_OrganizationInfoID",
                        column: x => x.OrganizationInfoID,
                        principalTable: "OrganizationInfo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizationSocialMedia_SocialMediaProfile_SocialMediaProfil~",
                        column: x => x.SocialMediaProfileID,
                        principalTable: "SocialMediaProfile",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OrganizationSuggestion",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrganizationInfoID = table.Column<int>(type: "int", nullable: false),
                    Approved = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationSuggestion", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrganizationSuggestion_OrganizationInfo_OrganizationInfoID",
                        column: x => x.OrganizationInfoID,
                        principalTable: "OrganizationInfo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Organization",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrganizationInfoID = table.Column<int>(type: "int", nullable: false),
                    OrganizationSuggestionID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Organization_OrganizationInfo_OrganizationInfoID",
                        column: x => x.OrganizationInfoID,
                        principalTable: "OrganizationInfo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Organization_OrganizationSuggestion_OrganizationSuggestionID",
                        column: x => x.OrganizationSuggestionID,
                        principalTable: "OrganizationSuggestion",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Address_CityID",
                table: "Address",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_City_StateID",
                table: "City",
                column: "StateID");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_OrganizationInfoID",
                table: "Organization",
                column: "OrganizationInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_OrganizationSuggestionID",
                table: "Organization",
                column: "OrganizationSuggestionID");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationInfo_AddressID",
                table: "OrganizationInfo",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationSocialMedia_OrganizationInfoID",
                table: "OrganizationSocialMedia",
                column: "OrganizationInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationSocialMedia_SocialMediaProfileID",
                table: "OrganizationSocialMedia",
                column: "SocialMediaProfileID");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationSuggestion_OrganizationInfoID",
                table: "OrganizationSuggestion",
                column: "OrganizationInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_SocialMediaProfile_SocialMediaPlatformID",
                table: "SocialMediaProfile",
                column: "SocialMediaPlatformID");

            migrationBuilder.CreateIndex(
                name: "IX_State_CountryID",
                table: "State",
                column: "CountryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Organization");

            migrationBuilder.DropTable(
                name: "OrganizationSocialMedia");

            migrationBuilder.DropTable(
                name: "OrganizationSuggestion");

            migrationBuilder.DropTable(
                name: "SocialMediaProfile");

            migrationBuilder.DropTable(
                name: "OrganizationInfo");

            migrationBuilder.DropTable(
                name: "SocialMediaPlatform");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
