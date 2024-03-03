using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IPSA.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedDailyFeeModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DailyFees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConnectedTariffId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyFees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyFees_ConnectedTariffs_ConnectedTariffId",
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
                value: new DateTime(2024, 3, 1, 5, 54, 47, 782, DateTimeKind.Utc).AddTicks(6894));

            migrationBuilder.UpdateData(
                table: "AbonentRequests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDateTime", "LastUpdateDateTime" },
                values: new object[] { new DateTime(2024, 3, 1, 5, 54, 47, 782, DateTimeKind.Utc).AddTicks(6868), new DateTime(2024, 3, 1, 5, 54, 47, 782, DateTimeKind.Utc).AddTicks(6869) });

            migrationBuilder.UpdateData(
                table: "ConnectedTariffs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDateTime",
                value: new DateTime(2024, 3, 1, 5, 54, 47, 782, DateTimeKind.Utc).AddTicks(7006));

            migrationBuilder.UpdateData(
                table: "ConnectedTariffs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDateTime",
                value: new DateTime(2024, 3, 1, 5, 54, 47, 782, DateTimeKind.Utc).AddTicks(7025));

            migrationBuilder.UpdateData(
                table: "ConnectedTariffs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDateTime",
                value: new DateTime(2024, 3, 1, 5, 54, 47, 782, DateTimeKind.Utc).AddTicks(7041));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegistrationDateTime",
                value: new DateTime(2024, 3, 1, 5, 54, 47, 782, DateTimeKind.Utc).AddTicks(6714));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegistrationDateTime",
                value: new DateTime(2024, 3, 1, 5, 54, 47, 782, DateTimeKind.Utc).AddTicks(6735));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                column: "RegistrationDateTime",
                value: new DateTime(2024, 3, 1, 5, 54, 47, 782, DateTimeKind.Utc).AddTicks(6751));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PaymentDateTime",
                value: new DateTime(2024, 3, 1, 5, 54, 47, 782, DateTimeKind.Utc).AddTicks(6920));

            migrationBuilder.UpdateData(
                table: "Tariffs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDateTime",
                value: new DateTime(2024, 3, 1, 5, 54, 47, 782, DateTimeKind.Utc).AddTicks(6943));

            migrationBuilder.UpdateData(
                table: "Tariffs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDateTime",
                value: new DateTime(2024, 3, 1, 5, 54, 47, 782, DateTimeKind.Utc).AddTicks(6970));

            migrationBuilder.UpdateData(
                table: "Tariffs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDateTime",
                value: new DateTime(2024, 3, 1, 5, 54, 47, 782, DateTimeKind.Utc).AddTicks(6987));

            migrationBuilder.CreateIndex(
                name: "IX_DailyFees_ConnectedTariffId",
                table: "DailyFees",
                column: "ConnectedTariffId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyFees");

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
                table: "ConnectedTariffs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 29, 6, 3, 52, 10, DateTimeKind.Utc).AddTicks(8721));

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
        }
    }
}
