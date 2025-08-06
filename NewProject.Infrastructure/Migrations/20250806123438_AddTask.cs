using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TaskID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantID = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TaskTypeID = table.Column<int>(type: "int", nullable: false),
                    TaskStageID = table.Column<int>(type: "int", nullable: false),
                    TaskStatusID = table.Column<int>(type: "int", nullable: false),
                    TaskPriorityID = table.Column<int>(type: "int", nullable: false),
                    ModuleID = table.Column<int>(type: "int", nullable: true),
                    ModuleName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ModuleEntityID = table.Column<int>(type: "int", nullable: true),
                    GroupID = table.Column<int>(type: "int", nullable: true),
                    ActualStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserID = table.Column<int>(type: "int", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateUserID = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ModCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TaskID);
                    table.ForeignKey(
                        name: "FK_Tasks_SupportGroups_GroupID",
                        column: x => x.GroupID,
                        principalTable: "SupportGroups",
                        principalColumn: "GroupID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_GroupID",
                table: "Tasks",
                column: "GroupID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}
