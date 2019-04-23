using Microsoft.EntityFrameworkCore.Migrations;

namespace Anabi.DataAccess.Ef.Migrations
{
    public partial class RemoveAddressIdAndCatregoryIdFromInstitution : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Institutions_Addresses_AddressDbId",
                table: "Institutions");

            migrationBuilder.DropForeignKey(
                name: "FK_Institutions_Categories",
                table: "Institutions");

            migrationBuilder.DropIndex(
                name: "IX_Institutions_AddressDbId",
                table: "Institutions");

            migrationBuilder.DropIndex(
                name: "IX_Institutions_CategoryId",
                table: "Institutions");

            migrationBuilder.DropColumn(
                name: "AddressDbId",
                table: "Institutions");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Institutions");

            migrationBuilder.AddColumn<int>(
                name: "BusinessId",
                table: "Institutions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusinessId",
                table: "Institutions");

            migrationBuilder.AddColumn<int>(
                name: "AddressDbId",
                table: "Institutions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Institutions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Institutions_AddressDbId",
                table: "Institutions",
                column: "AddressDbId");

            migrationBuilder.CreateIndex(
                name: "IX_Institutions_CategoryId",
                table: "Institutions",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Institutions_Addresses_AddressDbId",
                table: "Institutions",
                column: "AddressDbId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Institutions_Categories",
                table: "Institutions",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
