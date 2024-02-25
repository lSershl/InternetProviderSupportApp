using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IPSA.API.Migrations
{
    /// <inheritdoc />
    public partial class NewDataSeeded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "CreationDateTime", "Description" },
                values: new object[] { new DateTime(2024, 2, 25, 6, 42, 34, 682, DateTimeKind.Utc).AddTicks(6361), "Безлимитный Интернет со скоростью 100 Мбит/сек с ежемесячной платой" });

            migrationBuilder.UpdateData(
                table: "Tariffs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDateTime", "Description" },
                values: new object[] { new DateTime(2024, 2, 25, 6, 42, 34, 682, DateTimeKind.Utc).AddTicks(6382), "Базовый пакет каналов цифрового телевидения с ежемесячной платой" });

            migrationBuilder.InsertData(
                table: "Tariffs",
                columns: new[] { "Id", "Archived", "CreationDateTime", "DailyPrice", "Description", "MonthlyPrice", "Name", "PricingModel", "Type" },
                values: new object[] { 3, false, new DateTime(2024, 2, 25, 6, 42, 34, 682, DateTimeKind.Utc).AddTicks(6398), 50m, "Безлимитный Интернет со скоростью до 100 Мбит/сек с посуточным списанием платы", 0m, "Посуточный Безлимит 100", "Посуточный", "Интернет" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tariffs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AbonPageComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CommentDateTime",
                value: new DateTime(2024, 2, 16, 6, 42, 44, 306, DateTimeKind.Utc).AddTicks(817));

            migrationBuilder.UpdateData(
                table: "AbonentRequests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDateTime", "LastUpdateDateTime" },
                values: new object[] { new DateTime(2024, 2, 16, 6, 42, 44, 306, DateTimeKind.Utc).AddTicks(789), new DateTime(2024, 2, 16, 6, 42, 44, 306, DateTimeKind.Utc).AddTicks(790) });

            migrationBuilder.UpdateData(
                table: "ConnectedTariffs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 16, 6, 42, 44, 306, DateTimeKind.Utc).AddTicks(911));

            migrationBuilder.UpdateData(
                table: "ConnectedTariffs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 16, 6, 42, 44, 306, DateTimeKind.Utc).AddTicks(931));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegistrationDateTime",
                value: new DateTime(2024, 2, 16, 6, 42, 44, 306, DateTimeKind.Utc).AddTicks(699));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegistrationDateTime",
                value: new DateTime(2024, 2, 16, 6, 42, 44, 306, DateTimeKind.Utc).AddTicks(720));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                column: "RegistrationDateTime",
                value: new DateTime(2024, 2, 16, 6, 42, 44, 306, DateTimeKind.Utc).AddTicks(736));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PaymentDateTime",
                value: new DateTime(2024, 2, 16, 6, 42, 44, 306, DateTimeKind.Utc).AddTicks(841));

            migrationBuilder.UpdateData(
                table: "Tariffs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDateTime", "Description" },
                values: new object[] { new DateTime(2024, 2, 16, 6, 42, 44, 306, DateTimeKind.Utc).AddTicks(865), "Безлимитный Интернет со скоростью 100 Мбит/сек" });

            migrationBuilder.UpdateData(
                table: "Tariffs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDateTime", "Description" },
                values: new object[] { new DateTime(2024, 2, 16, 6, 42, 44, 306, DateTimeKind.Utc).AddTicks(886), "Базовый пакет каналов цифрового телевидения" });
        }
    }
}
