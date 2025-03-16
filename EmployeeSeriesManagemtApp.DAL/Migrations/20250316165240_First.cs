using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeSeriesManagemtApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddressTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    ExternalIdf = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Number = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    BirthPlace = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProfileImage = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    ExitDate = table.Column<DateOnly>(type: "date", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrganizationalUnit = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.ExternalIdf);
                });

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExternalEmployeeIdf = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Number = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MailBoxNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Building = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Floor = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    AddressTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_AddressTypes_AddressTypeId",
                        column: x => x.AddressTypeId,
                        principalTable: "AddressTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeIdCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Validity = table.Column<DateOnly>(type: "date", nullable: false),
                    EmployeesExternalIdf = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeIdCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeIdCards_Employees_EmployeesExternalIdf",
                        column: x => x.EmployeesExternalIdf,
                        principalTable: "Employees",
                        principalColumn: "ExternalIdf");
                });

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

            migrationBuilder.CreateTable(
                name: "AddressEmployee",
                columns: table => new
                {
                    AddressesId = table.Column<int>(type: "int", nullable: false),
                    EmployeesExternalIdf = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressEmployee", x => new { x.AddressesId, x.EmployeesExternalIdf });
                    table.ForeignKey(
                        name: "FK_AddressEmployee_Addresses_AddressesId",
                        column: x => x.AddressesId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AddressEmployee_Employees_EmployeesExternalIdf",
                        column: x => x.EmployeesExternalIdf,
                        principalTable: "Employees",
                        principalColumn: "ExternalIdf",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddressEmployee_EmployeesExternalIdf",
                table: "AddressEmployee",
                column: "EmployeesExternalIdf");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_AddressTypeId",
                table: "Addresses",
                column: "AddressTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeIdCards_EmployeesExternalIdf",
                table: "EmployeeIdCards",
                column: "EmployeesExternalIdf");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSeries_SeriesCode",
                table: "EmployeeSeries",
                column: "SeriesCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressEmployee");

            migrationBuilder.DropTable(
                name: "EmployeeIdCards");

            migrationBuilder.DropTable(
                name: "EmployeeSeries");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Series");

            migrationBuilder.DropTable(
                name: "AddressTypes");
        }
    }
}
