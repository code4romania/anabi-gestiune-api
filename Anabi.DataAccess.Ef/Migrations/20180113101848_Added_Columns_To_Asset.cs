using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Anabi.DataAccess.Ef.Migrations
{
    public partial class Added_Columns_To_Asset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MeasureUnit",
                schema: "dbo",
                table: "Assets",
                type: "nvarchar(10)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NrOfObjects",
                schema: "dbo",
                table: "Assets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                schema: "dbo",
                table: "Assets",
                type: "nvarchar(2000)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MeasureUnit",
                schema: "dbo",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "NrOfObjects",
                schema: "dbo",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "Remarks",
                schema: "dbo",
                table: "Assets");
        }
    }
}
