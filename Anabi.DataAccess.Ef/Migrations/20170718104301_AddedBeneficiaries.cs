using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Anabi.DataAccess.Ef.Migrations
{
    public partial class AddedBeneficiaries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RecoveryBeneficiaries",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecoveryBeneficiaries", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecoveryBeneficiaries_Name",
                schema: "dbo",
                table: "RecoveryBeneficiaries",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecoveryBeneficiaries",
                schema: "dbo");
        }
    }
}
