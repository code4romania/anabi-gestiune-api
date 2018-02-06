using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Anabi.DataAccess.Ef.Migrations
{
    public partial class asset_nullable_columns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE Assets ALTER COLUMN AddressId int null");
            migrationBuilder.Sql("ALTER TABLE Assets ALTER COLUMN DecisionId int null");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //not interested in making them not null again
        }
    }
}
