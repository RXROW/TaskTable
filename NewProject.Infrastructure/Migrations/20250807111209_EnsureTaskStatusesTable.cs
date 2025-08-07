using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NewProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EnsureTaskStatusesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskStatuses",
                columns: table => new
                {
                    TaskStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantID = table.Column<int>(type: "int", nullable: true),
                    TaskStatusName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskStatuses", x => x.TaskStatusID);
                });

            migrationBuilder.InsertData(
                table: "TaskStatuses",
                columns: new[] { "TaskStatusID", "Language", "TaskStatusName", "TenantID" },
                values: new object[,]
                {
                    { 1, "EN", "Pending", null },
                    { 2, "EN", "In Progress", null },
                    { 3, "EN", "Review", null },
                    { 4, "EN", "Completed", null },
                    { 5, "EN", "Cancelled", null },
                    { 6, "EN", "On Hold", null },
                    { 7, "EN", "Rejected", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskStatuses");
        }
    }
}
