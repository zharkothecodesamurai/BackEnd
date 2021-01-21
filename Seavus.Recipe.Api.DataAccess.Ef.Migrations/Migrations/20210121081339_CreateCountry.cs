using Microsoft.EntityFrameworkCore.Migrations;

namespace Seavus.Recipe.Api.DataAccess.Ef.Migrations.Migrations
{
    public partial class CreateCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryCodeA2 = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => new { x.CountryCodeA2, x.CountryName });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
