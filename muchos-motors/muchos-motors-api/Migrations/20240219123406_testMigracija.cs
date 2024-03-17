using Microsoft.EntityFrameworkCore.Migrations;

namespace muchosmotorsapi.Migrations
{
    public partial class testMigracija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserType",
                table: "UserAccount",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "NoviAtribut",
                table: "UserAccount",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoviAtribut",
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
