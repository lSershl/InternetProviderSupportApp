using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IPSA.API.Migrations
{
    /// <inheritdoc />
    public partial class ChangedConnectedTariffModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAutoblocked",
                table: "ConnectedTariffs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AbonPageComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CommentDateTime",
                value: new DateTime(2024, 3, 10, 7, 48, 22, 42, DateTimeKind.Utc).AddTicks(5453));

            migrationBuilder.UpdateData(
                table: "AbonentRequests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDateTime", "LastUpdateDateTime" },
                values: new object[] { new DateTime(2024, 3, 10, 7, 48, 22, 42, DateTimeKind.Utc).AddTicks(5424), new DateTime(2024, 3, 10, 7, 48, 22, 42, DateTimeKind.Utc).AddTicks(5424) });

            migrationBuilder.UpdateData(
                table: "ConnectedTariffs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDateTime", "IsAutoblocked" },
                values: new object[] { new DateTime(2024, 3, 10, 7, 48, 22, 42, DateTimeKind.Utc).AddTicks(5593), false });

            migrationBuilder.UpdateData(
                table: "ConnectedTariffs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDateTime", "IsAutoblocked" },
                values: new object[] { new DateTime(2024, 3, 10, 7, 48, 22, 42, DateTimeKind.Utc).AddTicks(5613), false });

            migrationBuilder.UpdateData(
                table: "ConnectedTariffs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDateTime", "IsAutoblocked" },
                values: new object[] { new DateTime(2024, 3, 10, 7, 48, 22, 42, DateTimeKind.Utc).AddTicks(5628), false });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegistrationDateTime",
                value: new DateTime(2024, 3, 10, 7, 48, 22, 42, DateTimeKind.Utc).AddTicks(5316));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegistrationDateTime",
                value: new DateTime(2024, 3, 10, 7, 48, 22, 42, DateTimeKind.Utc).AddTicks(5336));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                column: "RegistrationDateTime",
                value: new DateTime(2024, 3, 10, 7, 48, 22, 42, DateTimeKind.Utc).AddTicks(5350));

            migrationBuilder.UpdateData(
                table: "FeeWithdraws",
                keyColumn: "Id",
                keyValue: 1,
                column: "CompletionDateTime",
                value: new DateTime(2024, 3, 10, 7, 48, 22, 42, DateTimeKind.Utc).AddTicks(5650));

            migrationBuilder.UpdateData(
                table: "FeeWithdraws",
                keyColumn: "Id",
                keyValue: 2,
                column: "CompletionDateTime",
                value: new DateTime(2024, 3, 10, 7, 48, 22, 42, DateTimeKind.Utc).AddTicks(5667));

            migrationBuilder.UpdateData(
                table: "FeeWithdraws",
                keyColumn: "Id",
                keyValue: 3,
                column: "CompletionDateTime",
                value: new DateTime(2024, 3, 10, 7, 48, 22, 42, DateTimeKind.Utc).AddTicks(5682));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PaymentDateTime",
                value: new DateTime(2024, 3, 10, 7, 48, 22, 42, DateTimeKind.Utc).AddTicks(5483));

            migrationBuilder.UpdateData(
                table: "Tariffs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDateTime",
                value: new DateTime(2024, 3, 10, 7, 48, 22, 42, DateTimeKind.Utc).AddTicks(5507));

            migrationBuilder.UpdateData(
                table: "Tariffs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDateTime",
                value: new DateTime(2024, 3, 10, 7, 48, 22, 42, DateTimeKind.Utc).AddTicks(5554));

            migrationBuilder.UpdateData(
                table: "Tariffs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDateTime",
                value: new DateTime(2024, 3, 10, 7, 48, 22, 42, DateTimeKind.Utc).AddTicks(5572));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAutoblocked",
                table: "ConnectedTariffs");

            migrationBuilder.UpdateData(
                table: "AbonPageComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CommentDateTime",
                value: new DateTime(2024, 3, 6, 6, 38, 21, 909, DateTimeKind.Utc).AddTicks(2698));

            migrationBuilder.UpdateData(
                table: "AbonentRequests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDateTime", "LastUpdateDateTime" },
                values: new object[] { new DateTime(2024, 3, 6, 6, 38, 21, 909, DateTimeKind.Utc).AddTicks(2666), new DateTime(2024, 3, 6, 6, 38, 21, 909, DateTimeKind.Utc).AddTicks(2666) });

            migrationBuilder.UpdateData(
                table: "ConnectedTariffs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDateTime",
                value: new DateTime(2024, 3, 6, 6, 38, 21, 909, DateTimeKind.Utc).AddTicks(2814));

            migrationBuilder.UpdateData(
                table: "ConnectedTariffs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDateTime",
                value: new DateTime(2024, 3, 6, 6, 38, 21, 909, DateTimeKind.Utc).AddTicks(2873));

            migrationBuilder.UpdateData(
                table: "ConnectedTariffs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDateTime",
                value: new DateTime(2024, 3, 6, 6, 38, 21, 909, DateTimeKind.Utc).AddTicks(2889));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegistrationDateTime",
                value: new DateTime(2024, 3, 6, 6, 38, 21, 909, DateTimeKind.Utc).AddTicks(2553));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegistrationDateTime",
                value: new DateTime(2024, 3, 6, 6, 38, 21, 909, DateTimeKind.Utc).AddTicks(2575));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                column: "RegistrationDateTime",
                value: new DateTime(2024, 3, 6, 6, 38, 21, 909, DateTimeKind.Utc).AddTicks(2589));

            migrationBuilder.UpdateData(
                table: "FeeWithdraws",
                keyColumn: "Id",
                keyValue: 1,
                column: "CompletionDateTime",
                value: new DateTime(2024, 3, 6, 6, 38, 21, 909, DateTimeKind.Utc).AddTicks(2913));

            migrationBuilder.UpdateData(
                table: "FeeWithdraws",
                keyColumn: "Id",
                keyValue: 2,
                column: "CompletionDateTime",
                value: new DateTime(2024, 3, 6, 6, 38, 21, 909, DateTimeKind.Utc).AddTicks(2930));

            migrationBuilder.UpdateData(
                table: "FeeWithdraws",
                keyColumn: "Id",
                keyValue: 3,
                column: "CompletionDateTime",
                value: new DateTime(2024, 3, 6, 6, 38, 21, 909, DateTimeKind.Utc).AddTicks(2944));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PaymentDateTime",
                value: new DateTime(2024, 3, 6, 6, 38, 21, 909, DateTimeKind.Utc).AddTicks(2730));

            migrationBuilder.UpdateData(
                table: "Tariffs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDateTime",
                value: new DateTime(2024, 3, 6, 6, 38, 21, 909, DateTimeKind.Utc).AddTicks(2753));

            migrationBuilder.UpdateData(
                table: "Tariffs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDateTime",
                value: new DateTime(2024, 3, 6, 6, 38, 21, 909, DateTimeKind.Utc).AddTicks(2776));

            migrationBuilder.UpdateData(
                table: "Tariffs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDateTime",
                value: new DateTime(2024, 3, 6, 6, 38, 21, 909, DateTimeKind.Utc).AddTicks(2794));
        }
    }
}
