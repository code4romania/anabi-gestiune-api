using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Anabi.DataAccess.Ef.Migrations
{
    public partial class storage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StorageSpaces_Category",
                schema: "dbo",
                table: "StorageSpaces");

            migrationBuilder.AddForeignKey(
                name: "FK_StorageSpaces_Categories",
                schema: "dbo",
                table: "StorageSpaces",
                column: "CategoryId",
                principalSchema: "dbo",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StorageSpaces_Categories",
                schema: "dbo",
                table: "StorageSpaces");

            migrationBuilder.AddForeignKey(
                name: "FK_StorageSpaces_Category",
                schema: "dbo",
                table: "StorageSpaces",
                column: "CategoryId",
                principalSchema: "dbo",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
