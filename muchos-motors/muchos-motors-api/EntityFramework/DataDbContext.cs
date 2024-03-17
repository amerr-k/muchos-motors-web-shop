using Microsoft.EntityFrameworkCore;
using muchos_motors_api.Enums;
using muchos_motors_api.Models;
using System.Linq;

namespace muchos_motors_api.EntityFramework
{
    public class DataDbContext : DbContext
    {

        public DataDbContext(DbContextOptions options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<AuthenticationCode> AuthenticationCode { get; set; }
        public DbSet<AuthenticationToken> AuthenticationToken { get; set; }
        public DbSet<Car> Car { get; set; }
        public DbSet<CarBrand> CarBrand { get; set; }
        public DbSet<CarPart> CarPart { get; set; }
        public DbSet<CarPartBrand> CarPartBrand { get; set; }
        public DbSet<CarPartsCompatibility> CarPartsCompatibility { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<UserAccount> UserAccount { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<ErrorLog> ErrorLog { get; set; }
        public DbSet<GenericCarModel> GenericCarModel { get; set; }
        public DbSet<InventoryCarPartLog> InventoryCarPartLog { get; set; }
        public DbSet<InventoryLog> InventoryLog { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Parent> Parent { get; set; }
        public DbSet<Child> Child { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserAccount>()
                .HasDiscriminator<string>("UserType")
                .HasValue<Customer>("Customer")
                .HasValue<Employee>("Employee");

            modelBuilder.Entity<UserAccount>()
                .Property<string>("UserType")
                .IsRequired(false);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.NoAction;
            }

            modelBuilder.Entity<CarPartBrand>().HasData(
                    new CarPartBrand { CarPartBrandId = 1, Name = "A.B.S." },
                    new CarPartBrand { CarPartBrandId = 2, Name = "Dinex" },
                    new CarPartBrand { CarPartBrandId = 3, Name = "AC cosmetics" },
                    new CarPartBrand { CarPartBrandId = 4, Name = "Diederichs" },
                    new CarPartBrand { CarPartBrandId = 5, Name = "Airtex" },
                    new CarPartBrand { CarPartBrandId = 6, Name = "AJS" },
                    new CarPartBrand { CarPartBrandId = 7, Name = "Delphi" },
                    new CarPartBrand { CarPartBrandId = 8, Name = "Denso" },
                    new CarPartBrand { CarPartBrandId = 9, Name = "Pascal" },
                    new CarPartBrand { CarPartBrandId = 10, Name = "Payen" },
                    new CarPartBrand { CarPartBrandId = 11, Name = "Peters" }
                );

            modelBuilder.Entity<CarBrand>().HasData(
                new CarBrand { CarBrandId = 1, Name = "BMW", IsValid = true },
                new CarBrand { CarBrandId = 2, Name = "Audi", IsValid = true },
                new CarBrand { CarBrandId = 3, Name = "Mercedes", IsValid = true },
                new CarBrand { CarBrandId = 4, Name = "Skoda", IsValid = true },
                new CarBrand { CarBrandId = 5, Name = "Volkswagen", IsValid = true },
                new CarBrand { CarBrandId = 6, Name = "Opel", IsValid = true }

        );

            modelBuilder.Entity<GenericCarModel>().HasData(
               new GenericCarModel { GenericCarModelId = 1, ModelName = "X5", GenerationName = "G05", ProductionStartYear = 2018, ProductionEndYear = 2022, CarBrandId = 1, IsValid = true },
                new GenericCarModel { GenericCarModelId = 2, ModelName = "A4", GenerationName = "B9", ProductionStartYear = 2015, ProductionEndYear = 2019, CarBrandId = 2, IsValid = true },
                new GenericCarModel { GenericCarModelId = 3, ModelName = "E-Class", GenerationName = "W213", ProductionStartYear = 2016, ProductionEndYear = 2021, CarBrandId = 3, IsValid = true },
                new GenericCarModel { GenericCarModelId = 4, ModelName = "Octavia", GenerationName = "MK3", ProductionStartYear = 2012, ProductionEndYear = 2019, CarBrandId = 4, IsValid = true },
                new GenericCarModel { GenericCarModelId = 5, ModelName = "Golf", GenerationName = "MK7", ProductionStartYear = 2012, ProductionEndYear = 2019, CarBrandId = 5, IsValid = true },
                new GenericCarModel { GenericCarModelId = 6, ModelName = "Astra", GenerationName = "K", ProductionStartYear = 2015, ProductionEndYear = 2021, CarBrandId = 6, IsValid = true },
                new GenericCarModel { GenericCarModelId = 7, ModelName = "3 Series", GenerationName = "G20", ProductionStartYear = 2019, ProductionEndYear = 2023, CarBrandId = 1, IsValid = true },
                new GenericCarModel { GenericCarModelId = 8, ModelName = "Q5", GenerationName = "FY", ProductionStartYear = 2016, ProductionEndYear = 2020, CarBrandId = 2, IsValid = true },
                new GenericCarModel { GenericCarModelId = 9, ModelName = "C-Class", GenerationName = "W205", ProductionStartYear = 2014, ProductionEndYear = 2020, CarBrandId = 3, IsValid = true },
                new GenericCarModel { GenericCarModelId = 10, ModelName = "Superb", GenerationName = "MK3", ProductionStartYear = 2015, ProductionEndYear = 2020, CarBrandId = 4, IsValid = true },
                new GenericCarModel { GenericCarModelId = 11, ModelName = "Tiguan", GenerationName = "MK2", ProductionStartYear = 2016, ProductionEndYear = 2020, CarBrandId = 5, IsValid = true },
                new GenericCarModel { GenericCarModelId = 12, ModelName = "Corsa", GenerationName = "F", ProductionStartYear = 2019, ProductionEndYear = 2023, CarBrandId = 6, IsValid = true },
                new GenericCarModel { GenericCarModelId = 13, ModelName = "5 Series", GenerationName = "G30", ProductionStartYear = 2017, ProductionEndYear = 2021, CarBrandId = 1, IsValid = true },
                new GenericCarModel { GenericCarModelId = 14, ModelName = "A6", GenerationName = "C8", ProductionStartYear = 2018, ProductionEndYear = 2022, CarBrandId = 2, IsValid = true },
                new GenericCarModel { GenericCarModelId = 15, ModelName = "GLC", GenerationName = "X253", ProductionStartYear = 2015, ProductionEndYear = 2020, CarBrandId = 3, IsValid = true },
                new GenericCarModel { GenericCarModelId = 16, ModelName = "Kodiaq", GenerationName = "NS", ProductionStartYear = 2016, ProductionEndYear = 2021, CarBrandId = 4, IsValid = true },
                new GenericCarModel { GenericCarModelId = 17, ModelName = "Arteon", GenerationName = "3H", ProductionStartYear = 2017, ProductionEndYear = 2022, CarBrandId = 5, IsValid = true },
                new GenericCarModel { GenericCarModelId = 18, ModelName = "Insignia", GenerationName = "G2", ProductionStartYear = 2017, ProductionEndYear = 2022, CarBrandId = 6, IsValid = true },
                new GenericCarModel { GenericCarModelId = 19, ModelName = "7 Series", GenerationName = "G11", ProductionStartYear = 2015, ProductionEndYear = 2020, CarBrandId = 1, IsValid = true },
                new GenericCarModel { GenericCarModelId = 20, ModelName = "Q7", GenerationName = "4M", ProductionStartYear = 2015, ProductionEndYear = 2020, CarBrandId = 2, IsValid = true },
                new GenericCarModel { GenericCarModelId = 21, ModelName = "S-Class", GenerationName = "W222", ProductionStartYear = 2013, ProductionEndYear = 2020, CarBrandId = 3, IsValid = true },
                new GenericCarModel { GenericCarModelId = 22, ModelName = "Fabia", GenerationName = "MK3", ProductionStartYear = 2014, ProductionEndYear = 2019, CarBrandId = 4, IsValid = true },
                new GenericCarModel { GenericCarModelId = 23, ModelName = "Passat", GenerationName = "B8", ProductionStartYear = 2014, ProductionEndYear = 2019, CarBrandId = 5, IsValid = true },
                new GenericCarModel { GenericCarModelId = 24, ModelName = "Crossland", GenerationName = "X", ProductionStartYear = 2017, ProductionEndYear = 2021, CarBrandId = 6, IsValid = true },
                new GenericCarModel { GenericCarModelId = 25, ModelName = "X3", GenerationName = "G01", ProductionStartYear = 2017, ProductionEndYear = 2021, CarBrandId = 1, IsValid = true },
                new GenericCarModel { GenericCarModelId = 26, ModelName = "A3", GenerationName = "8V", ProductionStartYear = 2012, ProductionEndYear = 2018, CarBrandId = 2, IsValid = true },
                new GenericCarModel { GenericCarModelId = 27, ModelName = "CLA", GenerationName = "C117", ProductionStartYear = 2013, ProductionEndYear = 2019, CarBrandId = 3, IsValid = true },
                new GenericCarModel { GenericCarModelId = 28, ModelName = "Karoq", GenerationName = "NU", ProductionStartYear = 2017, ProductionEndYear = 2021, CarBrandId = 4, IsValid = true },
                new GenericCarModel { GenericCarModelId = 29, ModelName = "T-Roc", GenerationName = "A1", ProductionStartYear = 2017, ProductionEndYear = 2022, CarBrandId = 5, IsValid = true }
                );


            //modelbuilder
            //    .entity<carpart>()
            //    .property(entity => entity.carpartcategory)
            //    .hasconversion(
            //        value => value.getdisplayname(),
            //        displayname => enumhelper.getenumvalue<carpartcategory>(displayname)
            //    );

            modelBuilder
                .Entity<CarPart>()
                .Property(entity => entity.CarPartCategory)
                .HasConversion<string>();

            modelBuilder.Entity<CarPart>().HasData(
             new CarPart
             {
                 CarPartId = 1,
                 Name = "Pumpa",
                 Code = "XK-2312",
                 SellingPrice = 4.99M,
                 PurchasePrice = 2,
                 WarehouseCount = 10,
                 Details = "dobra roba",
                 CarPartCategory = CarPartCategory.Engine,
                 ImageUrl = "",
                 IsValid = true
             },
             new CarPart
             {
                 CarPartId = 2,
                 Name = "Svjećica",
                 Code = "31-2222",
                 SellingPrice = 42.99M,
                 PurchasePrice = 38,
                 WarehouseCount = 10,
                 Details = "dobra roba",
                 CarPartCategory = CarPartCategory.Engine,
                 ImageUrl = "",
                 IsValid = true
             },
             new CarPart
             {
                 CarPartId = 3,
                 Name = "Ulje za motor",
                 Code = "sf-1111",
                 SellingPrice = 32.99M,
                 PurchasePrice = 30M,
                 WarehouseCount = 10,
                 Details = "Ok",
                 CarPartCategory = CarPartCategory.Engine,
                 ImageUrl = "",
                 IsValid = true
             },
             new CarPart
             {
                 CarPartId = 4,
                 Name = "Kocioni sistem",
                 Code = "zt-3333",
                 SellingPrice = 42.99M,
                 PurchasePrice = 370M,
                 WarehouseCount = 10,
                 Details = "Ok",
                 CarPartCategory = CarPartCategory.BrakeSystem,
                 ImageUrl = "",
                 IsValid = true
             },
             new CarPart
             {
                 CarPartId = 5,
                 Name = "Filter za gorivo",
                 Code = "SS-5512",
                 SellingPrice = 22.99M,
                 PurchasePrice = 16M,
                 WarehouseCount = 10,
                 Details = "Ok",
                 CarPartCategory = CarPartCategory.Engine,
                 ImageUrl = "",
                 IsValid = true
             },
             new CarPart
             {
                 CarPartId = 6,
                 Name = "Akumulator",
                 Code = "ABC-123",
                 SellingPrice = 19.99M,
                 PurchasePrice = 12.5M,
                 WarehouseCount = 10,
                 Details = "Example details",
                 CarPartCategory = CarPartCategory.Electrical,
                 ImageUrl = "",
                 IsValid = true
             },
             new CarPart
             {
                 CarPartId = 7,
                 Name = "Lambda sonda",
                 Code = "XYZ-789",
                 SellingPrice = 29.99M,
                 PurchasePrice = 18.75M,
                 WarehouseCount = 10,
                 Details = "Example details",
                 CarPartCategory = CarPartCategory.ExhaustSystem,
                 ImageUrl = "",
                 IsValid = true
             },
             new CarPart
             {
                 CarPartId = 8,
                 Name = "Filter zraka",
                 Code = "LMN-456",
                 SellingPrice = 15.99M,
                 PurchasePrice = 10.25M,
                 WarehouseCount = 10,
                 Details = "Example details",
                 CarPartCategory = CarPartCategory.Engine,
                 ImageUrl = "",
                 IsValid = true
             },
             new CarPart
             {
                 CarPartId = 9,
                 Name = "Amortizer",
                 Code = "PQR-789",
                 SellingPrice = 59.99M,
                 PurchasePrice = 45.5M,
                 WarehouseCount = 10,
                 Details = "Example details",
                 CarPartCategory = CarPartCategory.Suspension,
                 ImageUrl = "",
                 IsValid = true
             },
             new CarPart
             {
                 CarPartId = 10,
                 Name = "Katalizator",
                 Code = "DEF-012",
                 SellingPrice = 99.99M,
                 PurchasePrice = 85.75M,
                 WarehouseCount = 10,
                 Details = "Example details",
                 CarPartCategory = CarPartCategory.ExhaustSystem,
                 ImageUrl = "",
                 IsValid = true
             },
             new CarPart
             {
                 CarPartId = 11,
                 Name = "Kvačilo",
                 Code = "GHJ-345",
                 SellingPrice = 79.99M,
                 PurchasePrice = 62.5M,
                 WarehouseCount = 10,
                 Details = "Example details",
                 CarPartCategory = CarPartCategory.Transmission,
                 ImageUrl = "",
                 IsValid = true
             },
             new CarPart
             {
                 CarPartId = 12,
                 Name = "Set kvačila",
                 Code = "IJK-678",
                 SellingPrice = 119.99M,
                 PurchasePrice = 95.75M,
                 WarehouseCount = 10,
                 Details = "Example details",
                 CarPartCategory = CarPartCategory.Transmission,
                 ImageUrl = "",
                 IsValid = true
             },
             new CarPart
             {
                 CarPartId = 13,
                 Name = "Senzor položaja bregaste",
                 Code = "MNO-910",
                 SellingPrice = 29.99M,
                 PurchasePrice = 22.5M,
                 WarehouseCount = 10,
                 Details = "Example details",
                 CarPartCategory = CarPartCategory.Engine,
                 ImageUrl = "",
                 IsValid = true
             },
             new CarPart
             {
                 CarPartId = 14,
                 Name = "Rashladni ventilator",
                 Code = "PQR-111",
                 SellingPrice = 49.99M,
                 PurchasePrice = 38.75M,
                 WarehouseCount = 10,
                 Details = "Example details",
                 CarPartCategory = CarPartCategory.Engine,
                 ImageUrl = "",
                 IsValid = true
             },
             new CarPart
             {
                 CarPartId = 15,
                 Name = "Kočioni disk",
                 Code = "STU-222",
                 SellingPrice = 39.99M,
                 PurchasePrice = 28.5M,
                 WarehouseCount = 10,
                 Details = "Example details",
                 CarPartCategory = CarPartCategory.BrakeSystem,
                 ImageUrl = "",
                 IsValid = true
             },
             new CarPart
             {
                 CarPartId = 16,
                 Name = "Zupčasti remen",
                 Code = "VWX-333",
                 SellingPrice = 15.99M,
                 PurchasePrice = 12.75M,
                 WarehouseCount = 10,
                 Details = "Example details",
                 CarPartCategory = CarPartCategory.Engine,
                 ImageUrl = "",
                 IsValid = true
             },
             new CarPart
             {
                 CarPartId = 17,
                 Name = "Amortizer zadnji",
                 Code = "YZA-444",
                 SellingPrice = 69.99M,
                 PurchasePrice = 54.5M,
                 WarehouseCount = 10,
                 Details = "Example details",
                 CarPartCategory = CarPartCategory.Suspension,
                 ImageUrl = "",
                 IsValid = true
             },
             new CarPart
             {
                 CarPartId = 18,
                 Name = "Stabilizator prednji",
                 Code = "BCD-555",
                 SellingPrice = 29.99M,
                 PurchasePrice = 22.75M,
                 WarehouseCount = 10,
                 Details = "Example details",
                 CarPartCategory = CarPartCategory.Suspension,
                 ImageUrl = "",
                 IsValid = true
             },
             new CarPart
             {
                 CarPartId = 19,
                 Name = "Filter ulja",
                 Code = "EFG-666",
                 SellingPrice = 12.99M,
                 PurchasePrice = 9.5M,
                 WarehouseCount = 10,
                 Details = "Example details",
                 CarPartCategory = CarPartCategory.Engine,
                 ImageUrl = "",
                 IsValid = true
             },
             new CarPart
             {
                 CarPartId = 20,
                 Name = "Sonda lambda",
                 Code = "HIJ-777",
                 SellingPrice = 39.99M,
                 PurchasePrice = 32.75M,
                 WarehouseCount = 10,
                 Details = "Example details",
                 CarPartCategory = CarPartCategory.ExhaustSystem,
                 ImageUrl = "",
                 IsValid = true
             },
             new CarPart
             {
                 CarPartId = 21,
                 Name = "Disk kočnica zadnji",
                 Code = "KLM-888",
                 SellingPrice = 25.99M,
                 PurchasePrice = 18.5M,
                 WarehouseCount = 10,
                 Details = "Example details",
                 CarPartCategory = CarPartCategory.BrakeSystem,
                 ImageUrl = "",
                 IsValid = true
             },
             new CarPart
             {
                 CarPartId = 22,
                 Name = "Remen alternatora",
                 Code = "NOP-999",
                 SellingPrice = 10.99M,
                 PurchasePrice = 8.75M,
                 WarehouseCount = 10,
                 Details = "Example details",
                 CarPartCategory = CarPartCategory.Engine,
                 ImageUrl = "",
                 IsValid = true
             },
             new CarPart
             {
                 CarPartId = 23,
                 Name = "Set brava vrata",
                 Code = "QRS-000",
                 SellingPrice = 49.99M,
                 PurchasePrice = 38.5M,
                 WarehouseCount = 10,
                 Details = "Example details",
                 CarPartCategory = CarPartCategory.Exterior,
                 ImageUrl = "",
                 IsValid = true
             },
             new CarPart
             {
                 CarPartId = 24,
                 Name = "Kopča auspuha",
                 Code = "TUV-111",
                 SellingPrice = 8.99M,
                 PurchasePrice = 5.5M,
                 WarehouseCount = 10,
                 Details = "Example details",
                 CarPartCategory = CarPartCategory.Exterior,
                 ImageUrl = "",
                 IsValid = true
             },
             new CarPart
             {
                 CarPartId = 25,
                 Name = "Osovinica",
                 Code = "WXY-222",
                 SellingPrice = 15.99M,
                 PurchasePrice = 12.75M,
                 WarehouseCount = 10,
                 Details = "Example details",
                 CarPartCategory = CarPartCategory.Suspension,
                 ImageUrl = "",
                 IsValid = true
             }
         );

            modelBuilder.Entity<CarPartsCompatibility>().HasData(
       new CarPartsCompatibility { CarPartsCompatibilityId = 1, CarPartId = 1, GenericCarModelId = 2, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 2, CarPartId = 2, GenericCarModelId = 3, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 3, CarPartId = 3, GenericCarModelId = 4, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 4, CarPartId = 4, GenericCarModelId = 5, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 5, CarPartId = 5, GenericCarModelId = 6, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 6, CarPartId = 6, GenericCarModelId = 7, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 7, CarPartId = 7, GenericCarModelId = 8, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 8, CarPartId = 8, GenericCarModelId = 9, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 9, CarPartId = 9, GenericCarModelId = 10, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 10, CarPartId = 10, GenericCarModelId = 11, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 11, CarPartId = 11, GenericCarModelId = 12, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 12, CarPartId = 12, GenericCarModelId = 13, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 13, CarPartId = 13, GenericCarModelId = 14, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 14, CarPartId = 14, GenericCarModelId = 15, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 15, CarPartId = 15, GenericCarModelId = 16, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 16, CarPartId = 16, GenericCarModelId = 17, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 17, CarPartId = 17, GenericCarModelId = 18, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 18, CarPartId = 18, GenericCarModelId = 19, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 19, CarPartId = 19, GenericCarModelId = 20, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 20, CarPartId = 20, GenericCarModelId = 20, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 21, CarPartId = 21, GenericCarModelId = 20, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 22, CarPartId = 22, GenericCarModelId = 20, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 23, CarPartId = 23, GenericCarModelId = 2, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 24, CarPartId = 24, GenericCarModelId = 3, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 26, CarPartId = 25, GenericCarModelId = 4, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 27, CarPartId = 25, GenericCarModelId = 15, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 28, CarPartId = 1, GenericCarModelId = 6, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 29, CarPartId = 2, GenericCarModelId = 7, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 30, CarPartId = 3, GenericCarModelId = 8, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 31, CarPartId = 4, GenericCarModelId = 9, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 32, CarPartId = 5, GenericCarModelId = 10, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 33, CarPartId = 6, GenericCarModelId = 11, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 34, CarPartId = 7, GenericCarModelId = 12, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 35, CarPartId = 8, GenericCarModelId = 13, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 36, CarPartId = 9, GenericCarModelId = 14, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 37, CarPartId = 10, GenericCarModelId = 15, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 38, CarPartId = 11, GenericCarModelId = 16, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 39, CarPartId = 12, GenericCarModelId = 17, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 40, CarPartId = 13, GenericCarModelId = 18, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 41, CarPartId = 14, GenericCarModelId = 19, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 42, CarPartId = 15, GenericCarModelId = 20, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 43, CarPartId = 16, GenericCarModelId = 21, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 44, CarPartId = 17, GenericCarModelId = 22, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 45, CarPartId = 18, GenericCarModelId = 23, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 46, CarPartId = 19, GenericCarModelId = 24, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 47, CarPartId = 20, GenericCarModelId = 25, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 48, CarPartId = 21, GenericCarModelId = 26, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 49, CarPartId = 22, GenericCarModelId = 27, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 50, CarPartId = 23, GenericCarModelId = 29, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 51, CarPartId = 14, GenericCarModelId = 2, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 52, CarPartId = 16, GenericCarModelId = 3, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 53, CarPartId = 17, GenericCarModelId = 4, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 54, CarPartId = 1, GenericCarModelId = 5, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 55, CarPartId = 2, GenericCarModelId = 6, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 56, CarPartId = 3, GenericCarModelId = 7, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 57, CarPartId = 4, GenericCarModelId = 8, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 58, CarPartId = 5, GenericCarModelId = 9, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 59, CarPartId = 6, GenericCarModelId = 10, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 60, CarPartId = 7, GenericCarModelId = 11, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 61, CarPartId = 8, GenericCarModelId = 12, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 62, CarPartId = 9, GenericCarModelId = 13, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 63, CarPartId = 10, GenericCarModelId = 14, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 64, CarPartId = 11, GenericCarModelId = 15, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 65, CarPartId = 12, GenericCarModelId = 16, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 66, CarPartId = 13, GenericCarModelId = 17, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 67, CarPartId = 14, GenericCarModelId = 18, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 68, CarPartId = 15, GenericCarModelId = 19, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 69, CarPartId = 16, GenericCarModelId = 20, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 70, CarPartId = 17, GenericCarModelId = 21, IsValid = true },
       new CarPartsCompatibility { CarPartsCompatibilityId = 71, CarPartId = 18, GenericCarModelId = 22, IsValid = true }
       );

            modelBuilder.Entity<City>().HasData(
              new City { CityId = 1, Name = "Donji Vakuf", PostCode = "72000", IsValid = true },
              new City { CityId = 2, Name = "Mostar", PostCode = "88000", IsValid = true },
              new City { CityId = 3, Name = "Visoko", PostCode = "71300", IsValid = true },
              new City { CityId = 4, Name = "Tuzla", PostCode = "75000", IsValid = true },
              new City { CityId = 5, Name = "Zenica", PostCode = "72000", IsValid = true },
              new City { CityId = 6, Name = "Jablanica", PostCode = "88420", IsValid = true },
              new City { CityId = 7, Name = "Konjic", PostCode = "88400", IsValid = true },
              new City { CityId = 8, Name = "Ljubuški", PostCode = "88320", IsValid = true },
              new City { CityId = 9, Name = "Maglaj", PostCode = "74250", IsValid = true });

            modelBuilder.Entity<Customer>().HasData(
                  new Customer { UserAccountId = 1, FirstName = "Nino", LastName = "Omic", Email = "nino.omic@edu.fit.ba", Phone = "062222222", Address = "Aleja Ljiljana 23", IsValid = true, Username = "NinoO", Password = "nino123" },
                  new Customer { UserAccountId = 2, FirstName = "Dajana", LastName = "Medic", Email = "dajana.medic@fit.ba", Phone = "063333333", Address = "Radinovici bb", IsValid = true, Username = "DajanaM", Password = "dajana123" },
                  new Customer { UserAccountId = 3, FirstName = "Kupac", LastName = "Kupac", Email = "kupac@edu.fit.ba", Phone = "063333333", Address = "Aleja Ljiljana 23", IsValid = true, Username = "kupac", Password = "kupac" },
                  new Customer { UserAccountId = 4, FirstName = "Amer", LastName = "Amer", Email = "amer@edu.fit.ba", Phone = "063333333", Address = "Aleja Ljiljana 23", IsValid = true, Username = "amer", Password = "amer" }
              );
            modelBuilder.Entity<Employee>().HasData(
                 new Employee { UserAccountId = 5, FirstName = "Asmir", LastName = "Šaric", Address = "Zenica bb", Email = "asmir.saric@gmail.com", Username = "AsmirS", Password = "asmir123", IsValid = true },
                 new Employee { UserAccountId = 6, FirstName = "Radnik", LastName = "Radnik", Address = "Zenica bb", Email = "radnik.radnik@gmail.com", Username = "radnik", Password = "radnik", IsValid = true }
                 );

            //      modelBuilder.Entity<ModelVozila>().HasData(
            //new ModelVozila { ModelVozilaId = 1, NazivModela = "E46", MarkaVozilaId = 1 },
            //new ModelVozila { ModelVozilaId = 3, NazivModela = "M5", MarkaVozilaId = 1 },
            //  new ModelVozila { ModelVozilaId = 2, NazivModela = "E220", MarkaVozilaId = 3 }
            //);

            //      modelBuilder.Entity<MarkaVozila>().HasData(
            //   new MarkaVozila { MarkaVozilaId = 1, Naziv = "BMW" },
            //   new MarkaVozila { MarkaVozilaId = 2, Naziv = "Audi" },
            //   new MarkaVozila { MarkaVozilaId = 3, Naziv = "Mercedes" }
            //   );

            //      modelBuilder.Entity<Termin>().HasData(
            //          new Termin { TerminId = 1, DatumTermina = DateTime.Now, VrijemeTerminaOD = DateTime.Now, VrijemeTerminaDO = DateTime.Now.AddHours(2), KupacId = 3, RadnikId = 2, IsOdobreno = true },
            //          new Termin { TerminId = 2, DatumTermina = DateTime.Now, VrijemeTerminaOD = DateTime.Now.AddHours(3), VrijemeTerminaDO = DateTime.Now.AddHours(5), KupacId = 2, IsOdobreno = false, RadnikId = 1 }
            //      );
        }
    }
}
