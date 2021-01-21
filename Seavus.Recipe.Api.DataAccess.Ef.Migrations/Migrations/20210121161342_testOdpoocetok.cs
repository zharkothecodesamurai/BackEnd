using Microsoft.EntityFrameworkCore.Migrations;

namespace Seavus.Recipe.Api.DataAccess.Ef.Migrations.Migrations
{
    public partial class testOdpoocetok : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Citizens",
                columns: new[] { "Id", "Age", "CityId", "Height", "LastName", "Name" },
                values: new object[] { 5, 40, 1, 175, "Naum", "Cvare" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Citizens",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
