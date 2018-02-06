using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Anabi.DataAccess.Ef.Migrations
{
    public partial class historicalStages_nullable_columns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE HistoricalStages ALTER COLUMN DecisionDate DATE null");
            migrationBuilder.Sql("ALTER TABLE HistoricalStages ALTER COLUMN DecisionNumber nvarchar(50) null");
            migrationBuilder.Sql("ALTER TABLE HistoricalStages ALTER COLUMN DecizieId int null");
            migrationBuilder.Sql("ALTER TABLE HistoricalStages ALTER COLUMN EstimatedAmount decimal(20, 2) null");
            migrationBuilder.Sql("ALTER TABLE HistoricalStages ALTER COLUMN EstimatedAmountCurrency nvarchar(3) null");
            migrationBuilder.Sql("ALTER TABLE HistoricalStages ALTER COLUMN InstitutionId int null");
            migrationBuilder.Sql("ALTER TABLE HistoricalStages ALTER COLUMN LegalBasis nvarchar(200) null");
            migrationBuilder.Sql("ALTER TABLE HistoricalStages ALTER COLUMN ActualValueCurrency nvarchar(3) null");
            migrationBuilder.Sql("ALTER TABLE HistoricalStages ALTER COLUMN AssetState nvarchar(100) null");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
