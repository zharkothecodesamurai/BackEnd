using Microsoft.EntityFrameworkCore.Migrations;

namespace Seavus.Recipe.Api.DataAccess.Ef.Migrations.Migrations
{
    public partial class CitizenSeeding2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Citizens",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "Citizens",
                columns: new[] { "Id", "Age", "Height", "LastName", "Name" },
                values: new object[] { 5, 50, 150, "Naum", "Vale" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Citizens",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.InsertData(
                table: "Citizens",
                columns: new[] { "Id", "Age", "Height", "LastName", "Name" },
                values: new object[] { 1, 30, 176, "Naum", "Zharko" });
        }
    }
}
