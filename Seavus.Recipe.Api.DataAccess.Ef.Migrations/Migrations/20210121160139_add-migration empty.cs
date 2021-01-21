using Microsoft.EntityFrameworkCore.Migrations;

namespace Seavus.Recipe.Api.DataAccess.Ef.Migrations.Migrations
{
    public partial class addmigrationempty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var countryMap= @"
                INSERT [Country] ([CountryCodeA2],[CountryName]) VALUES (N'KR',N'Korea,Republic Of')
                GO";

            migrationBuilder.Sql(countryMap);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
