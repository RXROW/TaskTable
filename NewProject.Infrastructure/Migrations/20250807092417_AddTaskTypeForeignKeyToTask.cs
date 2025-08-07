using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTaskTypeForeignKeyToTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TaskTypeID",
                table: "Tasks",
                column: "TaskTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TaskTypes_TaskTypeID",
                table: "Tasks",
                column: "TaskTypeID",
                principalTable: "TaskTypes",
                principalColumn: "TaskTypeID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TaskTypes_TaskTypeID",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_TaskTypeID",
                table: "Tasks");
        }
    }
}
