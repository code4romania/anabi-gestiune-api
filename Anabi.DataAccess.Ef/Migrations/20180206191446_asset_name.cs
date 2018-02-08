using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Anabi.DataAccess.Ef.Migrations
{
    public partial class asset_name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "Assets",
                type: "nvarchar(100)",
                nullable: false, 
                defaultValue: "");

            migrationBuilder.Sql("Update Assets set [Name] = 'Bun ' + convert(varchar, Id)");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                schema: "dbo",
                table: "Assets");
        }
    }
}
