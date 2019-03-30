using Microsoft.EntityFrameworkCore.Migrations;

namespace Anabi.DataAccess.Ef.Migrations
{
    public partial class RemoveInstitutionRedundantFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Institutions_Addresses_AddressId",
                table: "Institutions");

            migrationBuilder.DropForeignKey(
                name: "FK_Institutions_Categories_CategoryId",
                table: "Institutions");

            migrationBuilder.DropIndex(
                name: "IX_Institutions_CategoryId",
                table: "Institutions");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "Institutions",
                newName: "CategoryDbId");

            migrationBuilder.RenameIndex(
                name: "IX_Institutions_AddressId",
                table: "Institutions",
                newName: "IX_Institutions_CategoryDbId");

            migrationBuilder.AddColumn<int>(
                name: "AddressDbId",
                table: "Institutions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Institutions_AddressDbId",
                table: "Institutions",
                column: "AddressDbId");

            migrationBuilder.AddForeignKey(
                name: "FK_Institutions_Addresses_AddressDbId",
                table: "Institutions",
                column: "AddressDbId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Institutions_Categories_CategoryDbId",
                table: "Institutions",
                column: "CategoryDbId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Institutions_Addresses_AddressDbId",
                table: "Institutions");

            migrationBuilder.DropForeignKey(
                name: "FK_Institutions_Categories_CategoryDbId",
                table: "Institutions");

            migrationBuilder.DropIndex(
                name: "IX_Institutions_AddressDbId",
                table: "Institutions");

            migrationBuilder.DropColumn(
                name: "AddressDbId",
                table: "Institutions");

            migrationBuilder.RenameColumn(
                name: "CategoryDbId",
                table: "Institutions",
                newName: "AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Institutions_CategoryDbId",
                table: "Institutions",
                newName: "IX_Institutions_AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Institutions_CategoryId",
                table: "Institutions",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Institutions_Addresses_AddressId",
                table: "Institutions",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Institutions_Categories_CategoryId",
                table: "Institutions",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
