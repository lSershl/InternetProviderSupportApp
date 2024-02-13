using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IPSA.API.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abonents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    BirthPlace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumberForSending = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassportSeries = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassportNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassportRegistration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassportRegDate = table.Column<DateOnly>(type: "date", nullable: false),
                    RegistrationAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrationZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    House = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apartment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseEntranceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseFloorNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecretPhrase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SMSSending = table.Column<bool>(type: "bit", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abonents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbonPageComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AbonentId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbonPageComments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AbonentId = table.Column<int>(type: "int", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: false),
                    PaymentDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cancelled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Streets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Streets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tariffs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PricingModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MonthlyPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DailyPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Archived = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tariffs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConnectedTariffs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AbonentId = table.Column<int>(type: "int", nullable: false),
                    TariffId = table.Column<int>(type: "int", nullable: false),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkToHardware = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsBlocked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConnectedTariffs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConnectedTariffs_Abonents_AbonentId",
                        column: x => x.AbonentId,
                        principalTable: "Abonents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConnectedTariffs_Tariffs_TariffId",
                        column: x => x.TariffId,
                        principalTable: "Tariffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AbonPageComments",
                columns: new[] { "Id", "AbonentId", "CommentDateTime", "EmployeeId", "Text" },
                values: new object[] { 1, 1, new DateTime(2024, 2, 13, 10, 26, 2, 385, DateTimeKind.Utc).AddTicks(8303), 1, "Тестовый комментарий" });

            migrationBuilder.InsertData(
                table: "Abonents",
                columns: new[] { "Id", "AddressZipCode", "Apartment", "Balance", "BirthPlace", "City", "DateOfBirth", "Email", "FirstName", "House", "HouseEntranceNumber", "HouseFloorNumber", "LastName", "PassportNumber", "PassportRegDate", "PassportRegistration", "PassportSeries", "PhoneNumber", "PhoneNumberForSending", "RegistrationAddress", "RegistrationZipCode", "SMSSending", "SecretPhrase", "Street", "Surname" },
                values: new object[] { 1, "", "3", 0m, "гор. Братск", "Братск", new DateOnly(1993, 1, 10), "sample@gmail.com", "Иван", "1", "1", "2", "Иванов", "334455", new DateOnly(2020, 1, 10), "ГУ МВД России по Иркутской обл.", "1122", "+78005553535", "+78005553535", "гор. Братск, ул. Городская 1-1", "", false, "Код. слово", "Советская", "Иванович" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Братск" },
                    { 2, "Иркутск" },
                    { 3, "Усть-Кут" },
                    { 4, "Железногорск" },
                    { 5, "Вихоревка" }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "AbonentId", "Amount", "Cancelled", "Comment", "ManagerId", "PaymentDateTime", "PaymentType" },
                values: new object[] { 1, 1, 10m, false, "", 1, new DateTime(2024, 2, 13, 10, 26, 2, 385, DateTimeKind.Utc).AddTicks(8335), "" });

            migrationBuilder.InsertData(
                table: "Streets",
                columns: new[] { "Id", "CityId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Мира" },
                    { 2, 1, "Южная" },
                    { 3, 1, "Подбельского" },
                    { 4, 1, "Кирова" },
                    { 5, 1, "Пихтовая" },
                    { 6, 1, "Ленина" },
                    { 7, 1, "Обручева" },
                    { 8, 1, "Советская" },
                    { 9, 1, "Гагарина" },
                    { 10, 1, "Рябикова" },
                    { 11, 2, "Байкальская" },
                    { 12, 3, "Пушкина" },
                    { 13, 4, "2-й квартал" },
                    { 14, 5, "Кошевого" }
                });

            migrationBuilder.InsertData(
                table: "Tariffs",
                columns: new[] { "Id", "Archived", "CreationDateTime", "DailyPrice", "Description", "MonthlyPrice", "Name", "PricingModel", "Type" },
                values: new object[,]
                {
                    { 1, false, new DateTime(2024, 2, 13, 10, 26, 2, 385, DateTimeKind.Utc).AddTicks(8361), 13.4m, "Безлимитный Интернет со скоростью 100 Мбит/сек", 400m, "Безлимитный 100", "Месячный", "Интернет" },
                    { 2, false, new DateTime(2024, 2, 13, 10, 26, 2, 385, DateTimeKind.Utc).AddTicks(8381), 6.7m, "Базовый пакет каналов цифрового телевидения", 200m, "Базовое ЦКТВ", "Месячный", "ЦКТВ" }
                });

            migrationBuilder.InsertData(
                table: "ConnectedTariffs",
                columns: new[] { "Id", "AbonentId", "CreationDateTime", "IpAddress", "IsBlocked", "LinkToHardware", "TariffId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 2, 13, 10, 26, 2, 385, DateTimeKind.Utc).AddTicks(8400), "127.0.0.1", false, "(ссылка на мост к сетевому оборудованию)", 1 },
                    { 2, 1, new DateTime(2024, 2, 13, 10, 26, 2, 385, DateTimeKind.Utc).AddTicks(8417), "127.0.0.1", false, "(ссылка на мост к сетевому оборудованию)", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConnectedTariffs_AbonentId",
                table: "ConnectedTariffs",
                column: "AbonentId");

            migrationBuilder.CreateIndex(
                name: "IX_ConnectedTariffs_TariffId",
                table: "ConnectedTariffs",
                column: "TariffId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbonPageComments");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "ConnectedTariffs");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Streets");

            migrationBuilder.DropTable(
                name: "Abonents");

            migrationBuilder.DropTable(
                name: "Tariffs");
        }
    }
}
