using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UescColcicAPI.Services.Migrations
{
    /// <inheritdoc />
    public partial class Entrega3Migration : Migration
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
                name: "Skill",
                columns: table => new
                {
                    IdSkill = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    IdProject = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.IdSkill);
                    table.ForeignKey(
                        name: "FK_Skill_Project_IdProject",
                        column: x => x.IdProject,
                        principalTable: "Project",
                        principalColumn: "IdProject",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Skill_IdProject",
                table: "Skill",
                column: "IdProject");
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
        }
    }
}
