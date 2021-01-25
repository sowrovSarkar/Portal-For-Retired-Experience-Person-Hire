using Microsoft.EntityFrameworkCore.Migrations;

namespace PortalForRetiredExperienced.Migrations
{
    public partial class JobPortalInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "JobType",
                table: "JobListModels",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Applicant",
                columns: table => new
                {
                    Em_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployerUsername = table.Column<string>(nullable: false),
                    EmployerName = table.Column<string>(nullable: false),
                    EmployerContactNo = table.Column<string>(nullable: false),
                    EmployerEmail = table.Column<string>(nullable: false),
                    EmployerPassword = table.Column<string>(nullable: false),
                    ProfilePictureName = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicant", x => x.Em_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applicant");

            migrationBuilder.DropColumn(
                name: "JobType",
                table: "JobListModels");
        }
    }
}
