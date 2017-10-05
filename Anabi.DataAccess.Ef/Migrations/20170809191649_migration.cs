using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Anabi.DataAccess.Ef.Migrations
{
    public partial class migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AsphaltedArea",
                schema: "dbo",
                table: "StorageSpaces",
                type: "Decimal(20, 2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "AvailableVolume",
                schema: "dbo",
                table: "StorageSpaces",
                type: "Decimal(20, 2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                schema: "dbo",
                table: "StorageSpaces",
                nullable: true,
                defaultValue: 1);

            migrationBuilder.AddColumn<string>(
                name: "ContactData",
                schema: "dbo",
                table: "StorageSpaces",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "dbo",
                table: "StorageSpaces",
                maxLength: 2000,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Length",
                schema: "dbo",
                table: "StorageSpaces",
                type: "Decimal(20, 2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaintenanceMentions",
                schema: "dbo",
                table: "StorageSpaces",
                type: "Decimal(20, 2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MonthlyMaintenanceCost",
                schema: "dbo",
                table: "StorageSpaces",
                type: "Decimal(20, 2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalVolume",
                schema: "dbo",
                table: "StorageSpaces",
                type: "Decimal(20, 2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "UndevelopedArea",
                schema: "dbo",
                table: "StorageSpaces",
                type: "Decimal(20, 2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Width",
                schema: "dbo",
                table: "StorageSpaces",
                type: "Decimal(20, 2)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StorageSpaces_CategoryId",
                schema: "dbo",
                table: "StorageSpaces",
                column: "CategoryId",
                unique: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StorageSpaces_Category",
                schema: "dbo",
                table: "StorageSpaces");

            migrationBuilder.DropIndex(
                name: "IX_StorageSpaces_CategoryId",
                schema: "dbo",
                table: "StorageSpaces");

            migrationBuilder.DropColumn(
                name: "AsphaltedArea",
                schema: "dbo",
                table: "StorageSpaces");

            migrationBuilder.DropColumn(
                name: "AvailableVolume",
                schema: "dbo",
                table: "StorageSpaces");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                schema: "dbo",
                table: "StorageSpaces");

            migrationBuilder.DropColumn(
                name: "ContactData",
                schema: "dbo",
                table: "StorageSpaces");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "dbo",
                table: "StorageSpaces");

            migrationBuilder.DropColumn(
                name: "Length",
                schema: "dbo",
                table: "StorageSpaces");

            migrationBuilder.DropColumn(
                name: "MaintenanceMentions",
                schema: "dbo",
                table: "StorageSpaces");

            migrationBuilder.DropColumn(
                name: "MonthlyMaintenanceCost",
                schema: "dbo",
                table: "StorageSpaces");

            migrationBuilder.DropColumn(
                name: "TotalVolume",
                schema: "dbo",
                table: "StorageSpaces");

            migrationBuilder.DropColumn(
                name: "UndevelopedArea",
                schema: "dbo",
                table: "StorageSpaces");

            migrationBuilder.DropColumn(
                name: "Width",
                schema: "dbo",
                table: "StorageSpaces");
        }
    }
}
