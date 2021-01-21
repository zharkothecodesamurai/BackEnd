using Microsoft.EntityFrameworkCore.Migrations;

namespace Seavus.Recipe.Api.DataAccess.Ef.Migrations.Migrations
{
    public partial class ZharkoCitySeeding3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Citizens",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.InsertData(
                table: "Citizens",
                columns: new[] { "Id", "Age", "Height", "LastName", "Name" },
                values: new object[,]
                {
                    { 1, 30, 176, "Naum", "Zharko" },
                    { 2, 30, 156, "Naum", "Anastazija" },
                    { 3, 50, 180, "Naum", "Bube" },
                    { 4, 40, 175, "Naum", "Dare" }
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

            migrationBuilder.InsertData(
                table: "Citizens",
                columns: new[] { "Id", "Age", "Height", "LastName", "Name" },
                values: new object[] { 5, 50, 150, "Naum", "Vale" });
        }
    }
}
