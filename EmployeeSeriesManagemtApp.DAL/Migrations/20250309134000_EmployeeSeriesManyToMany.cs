using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeSeriesManagemtApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeSeriesManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeSeries",
                columns: table => new
                {
                    EmployeesExternalIdf = table.Column<int>(type: "int", nullable: false),
                    SeriesCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSeries", x => new { x.EmployeesExternalIdf, x.SeriesCode });
                    table.ForeignKey(
                        name: "FK_EmployeeSeries_Employees_EmployeesExternalIdf",
                        column: x => x.EmployeesExternalIdf,
                        principalTable: "Employees",
                        principalColumn: "ExternalIdf",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeSeries_Series_SeriesCode",
                        column: x => x.SeriesCode,
                        principalTable: "Series",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSeries_SeriesCode",
                table: "EmployeeSeries",
                column: "SeriesCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeSeries");
        }
    }
}
