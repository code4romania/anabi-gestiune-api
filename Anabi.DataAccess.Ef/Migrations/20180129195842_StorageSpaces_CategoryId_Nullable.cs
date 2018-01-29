using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Anabi.DataAccess.Ef.Migrations
{
    public partial class StorageSpaces_CategoryId_Nullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StorageSpaces_CategoryId",
                schema: "dbo",
                table: "StorageSpaces");

            migrationBuilder.AlterColumn<string>(
                name: "MaintenanceMentions",
                schema: "dbo",
                table: "StorageSpaces",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Decimal(20, 2)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StorageSpaces_CategoryId",
                schema: "dbo",
                table: "StorageSpaces",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StorageSpaces_CategoryId",
                schema: "dbo",
                table: "StorageSpaces");

            migrationBuilder.AlterColumn<string>(
                name: "MaintenanceMentions",
                schema: "dbo",
                table: "StorageSpaces",
                type: "Decimal(20, 2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StorageSpaces_CategoryId",
                schema: "dbo",
                table: "StorageSpaces",
                column: "CategoryId",
                unique: true);
        }
    }
}
