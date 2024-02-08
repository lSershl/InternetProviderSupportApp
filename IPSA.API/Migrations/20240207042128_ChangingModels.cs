using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IPSA.API.Migrations
{
    /// <inheritdoc />
    public partial class ChangingModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Houses");

            migrationBuilder.DropColumn(
                name: "DistId",
                table: "Streets");

            migrationBuilder.UpdateData(
                table: "AbonPageComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CommentDateTime",
                value: new DateTime(2024, 2, 7, 4, 21, 27, 293, DateTimeKind.Utc).AddTicks(5566));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PaymentDateTime",
                value: new DateTime(2024, 2, 7, 4, 21, 27, 293, DateTimeKind.Utc).AddTicks(5591));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DistId",
                table: "Streets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    CityId = table.Column<int>(type: "int", nullable: false),
                    DistId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AbonPageComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CommentDateTime",
                value: new DateTime(2023, 12, 5, 5, 33, 46, 414, DateTimeKind.Utc).AddTicks(9793));

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

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PaymentDateTime",
                value: new DateTime(2023, 12, 5, 5, 33, 46, 414, DateTimeKind.Utc).AddTicks(9817));

            migrationBuilder.UpdateData(
                table: "Streets",
                keyColumn: "Id",
                keyValue: 1,
                column: "DistId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Streets",
                keyColumn: "Id",
                keyValue: 2,
                column: "DistId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Streets",
                keyColumn: "Id",
                keyValue: 3,
                column: "DistId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Streets",
                keyColumn: "Id",
                keyValue: 4,
                column: "DistId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Streets",
                keyColumn: "Id",
                keyValue: 5,
                column: "DistId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Streets",
                keyColumn: "Id",
                keyValue: 6,
                column: "DistId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Streets",
                keyColumn: "Id",
                keyValue: 7,
                column: "DistId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Streets",
                keyColumn: "Id",
                keyValue: 8,
                column: "DistId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Streets",
                keyColumn: "Id",
                keyValue: 9,
                column: "DistId",
                value: 11);

            migrationBuilder.UpdateData(
                table: "Streets",
                keyColumn: "Id",
                keyValue: 10,
                column: "DistId",
                value: 14);

            migrationBuilder.UpdateData(
                table: "Streets",
                keyColumn: "Id",
                keyValue: 11,
                column: "DistId",
                value: 15);

            migrationBuilder.UpdateData(
                table: "Streets",
                keyColumn: "Id",
                keyValue: 12,
                column: "DistId",
                value: 16);

            migrationBuilder.UpdateData(
                table: "Streets",
                keyColumn: "Id",
                keyValue: 13,
                column: "DistId",
                value: 17);

            migrationBuilder.UpdateData(
                table: "Streets",
                keyColumn: "Id",
                keyValue: 14,
                column: "DistId",
                value: 18);
        }
    }
}
