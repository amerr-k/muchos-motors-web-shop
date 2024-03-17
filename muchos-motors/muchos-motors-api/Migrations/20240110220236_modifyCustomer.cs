using Microsoft.EntityFrameworkCore.Migrations;

namespace muchosmotorsapi.Migrations
{
    public partial class modifyCustomer : Migration
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
                name: "CustomerEmail",
                table: "Order",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomerFirstName",
                table: "Order",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomerLastName",
                table: "Order",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomerPhone",
                table: "Order",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomerShippingAddress",
                table: "Order",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CustomerShippingCityId",
                table: "Order",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerShippingCityId",
                table: "Order",
                column: "CustomerShippingCityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_City_CustomerShippingCityId",
                table: "Order",
                column: "CustomerShippingCityId",
                principalTable: "City",
                principalColumn: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_City_CustomerShippingCityId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_CustomerShippingCityId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "CustomerEmail",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "CustomerFirstName",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "CustomerLastName",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "CustomerPhone",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "CustomerShippingAddress",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "CustomerShippingCityId",
                table: "Order");

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
