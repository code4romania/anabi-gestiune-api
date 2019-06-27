using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Anabi.DataAccess.Ef.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserCodeAdd = table.Column<string>(maxLength: 20, nullable: false),
                    UserCodeLastChange = table.Column<string>(maxLength: 20, nullable: true),
                    AddedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    LastChangeDate = table.Column<DateTime>(nullable: true),
                    ParentId = table.Column<int>(nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 2000, nullable: true),
                    ForEntity = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Parent",
                        column: x => x.ParentId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Counties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserCodeAdd = table.Column<string>(maxLength: 20, nullable: false),
                    UserCodeLastChange = table.Column<string>(maxLength: 20, nullable: true),
                    AddedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    LastChangeDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Abreviation = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Counties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CrimeTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserCodeAdd = table.Column<string>(maxLength: 20, nullable: false),
                    UserCodeLastChange = table.Column<string>(maxLength: 20, nullable: true),
                    AddedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    LastChangeDate = table.Column<DateTime>(nullable: true),
                    CrimeName = table.Column<string>(maxLength: 400, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrimeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Decisions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserCodeAdd = table.Column<string>(maxLength: 20, nullable: false),
                    UserCodeLastChange = table.Column<string>(maxLength: 20, nullable: true),
                    AddedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    LastChangeDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Decisions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Identifiers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserCodeAdd = table.Column<string>(maxLength: 20, nullable: false),
                    UserCodeLastChange = table.Column<string>(maxLength: 20, nullable: true),
                    AddedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    LastChangeDate = table.Column<DateTime>(nullable: true),
                    IdentifierType = table.Column<string>(maxLength: 50, nullable: false),
                    IsForPerson = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identifiers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrecautionaryMeasures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserCodeAdd = table.Column<string>(maxLength: 20, nullable: false),
                    UserCodeLastChange = table.Column<string>(maxLength: 20, nullable: true),
                    AddedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    LastChangeDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Code = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrecautionaryMeasures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecoveryBeneficiaries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserCodeAdd = table.Column<string>(maxLength: 20, nullable: false),
                    UserCodeLastChange = table.Column<string>(maxLength: 20, nullable: true),
                    AddedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    LastChangeDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecoveryBeneficiaries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserCodeAdd = table.Column<string>(maxLength: 20, nullable: false),
                    UserCodeLastChange = table.Column<string>(maxLength: 20, nullable: true),
                    AddedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    LastChangeDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    StageCategory = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsFinal = table.Column<bool>(nullable: false),
                    ParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stages_Stages_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Stages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserCode = table.Column<string>(maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "varchar(8000)", nullable: false),
                    Salt = table.Column<string>(type: "varchar(8000)", nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Role = table.Column<string>(maxLength: 5000, nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserCodeAdd = table.Column<string>(maxLength: 20, nullable: false),
                    UserCodeLastChange = table.Column<string>(maxLength: 20, nullable: true),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    LastChangeDate = table.Column<DateTime>(nullable: true),
                    CountyId = table.Column<int>(nullable: false),
                    Street = table.Column<string>(maxLength: 100, nullable: false),
                    City = table.Column<string>(maxLength: 30, nullable: true),
                    Building = table.Column<string>(maxLength: 10, nullable: true),
                    Description = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Counties",
                        column: x => x.CountyId,
                        principalTable: "Counties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserCodeAdd = table.Column<string>(maxLength: 20, nullable: false),
                    UserCodeLastChange = table.Column<string>(maxLength: 20, nullable: true),
                    AddedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    LastChangeDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    AddressId = table.Column<int>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 2000, nullable: true),
                    DecisionId = table.Column<int>(nullable: true),
                    Identifier = table.Column<string>(maxLength: 100, nullable: true),
                    NecessaryVolume = table.Column<decimal>(type: "decimal(20, 2)", nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    NrOfObjects = table.Column<int>(nullable: true),
                    MeasureUnit = table.Column<string>(maxLength: 10, nullable: true),
                    Remarks = table.Column<string>(maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assets_Addresses",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assets_Categories",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assets_Decisions",
                        column: x => x.DecisionId,
                        principalTable: "Decisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Institutions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserCodeAdd = table.Column<string>(maxLength: 20, nullable: false),
                    UserCodeLastChange = table.Column<string>(maxLength: 20, nullable: true),
                    AddedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    LastChangeDate = table.Column<DateTime>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ContactData = table.Column<string>(type: "varchar(8000)", nullable: true),
                    AddressDbId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institutions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Institutions_Addresses_AddressDbId",
                        column: x => x.AddressDbId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Institutions_Categories",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserCodeAdd = table.Column<string>(maxLength: 20, nullable: false),
                    UserCodeLastChange = table.Column<string>(maxLength: 20, nullable: true),
                    AddedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    LastChangeDate = table.Column<DateTime>(nullable: true),
                    AddressId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Identification = table.Column<string>(maxLength: 20, nullable: false),
                    IdSerie = table.Column<string>(maxLength: 2, nullable: true),
                    IdNumber = table.Column<string>(maxLength: 6, nullable: true),
                    IsPerson = table.Column<bool>(nullable: false),
                    Birthdate = table.Column<DateTime>(nullable: true),
                    Nationality = table.Column<string>(maxLength: 20, nullable: true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    IdentifierId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_Addresses",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Persons_Identifiers",
                        column: x => x.IdentifierId,
                        principalTable: "Identifiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StorageSpaces",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserCodeAdd = table.Column<string>(maxLength: 20, nullable: false),
                    UserCodeLastChange = table.Column<string>(maxLength: 20, nullable: true),
                    AddedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    LastChangeDate = table.Column<DateTime>(nullable: true),
                    AddressId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    StorageSpacesType = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageSpaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StorageSpaces_Addresses",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssetDefendants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserCodeAdd = table.Column<string>(maxLength: 20, nullable: false),
                    UserCodeLastChange = table.Column<string>(maxLength: 20, nullable: true),
                    AddedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    LastChangeDate = table.Column<DateTime>(nullable: true),
                    AssetId = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetDefendants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assets_AssetDefendant",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Person_AssetDefendant",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HistoricalStages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserCodeAdd = table.Column<string>(maxLength: 20, nullable: false),
                    UserCodeLastChange = table.Column<string>(maxLength: 20, nullable: true),
                    AddedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    LastChangeDate = table.Column<DateTime>(nullable: true),
                    AssetId = table.Column<int>(nullable: false),
                    StageId = table.Column<int>(nullable: false),
                    DecizieId = table.Column<int>(nullable: true),
                    InstitutionId = table.Column<int>(nullable: true),
                    EstimatedAmount = table.Column<decimal>(type: "Decimal(20,2)", nullable: true),
                    EstimatedAmountCurrency = table.Column<string>(maxLength: 3, nullable: true),
                    AssetState = table.Column<string>(maxLength: 100, nullable: true),
                    OwnerId = table.Column<int>(type: "Int", nullable: true),
                    ActualValue = table.Column<decimal>(type: "Decimal(20, 2)", nullable: true),
                    ActualValueCurrency = table.Column<string>(maxLength: 3, nullable: true),
                    LegalBasis = table.Column<string>(maxLength: 200, nullable: true),
                    DecisionNumber = table.Column<string>(maxLength: 50, nullable: true),
                    DecisionDate = table.Column<DateTime>(type: "Date", nullable: false),
                    Source = table.Column<string>(maxLength: 500, nullable: true),
                    SentOnEmail = table.Column<bool>(nullable: true),
                    FileNumber = table.Column<string>(maxLength: 200, nullable: true),
                    FileNumberParquet = table.Column<string>(maxLength: 200, nullable: true),
                    ReceivingDate = table.Column<DateTime>(nullable: true),
                    DefinitiveDate = table.Column<DateTime>(nullable: true),
                    SendToAuthoritiesDate = table.Column<DateTime>(nullable: true),
                    IsDefinitive = table.Column<bool>(nullable: true),
                    CrimeTypeId = table.Column<int>(nullable: true),
                    PrecautionaryMeasureId = table.Column<int>(nullable: true),
                    RecoveryBeneficiaryId = table.Column<int>(nullable: true),
                    RecoveryState = table.Column<string>(nullable: true),
                    EvaluationCommitteeDesignationDate = table.Column<DateTime>(nullable: true),
                    EvaluationCommitteePresident = table.Column<string>(maxLength: 200, nullable: true),
                    EvaluationCommittee = table.Column<string>(nullable: true),
                    RecoveryCommitteeDesignationDate = table.Column<DateTime>(nullable: true),
                    RecoveryCommitteePresident = table.Column<string>(maxLength: 200, nullable: true),
                    RecoveryCommittee = table.Column<string>(nullable: true),
                    LastActivity = table.Column<DateTime>(nullable: true),
                    PersonResponsible = table.Column<string>(maxLength: 200, nullable: true),
                    RecoveryApplicationNumber = table.Column<string>(maxLength: 100, nullable: true),
                    RecoveryApplicationDate = table.Column<DateTime>(nullable: true),
                    RecoveryDocumentType = table.Column<int>(nullable: true),
                    RecoveryIssuingInstitution = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricalStages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricalStages_Assets",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoricalStages_CrimeTypes_CrimeTypeId",
                        column: x => x.CrimeTypeId,
                        principalTable: "CrimeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoricalStages_Decisions",
                        column: x => x.DecizieId,
                        principalTable: "Decisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoricalStages_Institutions",
                        column: x => x.InstitutionId,
                        principalTable: "Institutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoricalStages_PrecautionaryMeasures_PrecautionaryMeasureId",
                        column: x => x.PrecautionaryMeasureId,
                        principalTable: "PrecautionaryMeasures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoricalStages_RecoveryBeneficiaries_RecoveryBeneficiaryId",
                        column: x => x.RecoveryBeneficiaryId,
                        principalTable: "RecoveryBeneficiaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoricalStages_Stages",
                        column: x => x.StageId,
                        principalTable: "Stages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssetStorageSpaces",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserCodeAdd = table.Column<string>(maxLength: 20, nullable: false),
                    UserCodeLastChange = table.Column<string>(maxLength: 20, nullable: true),
                    AddedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    LastChangeDate = table.Column<DateTime>(nullable: true),
                    AssetId = table.Column<int>(nullable: false),
                    StorageSpaceId = table.Column<int>(nullable: false),
                    EntryDate = table.Column<DateTime>(nullable: false),
                    ExitDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetStorageSpaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetsStorageSpaces_Assets",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetsStorageSpaces_StorageSpaces",
                        column: x => x.StorageSpaceId,
                        principalTable: "StorageSpaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CountyId",
                table: "Addresses",
                column: "CountyId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetDefendants_AssetId",
                table: "AssetDefendants",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetDefendants_PersonId",
                table: "AssetDefendants",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_AddressId",
                table: "Assets",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_CategoryId",
                table: "Assets",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_DecisionId",
                table: "Assets",
                column: "DecisionId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetStorageSpaces_AssetId",
                table: "AssetStorageSpaces",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetStorageSpaces_StorageSpaceId",
                table: "AssetStorageSpaces",
                column: "StorageSpaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentId",
                table: "Categories",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "indx_code_forentity",
                table: "Categories",
                columns: new[] { "Code", "ForEntity" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Counties_Abreviation",
                table: "Counties",
                column: "Abreviation",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CrimeTypes_CrimeName",
                table: "CrimeTypes",
                column: "CrimeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "indx_uq_Decision",
                table: "Decisions",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HistoricalStages_AssetId",
                table: "HistoricalStages",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricalStages_CrimeTypeId",
                table: "HistoricalStages",
                column: "CrimeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricalStages_DecizieId",
                table: "HistoricalStages",
                column: "DecizieId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricalStages_InstitutionId",
                table: "HistoricalStages",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricalStages_OwnerId",
                table: "HistoricalStages",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricalStages_PrecautionaryMeasureId",
                table: "HistoricalStages",
                column: "PrecautionaryMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricalStages_RecoveryBeneficiaryId",
                table: "HistoricalStages",
                column: "RecoveryBeneficiaryId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricalStages_StageId",
                table: "HistoricalStages",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_Institutions_AddressDbId",
                table: "Institutions",
                column: "AddressDbId");

            migrationBuilder.CreateIndex(
                name: "IX_Institutions_CategoryId",
                table: "Institutions",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_AddressId",
                table: "Persons",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "indx_uq_Persons",
                table: "Persons",
                column: "Identification",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_IdentifierId",
                table: "Persons",
                column: "IdentifierId");

            migrationBuilder.CreateIndex(
                name: "uq_RecoveryBeneficiaryName",
                table: "RecoveryBeneficiaries",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "indx_uq_stagename",
                table: "Stages",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stages_ParentId",
                table: "Stages",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_StorageSpaces_AddressId",
                table: "StorageSpaces",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uq_StorageSpaceName",
                table: "StorageSpaces",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserCode",
                table: "Users",
                column: "UserCode",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssetDefendants");

            migrationBuilder.DropTable(
                name: "AssetStorageSpaces");

            migrationBuilder.DropTable(
                name: "HistoricalStages");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "StorageSpaces");

            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "CrimeTypes");

            migrationBuilder.DropTable(
                name: "Institutions");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "PrecautionaryMeasures");

            migrationBuilder.DropTable(
                name: "RecoveryBeneficiaries");

            migrationBuilder.DropTable(
                name: "Stages");

            migrationBuilder.DropTable(
                name: "Decisions");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Identifiers");

            migrationBuilder.DropTable(
                name: "Counties");
        }
    }
}
