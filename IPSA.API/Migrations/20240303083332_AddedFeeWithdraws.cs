using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IPSA.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedFeeWithdraws : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FeeWithdraws",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AbonentId = table.Column<int>(type: "int", nullable: false),
                    ConnectedTariffId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CompletionDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeeWithdraws", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeeWithdraws_Abonents_AbonentId",
                        column: x => x.AbonentId,
                        principalTable: "Abonents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FeeWithdraws_ConnectedTariffs_ConnectedTariffId",
                        column: x => x.ConnectedTariffId,
                        principalTable: "ConnectedTariffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.UpdateData(
                table: "AbonPageComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CommentDateTime",
                value: new DateTime(2024, 3, 3, 8, 33, 31, 183, DateTimeKind.Utc).AddTicks(5786));

            migrationBuilder.UpdateData(
                table: "AbonentRequests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDateTime", "LastUpdateDateTime" },
                values: new object[] { new DateTime(2024, 3, 3, 8, 33, 31, 183, DateTimeKind.Utc).AddTicks(5720), new DateTime(2024, 3, 3, 8, 33, 31, 183, DateTimeKind.Utc).AddTicks(5721) });

            migrationBuilder.UpdateData(
                table: "ConnectedTariffs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDateTime",
                value: new DateTime(2024, 3, 3, 8, 33, 31, 183, DateTimeKind.Utc).AddTicks(5900));

            migrationBuilder.UpdateData(
                table: "ConnectedTariffs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDateTime",
                value: new DateTime(2024, 3, 3, 8, 33, 31, 183, DateTimeKind.Utc).AddTicks(5921));

            migrationBuilder.UpdateData(
                table: "ConnectedTariffs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDateTime",
                value: new DateTime(2024, 3, 3, 8, 33, 31, 183, DateTimeKind.Utc).AddTicks(5938));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegistrationDateTime",
                value: new DateTime(2024, 3, 3, 8, 33, 31, 183, DateTimeKind.Utc).AddTicks(5607));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegistrationDateTime",
                value: new DateTime(2024, 3, 3, 8, 33, 31, 183, DateTimeKind.Utc).AddTicks(5626));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                column: "RegistrationDateTime",
                value: new DateTime(2024, 3, 3, 8, 33, 31, 183, DateTimeKind.Utc).AddTicks(5642));

            migrationBuilder.InsertData(
                table: "FeeWithdraws",
                columns: new[] { "Id", "AbonentId", "Amount", "CompletionDateTime", "ConnectedTariffId", "Type" },
                values: new object[,]
                {
                    { 1, 1, 400m, new DateTime(2024, 3, 3, 8, 33, 31, 183, DateTimeKind.Utc).AddTicks(5958), 1, "Месячный" },
                    { 2, 1, 200m, new DateTime(2024, 3, 3, 8, 33, 31, 183, DateTimeKind.Utc).AddTicks(5976), 2, "Месячный" },
                    { 3, 2, 50m, new DateTime(2024, 3, 3, 8, 33, 31, 183, DateTimeKind.Utc).AddTicks(5991), 3, "Посуточный" }
                });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PaymentDateTime",
                value: new DateTime(2024, 3, 3, 8, 33, 31, 183, DateTimeKind.Utc).AddTicks(5815));

            migrationBuilder.UpdateData(
                table: "Tariffs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDateTime",
                value: new DateTime(2024, 3, 3, 8, 33, 31, 183, DateTimeKind.Utc).AddTicks(5838));

            migrationBuilder.UpdateData(
                table: "Tariffs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDateTime",
                value: new DateTime(2024, 3, 3, 8, 33, 31, 183, DateTimeKind.Utc).AddTicks(5858));

            migrationBuilder.UpdateData(
                table: "Tariffs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDateTime",
                value: new DateTime(2024, 3, 3, 8, 33, 31, 183, DateTimeKind.Utc).AddTicks(5876));

            migrationBuilder.CreateIndex(
                name: "IX_FeeWithdraws_AbonentId",
                table: "FeeWithdraws",
                column: "AbonentId");

            migrationBuilder.CreateIndex(
                name: "IX_FeeWithdraws_ConnectedTariffId",
                table: "FeeWithdraws",
                column: "ConnectedTariffId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeeWithdraws");

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
        }
    }
}
