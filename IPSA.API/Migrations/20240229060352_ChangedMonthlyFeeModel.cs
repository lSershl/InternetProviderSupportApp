using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IPSA.API.Migrations
{
    /// <inheritdoc />
    public partial class ChangedMonthlyFeeModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MonthlyFees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConnectedTariffId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ScheduledDate = table.Column<DateOnly>(type: "date", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyFees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonthlyFees_ConnectedTariffs_ConnectedTariffId",
                        column: x => x.ConnectedTariffId,
                        principalTable: "ConnectedTariffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AbonPageComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CommentDateTime",
                value: new DateTime(2024, 2, 29, 6, 3, 52, 10, DateTimeKind.Utc).AddTicks(8571));

            migrationBuilder.UpdateData(
                table: "AbonentRequests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDateTime", "LastUpdateDateTime" },
                values: new object[] { new DateTime(2024, 2, 29, 6, 3, 52, 10, DateTimeKind.Utc).AddTicks(8542), new DateTime(2024, 2, 29, 6, 3, 52, 10, DateTimeKind.Utc).AddTicks(8543) });

            migrationBuilder.InsertData(
                table: "Abonents",
                columns: new[] { "Id", "AddressZipCode", "Apartment", "Balance", "BirthPlace", "City", "DateOfBirth", "Email", "FirstName", "House", "HouseEntranceNumber", "HouseFloorNumber", "LastName", "PassportNumber", "PassportRegDate", "PassportRegistration", "PassportSeries", "PhoneNumber", "PhoneNumberForSending", "RegistrationAddress", "RegistrationZipCode", "SMSSending", "SecretPhrase", "Street", "Surname" },
                values: new object[] { 2, "", "1", 300m, "гор. Братск", "Братск", new DateOnly(1989, 5, 9), "petrov_s@gmail.com", "Сергей", "5а", "1", "1", "Петров", "456123", new DateOnly(2018, 1, 8), "ГУ МВД России по Иркутской обл.", "1589", "+78005553535", "+78005553535", "гор. Братск, ул. Мира 1-1", "", false, "Петров", "Советская", "Николаевич" });

            migrationBuilder.UpdateData(
                table: "ConnectedTariffs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 29, 6, 3, 52, 10, DateTimeKind.Utc).AddTicks(8686));

            migrationBuilder.UpdateData(
                table: "ConnectedTariffs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 29, 6, 3, 52, 10, DateTimeKind.Utc).AddTicks(8706));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegistrationDateTime",
                value: new DateTime(2024, 2, 29, 6, 3, 52, 10, DateTimeKind.Utc).AddTicks(8428));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegistrationDateTime",
                value: new DateTime(2024, 2, 29, 6, 3, 52, 10, DateTimeKind.Utc).AddTicks(8454));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                column: "RegistrationDateTime",
                value: new DateTime(2024, 2, 29, 6, 3, 52, 10, DateTimeKind.Utc).AddTicks(8471));

            migrationBuilder.InsertData(
                table: "MonthlyFees",
                columns: new[] { "Id", "Amount", "ConnectedTariffId", "IsCompleted", "ScheduledDate" },
                values: new object[] { 1, 400m, 1, false, new DateOnly(2024, 3, 5) });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PaymentDateTime",
                value: new DateTime(2024, 2, 29, 6, 3, 52, 10, DateTimeKind.Utc).AddTicks(8597));

            migrationBuilder.UpdateData(
                table: "Tariffs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 29, 6, 3, 52, 10, DateTimeKind.Utc).AddTicks(8619));

            migrationBuilder.UpdateData(
                table: "Tariffs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 29, 6, 3, 52, 10, DateTimeKind.Utc).AddTicks(8644));

            migrationBuilder.UpdateData(
                table: "Tariffs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 29, 6, 3, 52, 10, DateTimeKind.Utc).AddTicks(8662));

            migrationBuilder.InsertData(
                table: "ConnectedTariffs",
                columns: new[] { "Id", "AbonentId", "CreationDateTime", "IpAddress", "IsBlocked", "LinkToHardware", "TariffId" },
                values: new object[] { 3, 2, new DateTime(2024, 2, 29, 6, 3, 52, 10, DateTimeKind.Utc).AddTicks(8721), "127.0.0.1", false, "(ссылка на мост к сетевому оборудованию)", 3 });

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyFees_ConnectedTariffId",
                table: "MonthlyFees",
                column: "ConnectedTariffId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MonthlyFees");

            migrationBuilder.DeleteData(
                table: "ConnectedTariffs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Abonents",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AbonPageComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CommentDateTime",
                value: new DateTime(2024, 2, 25, 6, 42, 34, 682, DateTimeKind.Utc).AddTicks(6317));

            migrationBuilder.UpdateData(
                table: "AbonentRequests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDateTime", "LastUpdateDateTime" },
                values: new object[] { new DateTime(2024, 2, 25, 6, 42, 34, 682, DateTimeKind.Utc).AddTicks(6290), new DateTime(2024, 2, 25, 6, 42, 34, 682, DateTimeKind.Utc).AddTicks(6291) });

            migrationBuilder.UpdateData(
                table: "ConnectedTariffs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 25, 6, 42, 34, 682, DateTimeKind.Utc).AddTicks(6418));

            migrationBuilder.UpdateData(
                table: "ConnectedTariffs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 25, 6, 42, 34, 682, DateTimeKind.Utc).AddTicks(6437));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegistrationDateTime",
                value: new DateTime(2024, 2, 25, 6, 42, 34, 682, DateTimeKind.Utc).AddTicks(6201));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegistrationDateTime",
                value: new DateTime(2024, 2, 25, 6, 42, 34, 682, DateTimeKind.Utc).AddTicks(6222));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                column: "RegistrationDateTime",
                value: new DateTime(2024, 2, 25, 6, 42, 34, 682, DateTimeKind.Utc).AddTicks(6238));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PaymentDateTime",
                value: new DateTime(2024, 2, 25, 6, 42, 34, 682, DateTimeKind.Utc).AddTicks(6340));

            migrationBuilder.UpdateData(
                table: "Tariffs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 25, 6, 42, 34, 682, DateTimeKind.Utc).AddTicks(6361));

            migrationBuilder.UpdateData(
                table: "Tariffs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 25, 6, 42, 34, 682, DateTimeKind.Utc).AddTicks(6382));

            migrationBuilder.UpdateData(
                table: "Tariffs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 25, 6, 42, 34, 682, DateTimeKind.Utc).AddTicks(6398));
        }
    }
}
