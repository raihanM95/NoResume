using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NoResume.Migrations
{
    public partial class AuditImplemented : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Audits",
                columns: table => new
                {
                    AuditId = table.Column<string>(nullable: false),
                    AuditDescription = table.Column<string>(nullable: false),
                    IsExceptionThrown = table.Column<bool>(nullable: false),
                    DeveloperOrAnonymous = table.Column<string>(nullable: false),
                    TimeOfAction = table.Column<DateTime>(nullable: false),
                    InternetProtocol = table.Column<string>(nullable: false),
                    Country = table.Column<string>(nullable: false),
                    CountryCode = table.Column<string>(nullable: false),
                    Latitude = table.Column<string>(nullable: false),
                    Longitude = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audits", x => x.AuditId);
                });

            migrationBuilder.CreateTable(
                name: "ShortBios",
                columns: table => new
                {
                    DeveloperId = table.Column<string>(nullable: false),
                    ShortDescription = table.Column<string>(maxLength: 2048, nullable: true),
                    CurrentCity = table.Column<string>(nullable: true),
                    IsAvailableForJob = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShortBios", x => x.DeveloperId);
                });

            migrationBuilder.CreateTable(
                name: "SocialProfiles",
                columns: table => new
                {
                    DeveloperId = table.Column<string>(nullable: false),
                    LinkedInUsername = table.Column<string>(nullable: true),
                    FacebookUsername = table.Column<string>(nullable: true),
                    TwitterUsername = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialProfiles", x => x.DeveloperId);
                });

            migrationBuilder.CreateTable(
                name: "WorkingProfiles",
                columns: table => new
                {
                    DeveloperId = table.Column<string>(nullable: false),
                    GithubUsername = table.Column<string>(nullable: true),
                    PrivacyForGithub = table.Column<bool>(nullable: false),
                    CodeforcesUsername = table.Column<string>(nullable: true),
                    PrivacyForCodeforces = table.Column<bool>(nullable: false),
                    UhuntUsername = table.Column<string>(nullable: true),
                    PrivacyForUhunt = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingProfiles", x => x.DeveloperId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Audits");

            migrationBuilder.DropTable(
                name: "ShortBios");

            migrationBuilder.DropTable(
                name: "SocialProfiles");

            migrationBuilder.DropTable(
                name: "WorkingProfiles");
        }
    }
}
