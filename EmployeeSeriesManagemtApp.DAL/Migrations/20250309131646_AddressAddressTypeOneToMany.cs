using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeSeriesManagemtApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddressAddressTypeOneToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressTypeId",
                table: "Addresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_AddressTypeId",
                table: "Addresses",
                column: "AddressTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_AddressTypes_AddressTypeId",
                table: "Addresses",
                column: "AddressTypeId",
                principalTable: "AddressTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_AddressTypes_AddressTypeId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_AddressTypeId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "AddressTypeId",
                table: "Addresses");
        }
    }
}
