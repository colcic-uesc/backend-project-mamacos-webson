using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UescColcicAPI.Services.Migrations
{
    /// <inheritdoc />
    public partial class migration3_Student : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skill_Project_ProjectId",
                table: "Skill");

            migrationBuilder.DropForeignKey(
                name: "FK_Skill_Student_StudentIdStudent",
                table: "Skill");

            migrationBuilder.DropIndex(
                name: "IX_Skill_StudentIdStudent",
                table: "Skill");

            migrationBuilder.DropColumn(
                name: "StudentIdStudent",
                table: "Skill");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Skill",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Skill",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Skill_Project_ProjectId",
                table: "Skill",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skill_Project_ProjectId",
                table: "Skill");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Skill");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Skill",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "StudentIdStudent",
                table: "Skill",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Skill_StudentIdStudent",
                table: "Skill",
                column: "StudentIdStudent");

            migrationBuilder.AddForeignKey(
                name: "FK_Skill_Project_ProjectId",
                table: "Skill",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skill_Student_StudentIdStudent",
                table: "Skill",
                column: "StudentIdStudent",
                principalTable: "Student",
                principalColumn: "IdStudent");
        }
    }
}
