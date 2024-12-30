using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assesment.Migrations
{
    /// <inheritdoc />
    public partial class Migra2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tasks_projects_ProjectID",
                table: "tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_tasks_teamMembers_TeamMemberID",
                table: "tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_teamMembers",
                table: "teamMembers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tasks",
                table: "tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_projects",
                table: "projects");

            migrationBuilder.RenameTable(
                name: "teamMembers",
                newName: "TeamMembers");

            migrationBuilder.RenameTable(
                name: "tasks",
                newName: "Tasks");

            migrationBuilder.RenameTable(
                name: "projects",
                newName: "Projects");

            migrationBuilder.RenameIndex(
                name: "IX_tasks_TeamMemberID",
                table: "Tasks",
                newName: "IX_Tasks_TeamMemberID");

            migrationBuilder.RenameIndex(
                name: "IX_tasks_ProjectID",
                table: "Tasks",
                newName: "IX_Tasks_ProjectID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamMembers",
                table: "TeamMembers",
                column: "TeamMemberID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "TasksID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projects",
                table: "Projects",
                column: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Projects_ProjectID",
                table: "Tasks",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TeamMembers_TeamMemberID",
                table: "Tasks",
                column: "TeamMemberID",
                principalTable: "TeamMembers",
                principalColumn: "TeamMemberID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Projects_ProjectID",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TeamMembers_TeamMemberID",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamMembers",
                table: "TeamMembers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projects",
                table: "Projects");

            migrationBuilder.RenameTable(
                name: "TeamMembers",
                newName: "teamMembers");

            migrationBuilder.RenameTable(
                name: "Tasks",
                newName: "tasks");

            migrationBuilder.RenameTable(
                name: "Projects",
                newName: "projects");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_TeamMemberID",
                table: "tasks",
                newName: "IX_tasks_TeamMemberID");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_ProjectID",
                table: "tasks",
                newName: "IX_tasks_ProjectID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_teamMembers",
                table: "teamMembers",
                column: "TeamMemberID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tasks",
                table: "tasks",
                column: "TasksID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_projects",
                table: "projects",
                column: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_tasks_projects_ProjectID",
                table: "tasks",
                column: "ProjectID",
                principalTable: "projects",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tasks_teamMembers_TeamMemberID",
                table: "tasks",
                column: "TeamMemberID",
                principalTable: "teamMembers",
                principalColumn: "TeamMemberID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
