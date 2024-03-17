using Microsoft.EntityFrameworkCore.Migrations;

namespace muchosmotorsapi.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "UserAccount");

            migrationBuilder.AlterColumn<string>(
                name: "UserPicture",
                table: "UserAccount",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "UserType",
                table: "UserAccount",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserType",
                table: "UserAccount");

            migrationBuilder.AlterColumn<string>(
                name: "UserPicture",
                table: "UserAccount",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "UserAccount",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
