using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UescColcicAPI.Services.Migrations
{
    /// <inheritdoc />
    public partial class addUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    IdProject = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProjectTitle = table.Column<string>(type: "TEXT", nullable: true),
                    ProjectDescription = table.Column<string>(type: "TEXT", nullable: true),
                    ProjectType = table.Column<string>(type: "TEXT", nullable: true),
                    ProjectStartDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ProjectEndDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.IdProject);
                });

            migrationBuilder.CreateTable(
                name: "RequestLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientIp = table.Column<string>(type: "TEXT", nullable: true),
                    HasJwt = table.Column<bool>(type: "INTEGER", nullable: false),
                    RequestDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    RequestMethod = table.Column<string>(type: "TEXT", nullable: true),
                    RequestUrl = table.Column<string>(type: "TEXT", nullable: true),
                    ProcessingTime = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    Rules = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    IdStudent = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Registration = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Course = table.Column<string>(type: "TEXT", nullable: true),
                    Bio = table.Column<string>(type: "TEXT", nullable: true),
                    IdUser = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.IdStudent);
                    table.ForeignKey(
                        name: "FK_Student_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    IdSkill = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    IdProject = table.Column<int>(type: "INTEGER", nullable: true),
                    IdStudent = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.IdSkill);
                    table.ForeignKey(
                        name: "FK_Skill_Project_IdProject",
                        column: x => x.IdProject,
                        principalTable: "Project",
                        principalColumn: "IdProject");
                    table.ForeignKey(
                        name: "FK_Skill_Student_IdStudent",
                        column: x => x.IdStudent,
                        principalTable: "Student",
                        principalColumn: "IdStudent");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Skill_IdProject",
                table: "Skill",
                column: "IdProject");

            migrationBuilder.CreateIndex(
                name: "IX_Skill_IdStudent",
                table: "Skill",
                column: "IdStudent");

            migrationBuilder.CreateIndex(
                name: "IX_Student_IdUser",
                table: "Student",
                column: "IdUser",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_Registration",
                table: "Student",
                column: "Registration",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestLogs");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
