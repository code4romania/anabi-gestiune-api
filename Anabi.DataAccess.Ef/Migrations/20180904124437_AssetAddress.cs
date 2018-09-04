using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Anabi.DataAccess.Ef.Migrations
{
    public partial class AssetAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AddedDate",
                schema: "dbo",
                table: "Addresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "dbo",
                table: "Addresses",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastChangeDate",
                schema: "dbo",
                table: "Addresses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserCodeAdd",
                schema: "dbo",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserCodeLastChange",
                schema: "dbo",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedDate",
                schema: "dbo",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "dbo",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "LastChangeDate",
                schema: "dbo",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "UserCodeAdd",
                schema: "dbo",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "UserCodeLastChange",
                schema: "dbo",
                table: "Addresses");
        }
    }
}
