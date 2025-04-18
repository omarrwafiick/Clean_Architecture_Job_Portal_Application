using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InfrastructureLayer.Migrations
{
    /// <inheritdoc />
    public partial class FinishedSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "JobPosts");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "JobApplications");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "AppUsers");

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "JobPosts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "JobTypeId",
                table: "JobPosts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationStatusId",
                table: "JobApplications",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "AppUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RoleId",
                table: "AppUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ApplicationStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ApplicationStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("10234718-cb49-4e33-90d3-55166b318850"), "Rejected" },
                    { new Guid("4424f875-b8fb-4eab-9902-39afac189a7a"), "Shortlisted" },
                    { new Guid("a35e9533-8cf9-4f12-af3e-89e8c1e56990"), "Pending" },
                    { new Guid("c350b43b-f6c4-4fe3-bd13-f5b362daac18"), "Reviewed" },
                    { new Guid("eca21248-960e-42a3-875d-ee8dc90f8397"), "Hired" }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Description", "Name", "Website" },
                values: new object[,]
                {
                    { new Guid("c1111111-aaaa-4bbb-cccc-111111111111"), "An innovative tech company building AI tools.", "TechNova Inc.", "https://technova.com" },
                    { new Guid("c2222222-aaaa-4bbb-cccc-222222222222"), "A healthcare organization focused on digital transformation.", "HealthCare Plus", "https://healthcareplus.org" },
                    { new Guid("c3333333-aaaa-4bbb-cccc-333333333333"), "Leading fintech platform provider.", "FinPro Solutions", "https://finprosolutions.com" }
                });

            migrationBuilder.InsertData(
                table: "JobTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0406323d-7e3f-40a4-ab25-e3477690d945"), "Freelance" },
                    { new Guid("3cc26e7b-e871-4b2b-bf0a-b3de7b9cc95e"), "PartTime" },
                    { new Guid("74fb7c4a-8b8e-405e-88dc-9c6fade5e261"), "Internship" },
                    { new Guid("9ea59c79-fc01-4308-a9ca-f46b7af7b34b"), "Contract" },
                    { new Guid("b4242be9-6359-4a4d-85ac-2db711793a12"), "FullTime" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("582b805e-c25d-43a3-8985-a8d67de41ca2"), "Employer" },
                    { new Guid("bd2d73f2-08a7-4481-b1be-eec35c7021fc"), "Admin" },
                    { new Guid("ffffae69-fb29-4f2e-b7c5-a597712a4912"), "Candidate" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobPosts_CompanyId",
                table: "JobPosts",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPosts_JobTypeId",
                table: "JobPosts",
                column: "JobTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_ApplicationStatusId",
                table: "JobApplications",
                column: "ApplicationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_CompanyId",
                table: "AppUsers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_RoleId",
                table: "AppUsers",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_Companies_CompanyId",
                table: "AppUsers",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_Roles_RoleId",
                table: "AppUsers",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_ApplicationStatus_ApplicationStatusId",
                table: "JobApplications",
                column: "ApplicationStatusId",
                principalTable: "ApplicationStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobPosts_Companies_CompanyId",
                table: "JobPosts",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobPosts_JobTypes_JobTypeId",
                table: "JobPosts",
                column: "JobTypeId",
                principalTable: "JobTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_Companies_CompanyId",
                table: "AppUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_Roles_RoleId",
                table: "AppUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_ApplicationStatus_ApplicationStatusId",
                table: "JobApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_JobPosts_Companies_CompanyId",
                table: "JobPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_JobPosts_JobTypes_JobTypeId",
                table: "JobPosts");

            migrationBuilder.DropTable(
                name: "ApplicationStatus");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "JobTypes");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_JobPosts_CompanyId",
                table: "JobPosts");

            migrationBuilder.DropIndex(
                name: "IX_JobPosts_JobTypeId",
                table: "JobPosts");

            migrationBuilder.DropIndex(
                name: "IX_JobApplications_ApplicationStatusId",
                table: "JobApplications");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_CompanyId",
                table: "AppUsers");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_RoleId",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "JobPosts");

            migrationBuilder.DropColumn(
                name: "JobTypeId",
                table: "JobPosts");

            migrationBuilder.DropColumn(
                name: "ApplicationStatusId",
                table: "JobApplications");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "AppUsers");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "JobPosts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "JobApplications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "AppUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
