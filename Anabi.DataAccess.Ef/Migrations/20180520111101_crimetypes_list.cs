using Microsoft.EntityFrameworkCore.Migrations;

namespace Anabi.DataAccess.Ef.Migrations
{
    public partial class crimetypes_list : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert CrimeTypes(crimename, usercodeadd, addeddate) values('Furt calificat', 'admin', getdate())");
            migrationBuilder.Sql("insert CrimeTypes(crimename, usercodeadd, addeddate) values('Spalare de bani', 'admin', getdate())");
            migrationBuilder.Sql("insert CrimeTypes(crimename, usercodeadd, addeddate) values('Coruptie', 'admin', getdate())");
            migrationBuilder.Sql("insert CrimeTypes(crimename, usercodeadd, addeddate) values('Altele', 'admin', getdate())");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
