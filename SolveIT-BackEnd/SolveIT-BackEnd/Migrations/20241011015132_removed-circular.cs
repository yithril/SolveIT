using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SolveIT_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class removedcircular : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_CreatedById",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_UpdatedById",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Users_CreatedById",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Users_UpdatedById",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Users_CreatedById",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Users_UpdatedById",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Users_CreatedById",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Users_UpdatedById",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketUser_Users_CreatedById",
                table: "TicketUser");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketUser_Users_UpdatedById",
                table: "TicketUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_CreatedById",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_UpdatedById",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CreatedById",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UpdatedById",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_TicketUser_CreatedById",
                table: "TicketUser");

            migrationBuilder.DropIndex(
                name: "IX_TicketUser_UpdatedById",
                table: "TicketUser");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_CreatedById",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_UpdatedById",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Roles_CreatedById",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_UpdatedById",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Departments_CreatedById",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_UpdatedById",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_CreatedById",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_UpdatedById",
                table: "Comments");

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Address", "City", "Country", "CreatedById", "CreatedOn", "IsActive", "Name", "UpdatedById", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, "123 Street", "Nowhere", 0, 1, new DateTime(2024, 10, 11, 1, 51, 32, 112, DateTimeKind.Utc).AddTicks(3861), false, "IT", null, null },
                    { 2, "123 Street", "Nowhere", 0, 1, new DateTime(2024, 10, 11, 1, 51, 32, 112, DateTimeKind.Utc).AddTicks(3863), false, "HR", null, null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedById", "CreatedOn", "Description", "IsActive", "Name", "UpdatedById", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 10, 11, 1, 51, 32, 112, DateTimeKind.Utc).AddTicks(3790), "Whatevs", false, "Admin", null, null },
                    { 2, 1, new DateTime(2024, 10, 11, 1, 51, 32, 112, DateTimeKind.Utc).AddTicks(3792), "Whatevs", false, "User", null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Auth0Id", "CreatedById", "CreatedOn", "DepartmentId", "Email", "FirstName", "IsActive", "LastName", "PhoneNumber", "ReportsToId", "UpdatedById", "UpdatedOn", "UserRoleId" },
                values: new object[] { 1, "auth0|system-admin-id", 1, new DateTime(2024, 10, 11, 1, 51, 32, 112, DateTimeKind.Utc).AddTicks(3878), 1, "admin@example.com", "System", true, "Admin", "123-456-9999", null, null, null, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Users_CreatedById",
                table: "Users",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UpdatedById",
                table: "Users",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_TicketUser_CreatedById",
                table: "TicketUser",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_TicketUser_UpdatedById",
                table: "TicketUser",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_CreatedById",
                table: "Ticket",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_UpdatedById",
                table: "Ticket",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_CreatedById",
                table: "Roles",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_UpdatedById",
                table: "Roles",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_CreatedById",
                table: "Departments",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_UpdatedById",
                table: "Departments",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CreatedById",
                table: "Comments",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UpdatedById",
                table: "Comments",
                column: "UpdatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_CreatedById",
                table: "Comments",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_UpdatedById",
                table: "Comments",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Users_CreatedById",
                table: "Departments",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Users_UpdatedById",
                table: "Departments",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Users_CreatedById",
                table: "Roles",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Users_UpdatedById",
                table: "Roles",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Users_CreatedById",
                table: "Ticket",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Users_UpdatedById",
                table: "Ticket",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketUser_Users_CreatedById",
                table: "TicketUser",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketUser_Users_UpdatedById",
                table: "TicketUser",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_CreatedById",
                table: "Users",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_UpdatedById",
                table: "Users",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
