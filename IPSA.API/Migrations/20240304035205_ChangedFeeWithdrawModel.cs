using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IPSA.API.Migrations
{
    /// <inheritdoc />
    public partial class ChangedFeeWithdrawModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PricingModel",
                table: "FeeWithdraws",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
                columns: new[] { "CompletionDateTime", "PricingModel", "Type" },
                values: new object[] { new DateTime(2024, 3, 4, 3, 52, 4, 787, DateTimeKind.Utc).AddTicks(6898), "Месячный", "Списание" });

            migrationBuilder.UpdateData(
                table: "FeeWithdraws",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CompletionDateTime", "PricingModel", "Type" },
                values: new object[] { new DateTime(2024, 3, 4, 3, 52, 4, 787, DateTimeKind.Utc).AddTicks(6914), "Месячный", "Списание" });

            migrationBuilder.UpdateData(
                table: "FeeWithdraws",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CompletionDateTime", "PricingModel", "Type" },
                values: new object[] { new DateTime(2024, 3, 4, 3, 52, 4, 787, DateTimeKind.Utc).AddTicks(6930), "Посуточный", "Списание" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PricingModel",
                table: "FeeWithdraws");

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

            migrationBuilder.UpdateData(
                table: "FeeWithdraws",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CompletionDateTime", "Type" },
                values: new object[] { new DateTime(2024, 3, 3, 8, 33, 31, 183, DateTimeKind.Utc).AddTicks(5958), "Месячный" });

            migrationBuilder.UpdateData(
                table: "FeeWithdraws",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CompletionDateTime", "Type" },
                values: new object[] { new DateTime(2024, 3, 3, 8, 33, 31, 183, DateTimeKind.Utc).AddTicks(5976), "Месячный" });

            migrationBuilder.UpdateData(
                table: "FeeWithdraws",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CompletionDateTime", "Type" },
                values: new object[] { new DateTime(2024, 3, 3, 8, 33, 31, 183, DateTimeKind.Utc).AddTicks(5991), "Посуточный" });

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
        }
    }
}
