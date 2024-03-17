using Microsoft.EntityFrameworkCore.Migrations;

namespace muchosmotorsapi.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserAccount",
                columns: new[] { "UserAccountId", "Address", "Email", "FirstName", "IsValid", "LastName", "Password", "Phone", "UserPicture", "UserType", "Username", "isAdmin" },
                values: new object[,]
                {
                    { 1, "Aleja Ljiljana 23", "nino.omic@edu.fit.ba", "Nino", true, "Omic", "nino123", "062222222", null, "Customer", "NinoO", false },
                    { 2, "Radinovici bb", "dajana.medic@fit.ba", "Dajana", true, "Medic", "dajana123", "063333333", null, "Customer", "DajanaM", false },
                    { 3, "Aleja Ljiljana 23", "kupac@edu.fit.ba", "Kupac", true, "Kupac", "kupac", "063333333", null, "Customer", "kupac", false },
                    { 4, "Aleja Ljiljana 23", "amer@edu.fit.ba", "Amer", true, "Amer", "amer", "063333333", null, "Customer", "amer", false },
                    { 5, "Zenica bb", "asmir.saric@gmail.com", "Asmir", true, "Šaric", "asmir123", null, null, "Employee", "AsmirS", false },
                    { 6, "Zenica bb", "radnik.radnik@gmail.com", "Radnik", true, "Radnik", "radnik", null, null, "Employee", "radnik", false }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserAccount",
                keyColumn: "UserAccountId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserAccount",
                keyColumn: "UserAccountId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserAccount",
                keyColumn: "UserAccountId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserAccount",
                keyColumn: "UserAccountId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UserAccount",
                keyColumn: "UserAccountId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "UserAccount",
                keyColumn: "UserAccountId",
                keyValue: 6);
        }
    }
}
