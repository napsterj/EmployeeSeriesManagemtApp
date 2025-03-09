using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeSeriesManagemtApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeEmployeeIdCardZeroToOneOptional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeesExternalIdf",
                table: "EmployeeIdCards",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeIdCards_EmployeesExternalIdf",
                table: "EmployeeIdCards",
                column: "EmployeesExternalIdf");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeIdCards_Employees_EmployeesExternalIdf",
                table: "EmployeeIdCards",
                column: "EmployeesExternalIdf",
                principalTable: "Employees",
                principalColumn: "ExternalIdf");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeIdCards_Employees_EmployeesExternalIdf",
                table: "EmployeeIdCards");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeIdCards_EmployeesExternalIdf",
                table: "EmployeeIdCards");

            migrationBuilder.DropColumn(
                name: "EmployeesExternalIdf",
                table: "EmployeeIdCards");
        }
    }
}
