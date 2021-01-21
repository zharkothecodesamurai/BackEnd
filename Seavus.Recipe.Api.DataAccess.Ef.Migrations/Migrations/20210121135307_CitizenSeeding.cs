using Microsoft.EntityFrameworkCore.Migrations;

namespace Seavus.Recipe.Api.DataAccess.Ef.Migrations.Migrations
{
    public partial class CitizenSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Citizens",
                columns: new[] { "Id", "Age", "Height", "LastName", "Name" },
                values: new object[] { 1, 30, 176, "Naum", "Zharko" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Citizens",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
