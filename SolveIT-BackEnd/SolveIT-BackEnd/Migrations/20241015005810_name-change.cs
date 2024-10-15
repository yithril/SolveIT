using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolveIT_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class namechange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Ticket_TicketId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Departments_DepartmentId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketUser_Ticket_TicketId",
                table: "TicketUser");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketUser_Users_UserId",
                table: "TicketUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketUser",
                table: "TicketUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket");

            migrationBuilder.RenameTable(
                name: "TicketUser",
                newName: "TicketUsers");

            migrationBuilder.RenameTable(
                name: "Ticket",
                newName: "Tickets");

            migrationBuilder.RenameIndex(
                name: "IX_TicketUser_UserId",
                table: "TicketUsers",
                newName: "IX_TicketUsers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketUser_TicketId",
                table: "TicketUsers",
                newName: "IX_TicketUsers_TicketId");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_DepartmentId",
                table: "Tickets",
                newName: "IX_Tickets_DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketUsers",
                table: "TicketUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "IsActive" },
                values: new object[] { new DateTime(2024, 10, 15, 0, 58, 10, 109, DateTimeKind.Utc).AddTicks(3097), true });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "IsActive" },
                values: new object[] { new DateTime(2024, 10, 15, 0, 58, 10, 109, DateTimeKind.Utc).AddTicks(3099), true });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "IsActive" },
                values: new object[] { new DateTime(2024, 10, 15, 0, 58, 10, 109, DateTimeKind.Utc).AddTicks(3008), true });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "IsActive" },
                values: new object[] { new DateTime(2024, 10, 15, 0, 58, 10, 109, DateTimeKind.Utc).AddTicks(3009), true });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 15, 0, 58, 10, 109, DateTimeKind.Utc).AddTicks(3119));

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Tickets_TicketId",
                table: "Comments",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Departments_DepartmentId",
                table: "Tickets",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketUsers_Tickets_TicketId",
                table: "TicketUsers",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketUsers_Users_UserId",
                table: "TicketUsers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Tickets_TicketId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Departments_DepartmentId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketUsers_Tickets_TicketId",
                table: "TicketUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketUsers_Users_UserId",
                table: "TicketUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketUsers",
                table: "TicketUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets");

            migrationBuilder.RenameTable(
                name: "TicketUsers",
                newName: "TicketUser");

            migrationBuilder.RenameTable(
                name: "Tickets",
                newName: "Ticket");

            migrationBuilder.RenameIndex(
                name: "IX_TicketUsers_UserId",
                table: "TicketUser",
                newName: "IX_TicketUser_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketUsers_TicketId",
                table: "TicketUser",
                newName: "IX_TicketUser_TicketId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_DepartmentId",
                table: "Ticket",
                newName: "IX_Ticket_DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketUser",
                table: "TicketUser",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "IsActive" },
                values: new object[] { new DateTime(2024, 10, 11, 1, 51, 32, 112, DateTimeKind.Utc).AddTicks(3861), false });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "IsActive" },
                values: new object[] { new DateTime(2024, 10, 11, 1, 51, 32, 112, DateTimeKind.Utc).AddTicks(3863), false });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "IsActive" },
                values: new object[] { new DateTime(2024, 10, 11, 1, 51, 32, 112, DateTimeKind.Utc).AddTicks(3790), false });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "IsActive" },
                values: new object[] { new DateTime(2024, 10, 11, 1, 51, 32, 112, DateTimeKind.Utc).AddTicks(3792), false });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 11, 1, 51, 32, 112, DateTimeKind.Utc).AddTicks(3878));

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Ticket_TicketId",
                table: "Comments",
                column: "TicketId",
                principalTable: "Ticket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Departments_DepartmentId",
                table: "Ticket",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketUser_Ticket_TicketId",
                table: "TicketUser",
                column: "TicketId",
                principalTable: "Ticket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketUser_Users_UserId",
                table: "TicketUser",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
