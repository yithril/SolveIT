using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolveIT_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class departmenttickets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Ticket",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_DepartmentId",
                table: "Ticket",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Departments_DepartmentId",
                table: "Ticket",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Departments_DepartmentId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_DepartmentId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Ticket");
        }
    }
}
