using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace muchosmotorsapi.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarBrand",
                columns: table => new
                {
                    CarBrandId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    IsValid = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarBrand", x => x.CarBrandId);
                });

            migrationBuilder.CreateTable(
                name: "CarPart",
                columns: table => new
                {
                    CarPartId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    SellingPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WarehouseCount = table.Column<int>(nullable: false),
                    Details = table.Column<string>(nullable: false),
                    CarPartCategory = table.Column<string>(nullable: false),
                    IsValid = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarPart", x => x.CarPartId);
                });

            migrationBuilder.CreateTable(
                name: "CarPartBrand",
                columns: table => new
                {
                    CarPartBrandId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    IsValid = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarPartBrand", x => x.CarPartBrandId);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    PostCode = table.Column<string>(nullable: false),
                    IsValid = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "ErrorLog",
                columns: table => new
                {
                    ErrorAuditId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(nullable: false),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    StackTrace = table.Column<string>(nullable: false),
                    StatusCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorLog", x => x.ErrorAuditId);
                });

            migrationBuilder.CreateTable(
                name: "InventoryLog",
                columns: table => new
                {
                    InventoryLogId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsValid = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryLog", x => x.InventoryLogId);
                });

            migrationBuilder.CreateTable(
                name: "GenericCarModel",
                columns: table => new
                {
                    GenericCarModelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenerationName = table.Column<string>(nullable: false),
                    ModelName = table.Column<string>(nullable: false),
                    CarBrandId = table.Column<int>(nullable: false),
                    ProductionStartYear = table.Column<int>(nullable: false),
                    ProductionEndYear = table.Column<int>(nullable: false),
                    IsValid = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenericCarModel", x => x.GenericCarModelId);
                    table.ForeignKey(
                        name: "FK_GenericCarModel_CarBrand_CarBrandId",
                        column: x => x.CarBrandId,
                        principalTable: "CarBrand",
                        principalColumn: "CarBrandId");
                });

            migrationBuilder.CreateTable(
                name: "UserAccount",
                columns: table => new
                {
                    UserAccountId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    UserPicture = table.Column<string>(nullable: false),
                    isAdmin = table.Column<bool>(nullable: false),
                    IsValid = table.Column<bool>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    CityId = table.Column<int>(nullable: true),
                    IsRegistered = table.Column<bool>(nullable: true),
                    Employee_FirstName = table.Column<string>(nullable: true),
                    Employee_LastName = table.Column<string>(nullable: true),
                    Employee_Email = table.Column<string>(nullable: true),
                    Employee_Address = table.Column<string>(nullable: true),
                    Employee_Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccount", x => x.UserAccountId);
                    table.ForeignKey(
                        name: "FK_UserAccount_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "CityId");
                });

            migrationBuilder.CreateTable(
                name: "InventoryCarPartLog",
                columns: table => new
                {
                    InventoryCarPartLogId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventoryLogId = table.Column<int>(nullable: false),
                    CarPartId = table.Column<int>(nullable: false),
                    NumberOfParts = table.Column<int>(nullable: false),
                    IsValid = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryCarPartLog", x => x.InventoryCarPartLogId);
                    table.ForeignKey(
                        name: "FK_InventoryCarPartLog_CarPart_CarPartId",
                        column: x => x.CarPartId,
                        principalTable: "CarPart",
                        principalColumn: "CarPartId");
                    table.ForeignKey(
                        name: "FK_InventoryCarPartLog_InventoryLog_InventoryLogId",
                        column: x => x.InventoryLogId,
                        principalTable: "InventoryLog",
                        principalColumn: "InventoryLogId");
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    CarId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChasisNumber = table.Column<string>(nullable: false),
                    LicencePlate = table.Column<string>(nullable: false),
                    YearOfManufacture = table.Column<int>(nullable: false),
                    Color = table.Column<string>(nullable: false),
                    Transmission = table.Column<string>(nullable: false),
                    EngineSize = table.Column<double>(nullable: false),
                    Mileage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Trim = table.Column<int>(nullable: false),
                    Segment = table.Column<int>(nullable: false),
                    GenericGenerationCarModelId = table.Column<int>(nullable: false),
                    IsValid = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.CarId);
                    table.ForeignKey(
                        name: "FK_Car_GenericCarModel_GenericGenerationCarModelId",
                        column: x => x.GenericGenerationCarModelId,
                        principalTable: "GenericCarModel",
                        principalColumn: "GenericCarModelId");
                });

            migrationBuilder.CreateTable(
                name: "CarPartsCompatibility",
                columns: table => new
                {
                    CarPartsCompatibilityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarPartId = table.Column<int>(nullable: false),
                    GenericCarModelId = table.Column<int>(nullable: false),
                    IsValid = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarPartsCompatibility", x => x.CarPartsCompatibilityId);
                    table.ForeignKey(
                        name: "FK_CarPartsCompatibility_CarPart_CarPartId",
                        column: x => x.CarPartId,
                        principalTable: "CarPart",
                        principalColumn: "CarPartId");
                    table.ForeignKey(
                        name: "FK_CarPartsCompatibility_GenericCarModel_GenericCarModelId",
                        column: x => x.GenericCarModelId,
                        principalTable: "GenericCarModel",
                        principalColumn: "GenericCarModelId");
                });

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    AppointmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentDate = table.Column<DateTime>(nullable: false),
                    AppointmentTimeStart = table.Column<DateTime>(nullable: false),
                    AppointmentTimeEnd = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    IsAuthorized = table.Column<bool>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    IsValid = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.AppointmentId);
                    table.ForeignKey(
                        name: "FK_Appointment_UserAccount_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "UserAccount",
                        principalColumn: "UserAccountId");
                    table.ForeignKey(
                        name: "FK_Appointment_UserAccount_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "UserAccount",
                        principalColumn: "UserAccountId");
                });

            migrationBuilder.CreateTable(
                name: "AuthenticationCode",
                columns: table => new
                {
                    AuthenticationCodeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(nullable: false),
                    TimeSent = table.Column<DateTime>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    isValid = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthenticationCode", x => x.AuthenticationCodeId);
                    table.ForeignKey(
                        name: "FK_AuthenticationCode_UserAccount_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "UserAccount",
                        principalColumn: "UserAccountId");
                });

            migrationBuilder.CreateTable(
                name: "AuthenticationToken",
                columns: table => new
                {
                    AuthenticationTokenId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(nullable: false),
                    UserAccountId = table.Column<int>(nullable: false),
                    IpAddress = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsValid = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthenticationToken", x => x.AuthenticationTokenId);
                    table.ForeignKey(
                        name: "FK_AuthenticationToken_UserAccount_UserAccountId",
                        column: x => x.UserAccountId,
                        principalTable: "UserAccount",
                        principalColumn: "UserAccountId");
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(nullable: true),
                    EmployeeId = table.Column<int>(nullable: true),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    ShippingDate = table.Column<DateTime>(nullable: true),
                    InvoiceCreatedDate = table.Column<DateTime>(nullable: true),
                    InvoiceCreated = table.Column<bool>(nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsValid = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_UserAccount_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "UserAccount",
                        principalColumn: "UserAccountId");
                    table.ForeignKey(
                        name: "FK_Order_UserAccount_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "UserAccount",
                        principalColumn: "UserAccountId");
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    OrderItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(nullable: false),
                    CarPartId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsValid = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "FK_OrderItem_CarPart_CarPartId",
                        column: x => x.CarPartId,
                        principalTable: "CarPart",
                        principalColumn: "CarPartId");
                    table.ForeignKey(
                        name: "FK_OrderItem_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId");
                });

            migrationBuilder.InsertData(
                table: "CarBrand",
                columns: new[] { "CarBrandId", "IsValid", "Name" },
                values: new object[,]
                {
                    { 1, true, "BMW" },
                    { 2, true, "Audi" },
                    { 3, true, "Mercedes" },
                    { 4, true, "Skoda" },
                    { 5, true, "Volkswagen" },
                    { 6, true, "Opel" }
                });

            migrationBuilder.InsertData(
                table: "CarPart",
                columns: new[] { "CarPartId", "CarPartCategory", "Code", "Details", "IsValid", "Name", "PurchasePrice", "SellingPrice", "WarehouseCount" },
                values: new object[,]
                {
                    { 15, "BrakeSystem", "STU-222", "Example details", true, "Kočioni disk", 28.5m, 39.99m, 10 },
                    { 16, "Engine", "VWX-333", "Example details", true, "Zupčasti remen", 12.75m, 15.99m, 10 },
                    { 17, "Suspension", "YZA-444", "Example details", true, "Amortizer zadnji", 54.5m, 69.99m, 10 },
                    { 18, "Suspension", "BCD-555", "Example details", true, "Stabilizator prednji", 22.75m, 29.99m, 10 },
                    { 19, "Engine", "EFG-666", "Example details", true, "Filter ulja", 9.5m, 12.99m, 10 },
                    { 23, "Exterior", "QRS-000", "Example details", true, "Set brava vrata", 38.5m, 49.99m, 10 },
                    { 22, "Engine", "NOP-999", "Example details", true, "Remen alternatora", 8.75m, 10.99m, 10 },
                    { 14, "Engine", "PQR-111", "Example details", true, "Rashladni ventilator", 38.75m, 49.99m, 10 },
                    { 24, "Exterior", "TUV-111", "Example details", true, "Kopča auspuha", 5.5m, 8.99m, 10 },
                    { 25, "Suspension", "WXY-222", "Example details", true, "Osovinica", 12.75m, 15.99m, 10 },
                    { 21, "BrakeSystem", "KLM-888", "Example details", true, "Disk kočnica zadnji", 18.5m, 25.99m, 10 },
                    { 13, "Engine", "MNO-910", "Example details", true, "Senzor položaja bregaste", 22.5m, 29.99m, 10 },
                    { 20, "ExhaustSystem", "HIJ-777", "Example details", true, "Sonda lambda", 32.75m, 39.99m, 10 },
                    { 11, "Transmission", "GHJ-345", "Example details", true, "Kvačilo", 62.5m, 79.99m, 10 },
                    { 1, "Engine", "XK-2312", "dobra roba", true, "Pumpa", 2m, 4.99m, 10 },
                    { 2, "Engine", "31-2222", "dobra roba", true, "Svjećica", 38m, 42.99m, 10 },
                    { 3, "Engine", "sf-1111", "Ok", true, "Ulje za motor", 30m, 32.99m, 10 },
                    { 12, "Transmission", "IJK-678", "Example details", true, "Set kvačila", 95.75m, 119.99m, 10 },
                    { 5, "Engine", "SS-5512", "Ok", true, "Filter za gorivo", 16m, 22.99m, 10 },
                    { 4, "BrakeSystem", "zt-3333", "Ok", true, "Kocioni sistem", 370m, 42.99m, 10 },
                    { 6, "Electrical", "ABC-123", "Example details", true, "Akumulator", 12.5m, 19.99m, 10 },
                    { 7, "ExhaustSystem", "XYZ-789", "Example details", true, "Lambda sonda", 18.75m, 29.99m, 10 },
                    { 8, "Engine", "LMN-456", "Example details", true, "Filter zraka", 10.25m, 15.99m, 10 },
                    { 9, "Suspension", "PQR-789", "Example details", true, "Amortizer", 45.5m, 59.99m, 10 },
                    { 10, "ExhaustSystem", "DEF-012", "Example details", true, "Katalizator", 85.75m, 99.99m, 10 }
                });

            migrationBuilder.InsertData(
                table: "CarPartBrand",
                columns: new[] { "CarPartBrandId", "IsValid", "Name" },
                values: new object[,]
                {
                    { 10, false, "Payen" },
                    { 9, false, "Pascal" },
                    { 8, false, "Denso" },
                    { 11, false, "Peters" },
                    { 7, false, "Delphi" },
                    { 4, false, "Diederichs" },
                    { 5, false, "Airtex" },
                    { 3, false, "AC cosmetics" },
                    { 2, false, "Dinex" },
                    { 1, false, "A.B.S." },
                    { 6, false, "AJS" }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityId", "IsValid", "Name", "PostCode" },
                values: new object[,]
                {
                    { 8, true, "Ljubuški", "88320" },
                    { 1, true, "Donji Vakuf", "72000" },
                    { 2, true, "Mostar", "88000" },
                    { 3, true, "Visoko", "71300" },
                    { 4, true, "Tuzla", "75000" },
                    { 5, true, "Zenica", "72000" },
                    { 6, true, "Jablanica", "88420" },
                    { 7, true, "Konjic", "88400" },
                    { 9, true, "Maglaj", "74250" }
                });

            migrationBuilder.InsertData(
                table: "GenericCarModel",
                columns: new[] { "GenericCarModelId", "CarBrandId", "GenerationName", "IsValid", "ModelName", "ProductionEndYear", "ProductionStartYear" },
                values: new object[,]
                {
                    { 1, 1, "G05", true, "X5", 2022, 2018 },
                    { 12, 6, "F", true, "Corsa", 2023, 2019 },
                    { 6, 6, "K", true, "Astra", 2021, 2015 },
                    { 29, 5, "A1", true, "T-Roc", 2022, 2017 },
                    { 23, 5, "B8", true, "Passat", 2019, 2014 },
                    { 17, 5, "3H", true, "Arteon", 2022, 2017 },
                    { 11, 5, "MK2", true, "Tiguan", 2020, 2016 },
                    { 5, 5, "MK7", true, "Golf", 2019, 2012 },
                    { 28, 4, "NU", true, "Karoq", 2021, 2017 },
                    { 22, 4, "MK3", true, "Fabia", 2019, 2014 },
                    { 16, 4, "NS", true, "Kodiaq", 2021, 2016 },
                    { 10, 4, "MK3", true, "Superb", 2020, 2015 },
                    { 4, 4, "MK3", true, "Octavia", 2019, 2012 },
                    { 18, 6, "G2", true, "Insignia", 2022, 2017 },
                    { 27, 3, "C117", true, "CLA", 2019, 2013 },
                    { 15, 3, "X253", true, "GLC", 2020, 2015 },
                    { 9, 3, "W205", true, "C-Class", 2020, 2014 },
                    { 3, 3, "W213", true, "E-Class", 2021, 2016 },
                    { 26, 2, "8V", true, "A3", 2018, 2012 },
                    { 20, 2, "4M", true, "Q7", 2020, 2015 },
                    { 14, 2, "C8", true, "A6", 2022, 2018 },
                    { 8, 2, "FY", true, "Q5", 2020, 2016 },
                    { 2, 2, "B9", true, "A4", 2019, 2015 },
                    { 25, 1, "G01", true, "X3", 2021, 2017 },
                    { 19, 1, "G11", true, "7 Series", 2020, 2015 },
                    { 13, 1, "G30", true, "5 Series", 2021, 2017 },
                    { 7, 1, "G20", true, "3 Series", 2023, 2019 },
                    { 21, 3, "W222", true, "S-Class", 2020, 2013 },
                    { 24, 6, "X", true, "Crossland", 2021, 2017 }
                });

            migrationBuilder.InsertData(
                table: "CarPartsCompatibility",
                columns: new[] { "CarPartsCompatibilityId", "CarPartId", "GenericCarModelId", "IsValid" },
                values: new object[,]
                {
                    { 6, 6, 7, true },
                    { 70, 17, 21, true },
                    { 49, 22, 27, true },
                    { 3, 3, 4, true },
                    { 26, 25, 4, true },
                    { 53, 17, 4, true },
                    { 9, 9, 10, true },
                    { 32, 5, 10, true },
                    { 59, 6, 10, true },
                    { 15, 15, 16, true },
                    { 38, 11, 16, true },
                    { 65, 12, 16, true },
                    { 44, 17, 22, true },
                    { 71, 18, 22, true },
                    { 4, 4, 5, true },
                    { 54, 1, 5, true },
                    { 10, 10, 11, true },
                    { 33, 6, 11, true },
                    { 40, 13, 18, true },
                    { 17, 17, 18, true },
                    { 61, 8, 12, true },
                    { 34, 7, 12, true },
                    { 11, 11, 12, true },
                    { 55, 2, 6, true },
                    { 43, 16, 21, true },
                    { 28, 1, 6, true },
                    { 50, 23, 29, true },
                    { 45, 18, 23, true },
                    { 66, 13, 17, true },
                    { 39, 12, 17, true },
                    { 16, 16, 17, true },
                    { 60, 7, 11, true },
                    { 5, 5, 6, true },
                    { 64, 11, 15, true },
                    { 37, 10, 15, true },
                    { 27, 25, 15, true },
                    { 30, 3, 8, true },
                    { 7, 7, 8, true },
                    { 51, 14, 2, true },
                    { 23, 23, 2, true },
                    { 1, 1, 2, true },
                    { 47, 20, 25, true },
                    { 57, 4, 8, true },
                    { 68, 15, 19, true },
                    { 18, 18, 19, true },
                    { 62, 9, 13, true },
                    { 35, 8, 13, true },
                    { 12, 12, 13, true },
                    { 56, 3, 7, true },
                    { 29, 2, 7, true },
                    { 41, 14, 19, true },
                    { 67, 14, 18, true },
                    { 13, 13, 14, true },
                    { 63, 10, 14, true },
                    { 14, 14, 15, true },
                    { 58, 5, 9, true },
                    { 31, 4, 9, true },
                    { 8, 8, 9, true },
                    { 52, 16, 3, true },
                    { 24, 24, 3, true },
                    { 36, 9, 14, true },
                    { 2, 2, 3, true },
                    { 69, 16, 20, true },
                    { 42, 15, 20, true },
                    { 22, 22, 20, true },
                    { 21, 21, 20, true },
                    { 20, 20, 20, true },
                    { 19, 19, 20, true },
                    { 48, 21, 26, true },
                    { 46, 19, 24, true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_CustomerId",
                table: "Appointment",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_EmployeeId",
                table: "Appointment",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthenticationCode_CustomerId",
                table: "AuthenticationCode",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthenticationToken_UserAccountId",
                table: "AuthenticationToken",
                column: "UserAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_GenericGenerationCarModelId",
                table: "Car",
                column: "GenericGenerationCarModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CarPartsCompatibility_CarPartId",
                table: "CarPartsCompatibility",
                column: "CarPartId");

            migrationBuilder.CreateIndex(
                name: "IX_CarPartsCompatibility_GenericCarModelId",
                table: "CarPartsCompatibility",
                column: "GenericCarModelId");

            migrationBuilder.CreateIndex(
                name: "IX_GenericCarModel_CarBrandId",
                table: "GenericCarModel",
                column: "CarBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryCarPartLog_CarPartId",
                table: "InventoryCarPartLog",
                column: "CarPartId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryCarPartLog_InventoryLogId",
                table: "InventoryCarPartLog",
                column: "InventoryLogId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_EmployeeId",
                table: "Order",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_CarPartId",
                table: "OrderItem",
                column: "CarPartId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccount_CityId",
                table: "UserAccount",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "AuthenticationCode");

            migrationBuilder.DropTable(
                name: "AuthenticationToken");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "CarPartBrand");

            migrationBuilder.DropTable(
                name: "CarPartsCompatibility");

            migrationBuilder.DropTable(
                name: "ErrorLog");

            migrationBuilder.DropTable(
                name: "InventoryCarPartLog");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "GenericCarModel");

            migrationBuilder.DropTable(
                name: "InventoryLog");

            migrationBuilder.DropTable(
                name: "CarPart");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "CarBrand");

            migrationBuilder.DropTable(
                name: "UserAccount");

            migrationBuilder.DropTable(
                name: "City");
        }
    }
}
