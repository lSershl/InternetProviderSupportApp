using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IPSA.API.Migrations
{
    /// <inheritdoc />
    public partial class NewModelsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmloyeeRole = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbonentRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AbonentId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletionDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CompletionTimePeriod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbonentRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbonentRequests_Abonents_AbonentId",
                        column: x => x.AbonentId,
                        principalTable: "Abonents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AbonentRequests_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AbonPageComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CommentDateTime",
                value: new DateTime(2024, 2, 16, 6, 42, 44, 306, DateTimeKind.Utc).AddTicks(817));

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

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "EmloyeeRole", "Name" },
                values: new object[,]
                {
                    { 1, "Менеджер сети", "Менеджеры сети" },
                    { 2, "Техподдержка", "Служба технической поддержки" },
                    { 3, "Наладчик", "Инженеры сети и наладчики" }
                });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Cancelled", "Comment", "PaymentDateTime", "PaymentType" },
                values: new object[] { true, "тест", new DateTime(2024, 2, 16, 6, 42, 44, 306, DateTimeKind.Utc).AddTicks(841), "Наличными в офисе" });

            migrationBuilder.UpdateData(
                table: "Tariffs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 16, 6, 42, 44, 306, DateTimeKind.Utc).AddTicks(865));

            migrationBuilder.UpdateData(
                table: "Tariffs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 16, 6, 42, 44, 306, DateTimeKind.Utc).AddTicks(886));

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DepartmentId", "FullName", "Login", "Password", "RegistrationDateTime", "ShortName" },
                values: new object[,]
                {
                    { 1, 1, "Увалова Александра Николаевна", "manager", "manager", new DateTime(2024, 2, 16, 6, 42, 44, 306, DateTimeKind.Utc).AddTicks(699), "Увалова А." },
                    { 2, 2, "Свиридов Иван Петрович", "techsup", "techsup", new DateTime(2024, 2, 16, 6, 42, 44, 306, DateTimeKind.Utc).AddTicks(720), "Свиридов И." },
                    { 3, 3, "Донских Александр Иванович", "engineer", "engineer", new DateTime(2024, 2, 16, 6, 42, 44, 306, DateTimeKind.Utc).AddTicks(736), "Донских А." }
                });

            migrationBuilder.InsertData(
                table: "AbonentRequests",
                columns: new[] { "Id", "AbonentId", "CompletionDate", "CompletionTimePeriod", "CreationDateTime", "Description", "EmployeeId", "LastUpdateDateTime", "Status", "Type" },
                values: new object[] { 1, 1, new DateOnly(2024, 3, 5), "15:00 - 17:00", new DateTime(2024, 2, 16, 6, 42, 44, 306, DateTimeKind.Utc).AddTicks(789), "Подкл. СПД через роутер абонента, документы выданы, кабеля нет, предв. позвонить", 1, new DateTime(2024, 2, 16, 6, 42, 44, 306, DateTimeKind.Utc).AddTicks(790), "Открыта", "Подключение СПД" });

            migrationBuilder.CreateIndex(
                name: "IX_AbonentRequests_AbonentId",
                table: "AbonentRequests",
                column: "AbonentId");

            migrationBuilder.CreateIndex(
                name: "IX_AbonentRequests_EmployeeId",
                table: "AbonentRequests",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbonentRequests");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.UpdateData(
                table: "AbonPageComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CommentDateTime",
                value: new DateTime(2024, 2, 13, 10, 26, 2, 385, DateTimeKind.Utc).AddTicks(8303));

            migrationBuilder.UpdateData(
                table: "ConnectedTariffs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 13, 10, 26, 2, 385, DateTimeKind.Utc).AddTicks(8400));

            migrationBuilder.UpdateData(
                table: "ConnectedTariffs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 13, 10, 26, 2, 385, DateTimeKind.Utc).AddTicks(8417));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Cancelled", "Comment", "PaymentDateTime", "PaymentType" },
                values: new object[] { false, "", new DateTime(2024, 2, 13, 10, 26, 2, 385, DateTimeKind.Utc).AddTicks(8335), "" });

            migrationBuilder.UpdateData(
                table: "Tariffs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 13, 10, 26, 2, 385, DateTimeKind.Utc).AddTicks(8361));

            migrationBuilder.UpdateData(
                table: "Tariffs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDateTime",
                value: new DateTime(2024, 2, 13, 10, 26, 2, 385, DateTimeKind.Utc).AddTicks(8381));
        }
    }
}
