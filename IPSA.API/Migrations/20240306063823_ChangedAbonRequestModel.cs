using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IPSA.API.Migrations
{
    /// <inheritdoc />
    public partial class ChangedAbonRequestModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AllocatedEngineer",
                table: "AbonentRequests",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

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
                columns: new[] { "AllocatedEngineer", "CreationDateTime", "LastUpdateDateTime" },
                values: new object[] { "", new DateTime(2024, 3, 6, 6, 38, 21, 909, DateTimeKind.Utc).AddTicks(2666), new DateTime(2024, 3, 6, 6, 38, 21, 909, DateTimeKind.Utc).AddTicks(2666) });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllocatedEngineer",
                table: "AbonentRequests");

            migrationBuilder.UpdateData(
                table: "AbonPageComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CommentDateTime",
                value: new DateTime(2024, 3, 4, 3, 52, 4, 787, DateTimeKind.Utc).AddTicks(6736));

            migrationBuilder.UpdateData(
                table: "AbonentRequests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDateTime", "LastUpdateDateTime" },
                values: new object[] { new DateTime(2024, 3, 4, 3, 52, 4, 787, DateTimeKind.Utc).AddTicks(6682), new DateTime(2024, 3, 4, 3, 52, 4, 787, DateTimeKind.Utc).AddTicks(6683) });

            migrationBuilder.UpdateData(
                table: "ConnectedTariffs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDateTime",
                value: new DateTime(2024, 3, 4, 3, 52, 4, 787, DateTimeKind.Utc).AddTicks(6842));

            migrationBuilder.UpdateData(
                table: "ConnectedTariffs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDateTime",
                value: new DateTime(2024, 3, 4, 3, 52, 4, 787, DateTimeKind.Utc).AddTicks(6862));

            migrationBuilder.UpdateData(
                table: "ConnectedTariffs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDateTime",
                value: new DateTime(2024, 3, 4, 3, 52, 4, 787, DateTimeKind.Utc).AddTicks(6877));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegistrationDateTime",
                value: new DateTime(2024, 3, 4, 3, 52, 4, 787, DateTimeKind.Utc).AddTicks(6569));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegistrationDateTime",
                value: new DateTime(2024, 3, 4, 3, 52, 4, 787, DateTimeKind.Utc).AddTicks(6589));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                column: "RegistrationDateTime",
                value: new DateTime(2024, 3, 4, 3, 52, 4, 787, DateTimeKind.Utc).AddTicks(6605));

            migrationBuilder.UpdateData(
                table: "FeeWithdraws",
                keyColumn: "Id",
                keyValue: 1,
                column: "CompletionDateTime",
                value: new DateTime(2024, 3, 4, 3, 52, 4, 787, DateTimeKind.Utc).AddTicks(6898));

            migrationBuilder.UpdateData(
                table: "FeeWithdraws",
                keyColumn: "Id",
                keyValue: 2,
                column: "CompletionDateTime",
                value: new DateTime(2024, 3, 4, 3, 52, 4, 787, DateTimeKind.Utc).AddTicks(6914));

            migrationBuilder.UpdateData(
                table: "FeeWithdraws",
                keyColumn: "Id",
                keyValue: 3,
                column: "CompletionDateTime",
                value: new DateTime(2024, 3, 4, 3, 52, 4, 787, DateTimeKind.Utc).AddTicks(6930));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PaymentDateTime",
                value: new DateTime(2024, 3, 4, 3, 52, 4, 787, DateTimeKind.Utc).AddTicks(6763));

            migrationBuilder.UpdateData(
                table: "Tariffs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDateTime",
                value: new DateTime(2024, 3, 4, 3, 52, 4, 787, DateTimeKind.Utc).AddTicks(6784));

            migrationBuilder.UpdateData(
                table: "Tariffs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDateTime",
                value: new DateTime(2024, 3, 4, 3, 52, 4, 787, DateTimeKind.Utc).AddTicks(6804));

            migrationBuilder.UpdateData(
                table: "Tariffs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDateTime",
                value: new DateTime(2024, 3, 4, 3, 52, 4, 787, DateTimeKind.Utc).AddTicks(6821));
        }
    }
}
