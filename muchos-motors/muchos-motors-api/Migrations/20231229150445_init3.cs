using Microsoft.EntityFrameworkCore.Migrations;

namespace muchosmotorsapi.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "IsRegistered",
                table: "UserAccount");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "UserAccount");

            migrationBuilder.DropColumn(
                name: "Employee_Address",
                table: "UserAccount");

            migrationBuilder.DropColumn(
                name: "Employee_Email",
                table: "UserAccount");

            migrationBuilder.DropColumn(
                name: "Employee_FirstName",
                table: "UserAccount");

            migrationBuilder.DropColumn(
                name: "Employee_LastName",
                table: "UserAccount");

            migrationBuilder.DropColumn(
                name: "Employee_Phone",
                table: "UserAccount");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "UserAccount",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "UserAccount",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "UserAccount",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "UserAccount",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "UserAccount",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "UserAccount",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "UserAccount",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRegistered",
                table: "UserAccount",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "UserAccount",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Employee_Address",
                table: "UserAccount",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Employee_Email",
                table: "UserAccount",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Employee_FirstName",
                table: "UserAccount",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Employee_LastName",
                table: "UserAccount",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Employee_Phone",
                table: "UserAccount",
                type: "nvarchar(max)",
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
    }
}
