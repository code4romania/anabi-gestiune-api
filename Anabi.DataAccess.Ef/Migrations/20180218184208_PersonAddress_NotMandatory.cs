using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Anabi.DataAccess.Ef.Migrations
{
    public partial class PersonAddress_NotMandatory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE Persons alter column AddressId int null");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
