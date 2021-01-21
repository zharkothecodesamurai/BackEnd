using Microsoft.EntityFrameworkCore.Migrations;

namespace Seavus.Recipe.Api.DataAccess.Ef.Migrations.Migrations
{
    public partial class SeedingCityandCitizens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "CityCodeA2", "CityName", "Population" },
                values: new object[] { 1, "SK", "Skopje", 1000000 });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "CityCodeA2", "CityName", "Population" },
                values: new object[] { 2, "BG", "Beograd", 2000000 });

            migrationBuilder.InsertData(
                table: "Citizens",
                columns: new[] { "Id", "Age", "CityId", "Height", "LastName", "Name" },
                values: new object[,]
                {
                    { 1, 30, 1, 176, "Naum", "Zharko" },
                    { 2, 30, 1, 156, "Naum", "Anastazija" },
                    { 3, 50, 2, 180, "Naum", "Bube" },
                    { 4, 40, 2, 175, "Naum", "Dare" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Citizens",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Citizens",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Citizens",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Citizens",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
