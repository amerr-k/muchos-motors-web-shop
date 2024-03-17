using Microsoft.EntityFrameworkCore.Migrations;

namespace muchosmotorsapi.Migrations
{
    public partial class removePicUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserType",
                table: "UserAccount",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "CarPart",
                keyColumn: "CarPartId",
                keyValue: 1,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "CarPart",
                keyColumn: "CarPartId",
                keyValue: 2,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "CarPart",
                keyColumn: "CarPartId",
                keyValue: 3,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "CarPart",
                keyColumn: "CarPartId",
                keyValue: 4,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "CarPart",
                keyColumn: "CarPartId",
                keyValue: 5,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "CarPart",
                keyColumn: "CarPartId",
                keyValue: 6,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "CarPart",
                keyColumn: "CarPartId",
                keyValue: 7,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "CarPart",
                keyColumn: "CarPartId",
                keyValue: 8,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "CarPart",
                keyColumn: "CarPartId",
                keyValue: 9,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "CarPart",
                keyColumn: "CarPartId",
                keyValue: 10,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "CarPart",
                keyColumn: "CarPartId",
                keyValue: 11,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "CarPart",
                keyColumn: "CarPartId",
                keyValue: 12,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "CarPart",
                keyColumn: "CarPartId",
                keyValue: 13,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "CarPart",
                keyColumn: "CarPartId",
                keyValue: 14,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "CarPart",
                keyColumn: "CarPartId",
                keyValue: 15,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "CarPart",
                keyColumn: "CarPartId",
                keyValue: 16,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "CarPart",
                keyColumn: "CarPartId",
                keyValue: 17,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "CarPart",
                keyColumn: "CarPartId",
                keyValue: 18,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "CarPart",
                keyColumn: "CarPartId",
                keyValue: 19,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "CarPart",
                keyColumn: "CarPartId",
                keyValue: 20,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "CarPart",
                keyColumn: "CarPartId",
                keyValue: 21,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "CarPart",
                keyColumn: "CarPartId",
                keyValue: 22,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "CarPart",
                keyColumn: "CarPartId",
                keyValue: 23,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "CarPart",
                keyColumn: "CarPartId",
                keyValue: 24,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "CarPart",
                keyColumn: "CarPartId",
                keyValue: 25,
                column: "ImageUrl",
                value: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserType",
                table: "UserAccount",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "CarPart",
                keyColumn: "CarPartId",
                keyValue: 1,
                column: "ImageUrl",
                value: "car-parts-images/slika_1.jpg");

            migrationBuilder.UpdateData(
                table: "CarPart",
                keyColumn: "CarPartId",
                keyValue: 2,
                column: "ImageUrl",
                value: "car-parts-images/slika_24.jpg");

            migrationBuilder.UpdateData(
                table: "CarPart",
                keyColumn: "CarPartId",
                keyValue: 3,
                column: "ImageUrl",
                value: "car-parts-images/slika_23.jpg");

            migrationBuilder.UpdateData(
                table: "CarPart",
                keyColumn: "CarPartId",
                keyValue: 4,
                column: "ImageUrl",
                value: "car-parts-images/slika_22.jpg");

            migrationBuilder.UpdateData(
                table: "CarPart",
                keyColumn: "CarPartId",
                keyValue: 5,
                column: "ImageUrl",
                value: "car-parts-images/slika_21.jpg");

            migrationBuilder.UpdateData(
                table: "CarPart",
                keyColumn: "CarPartId",
                keyValue: 6,
                column: "ImageUrl",
                value: "car-parts-images/slika_20.jpg");

            migrationBuilder.UpdateData(
                table: "CarPart",
                keyColumn: "CarPartId",
                keyValue: 7,
                column: "ImageUrl",
                value: "car-parts-images/slika_19.jpg");

            migrationBuilder.UpdateData(
                table: "CarPart",
                keyColumn: "CarPartId",
                keyValue: 8,
                column: "ImageUrl",
                value: "car-parts-images/slika_18.jpg");

            migrationBuilder.UpdateData(
                table: "CarPart",
                keyColumn: "CarPartId",
                keyValue: 9,
                column: "ImageUrl",
                value: "car-parts-images/slika_17.jpg");

            migrationBuilder.UpdateData(
                table: "CarPart",
                keyColumn: "CarPartId",
                keyValue: 10,
                column: "ImageUrl",
                value: "car-parts-images/slika_16.jpg");

            migrationBuilder.UpdateData(
                table: "CarPart",
                keyColumn: "CarPartId",
                keyValue: 11,
                column: "ImageUrl",
                value: "car-parts-images/slika_15.jpg");

            migrationBuilder.UpdateData(
                table: "CarPart",
                keyColumn: "CarPartId",
                keyValue: 12,
                column: "ImageUrl",
                value: "car-parts-images/slika_14.jpg");

            migrationBuilder.UpdateData(
                table: "CarPart",
                keyColumn: "CarPartId",
                keyValue: 13,
                column: "ImageUrl",
                value: "car-parts-images/slika_13.jpg");

            migrationBuilder.UpdateData(
                table: "CarPart",
                keyColumn: "CarPartId",
                keyValue: 14,
                column: "ImageUrl",
                value: "car-parts-images/slika_12.jpg");

            migrationBuilder.UpdateData(
                table: "CarPart",
                keyColumn: "CarPartId",
                keyValue: 15,
                column: "ImageUrl",
                value: "car-parts-images/slika_11.jpg");

            migrationBuilder.UpdateData(
                table: "CarPart",
                keyColumn: "CarPartId",
                keyValue: 16,
                column: "ImageUrl",
                value: "car-parts-images/slika_10.jpg");

            migrationBuilder.UpdateData(
                table: "CarPart",
                keyColumn: "CarPartId",
                keyValue: 17,
                column: "ImageUrl",
                value: "car-parts-images/slika_9.jpg");

            migrationBuilder.UpdateData(
                table: "CarPart",
                keyColumn: "CarPartId",
                keyValue: 18,
                column: "ImageUrl",
                value: "car-parts-images/slika_8.jpg");

            migrationBuilder.UpdateData(
                table: "CarPart",
                keyColumn: "CarPartId",
                keyValue: 19,
                column: "ImageUrl",
                value: "car-parts-images/slika_7.jpg");

            migrationBuilder.UpdateData(
                table: "CarPart",
                keyColumn: "CarPartId",
                keyValue: 20,
                column: "ImageUrl",
                value: "car-parts-images/slika_6.jpg");

            migrationBuilder.UpdateData(
                table: "CarPart",
                keyColumn: "CarPartId",
                keyValue: 21,
                column: "ImageUrl",
                value: "car-parts-images/slika_5.jpg");

            migrationBuilder.UpdateData(
                table: "CarPart",
                keyColumn: "CarPartId",
                keyValue: 22,
                column: "ImageUrl",
                value: "car-parts-images/slika_4.jpg");

            migrationBuilder.UpdateData(
                table: "CarPart",
                keyColumn: "CarPartId",
                keyValue: 23,
                column: "ImageUrl",
                value: "car-parts-images/slika_3.jpg");

            migrationBuilder.UpdateData(
                table: "CarPart",
                keyColumn: "CarPartId",
                keyValue: 24,
                column: "ImageUrl",
                value: "car-parts-images/slika_2.jpg");

            migrationBuilder.UpdateData(
                table: "CarPart",
                keyColumn: "CarPartId",
                keyValue: 25,
                column: "ImageUrl",
                value: "car-parts-images/slika_1.jpg");
        }
    }
}
