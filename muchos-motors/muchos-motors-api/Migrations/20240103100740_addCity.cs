using Microsoft.EntityFrameworkCore.Migrations;

namespace muchosmotorsapi.Migrations
{
    public partial class addCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserType",
                table: "UserAccount",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "UserAccount",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAccount_CityId",
                table: "UserAccount",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccount_City_CityId",
                table: "UserAccount",
                column: "CityId",
                principalTable: "City",
                principalColumn: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAccount_City_CityId",
                table: "UserAccount");

            migrationBuilder.DropIndex(
                name: "IX_UserAccount_CityId",
                table: "UserAccount");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "UserAccount");

            migrationBuilder.AlterColumn<string>(
                name: "UserType",
                table: "UserAccount",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
