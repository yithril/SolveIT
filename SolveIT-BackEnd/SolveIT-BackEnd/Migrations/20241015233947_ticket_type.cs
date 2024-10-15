using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolveIT_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class ticket_type : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TicketType",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 15, 23, 39, 46, 960, DateTimeKind.Utc).AddTicks(6913));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 15, 23, 39, 46, 960, DateTimeKind.Utc).AddTicks(6914));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 15, 23, 39, 46, 960, DateTimeKind.Utc).AddTicks(6793));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 15, 23, 39, 46, 960, DateTimeKind.Utc).AddTicks(6795));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 15, 23, 39, 46, 960, DateTimeKind.Utc).AddTicks(6885));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 15, 23, 39, 46, 960, DateTimeKind.Utc).AddTicks(6886));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 15, 23, 39, 46, 960, DateTimeKind.Utc).AddTicks(6932));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketType",
                table: "Tickets");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 15, 22, 40, 50, 127, DateTimeKind.Utc).AddTicks(1709));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 15, 22, 40, 50, 127, DateTimeKind.Utc).AddTicks(1710));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 15, 22, 40, 50, 127, DateTimeKind.Utc).AddTicks(1598));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 15, 22, 40, 50, 127, DateTimeKind.Utc).AddTicks(1599));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 15, 22, 40, 50, 127, DateTimeKind.Utc).AddTicks(1696));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 15, 22, 40, 50, 127, DateTimeKind.Utc).AddTicks(1697));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 15, 22, 40, 50, 127, DateTimeKind.Utc).AddTicks(1753));
        }
    }
}
