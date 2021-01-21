using Microsoft.EntityFrameworkCore.Migrations;

namespace Seavus.Recipe.Api.DataAccess.Ef.Migrations.Migrations
{
    public partial class Te : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_City",
            //    table: "City");

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

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "City",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Citizens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_City",
                table: "City",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Citizens_CityId",
                table: "Citizens",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Citizens_City_CityId",
                table: "Citizens",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citizens_City_CityId",
                table: "Citizens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_City",
                table: "City");

            migrationBuilder.DropIndex(
                name: "IX_Citizens_CityId",
                table: "Citizens");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "City");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Citizens");

            migrationBuilder.AddPrimaryKey(
                name: "PK_City",
                table: "City",
                column: "CityCodeA2");

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
    }
}
