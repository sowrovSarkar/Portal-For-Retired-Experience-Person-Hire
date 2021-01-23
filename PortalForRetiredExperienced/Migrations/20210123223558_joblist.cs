using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PortalForRetiredExperienced.Migrations
{
    public partial class joblist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyDetailsModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    WebAddress = table.Column<string>(nullable: true),
                    Discription = table.Column<string>(nullable: true),
                    FacebookLink = table.Column<string>(nullable: true),
                    LinkedInLink = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyDetailsModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobListModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobTitle = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    JobNature = table.Column<string>(nullable: true),
                    Salary = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    DateTime = table.Column<DateTime>(nullable: false),
                    CompanyDetailsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobListModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobListModels_CompanyDetailsModel_CompanyDetailsId",
                        column: x => x.CompanyDetailsId,
                        principalTable: "CompanyDetailsModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobListModels_CompanyDetailsId",
                table: "JobListModels",
                column: "CompanyDetailsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobListModels");

            migrationBuilder.DropTable(
                name: "CompanyDetailsModel");
        }
    }
}
