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
                name: "Districts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    DistId = table.Column<int>(type: "int", nullable: false),
                    StreetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.Id);
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
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
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
                    CityId = table.Column<int>(type: "int", nullable: false),
                    DistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Streets", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AbonPageComments",
                columns: new[] { "Id", "AbonentId", "CommentDateTime", "EmployeeId", "Text" },
                values: new object[] { 1, 1, new DateTime(2023, 12, 4, 11, 23, 35, 540, DateTimeKind.Utc).AddTicks(8382), 1, "Тестовый комментарий" });

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
                table: "Districts",
                columns: new[] { "Id", "CityId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "1-й мкрн" },
                    { 2, 1, "2-й мкрн" },
                    { 3, 1, "4-й мкрн" },
                    { 4, 1, "9-й мкрн" },
                    { 5, 1, "10-й мкрн" },
                    { 6, 1, "11-й мкрн" },
                    { 7, 1, "14-й мкрн" },
                    { 8, 1, "17-й мкрн" },
                    { 9, 1, "18-й мкрн" },
                    { 10, 1, "20-й мкрн" },
                    { 11, 1, "21-й мкрн" },
                    { 12, 1, "22-й мкрн" },
                    { 13, 1, "23-й мкрн" },
                    { 14, 1, "24-й мкрн" },
                    { 15, 2, "Иркутск" },
                    { 16, 3, "Усть-Кут" },
                    { 17, 4, "Железногорск" },
                    { 18, 5, "Вихоревка" }
                });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "CityId", "DistId", "Name", "StreetId" },
                values: new object[,]
                {
                    { 1, 1, 1, "1", 1 },
                    { 2, 1, 3, "52", 5 },
                    { 3, 1, 4, "16", 4 },
                    { 4, 1, 9, "18", 8 },
                    { 5, 1, 14, "26", 10 },
                    { 6, 1, 14, "26", 10 },
                    { 7, 2, 15, "26", 11 },
                    { 8, 3, 16, "26", 12 },
                    { 9, 4, 17, "26", 13 },
                    { 10, 5, 18, "26", 14 }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "AbonentId", "Amount", "Comment", "ManagerId", "PaymentDateTime", "PaymentType" },
                values: new object[] { 1, 1, 10m, "", 1, new DateTime(2023, 12, 4, 11, 23, 35, 540, DateTimeKind.Utc).AddTicks(8410), "" });

            migrationBuilder.InsertData(
                table: "Streets",
                columns: new[] { "Id", "CityId", "DistId", "Name" },
                values: new object[,]
                {
                    { 1, 1, 1, "Мира" },
                    { 2, 1, 1, "Южная" },
                    { 3, 1, 1, "Подбельского" },
                    { 4, 1, 2, "Кирова" },
                    { 5, 1, 3, "Пихтовая" },
                    { 6, 1, 6, "Ленина" },
                    { 7, 1, 7, "Обручева" },
                    { 8, 1, 9, "Советская" },
                    { 9, 1, 11, "Гагарина" },
                    { 10, 1, 14, "Рябикова" },
                    { 11, 2, 15, "Байкальская" },
                    { 12, 3, 16, "Пушкина" },
                    { 13, 4, 17, "2-й квартал" },
                    { 14, 5, 18, "Кошевого" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbonPageComments");

            migrationBuilder.DropTable(
                name: "Abonents");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Houses");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Streets");
        }
    }
}
