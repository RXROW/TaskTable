using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NewProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedTaskTypeData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TaskTypes",
                columns: new[] { "TaskTypeID", "Description", "Language", "TaskTypeName", "TenantID" },
                values: new object[,]
                {
                    { 1, "Review a record or item", "EN", "Review", null },
                    { 2, "Approve a request or change", "EN", "Approval", null },
                    { 3, "Develop or review a mitigation plan", "EN", "Mitigation Plan", null },
                    { 4, "Conduct an assessment", "EN", "Assessment", null },
                    { 5, "Make updates to a module record", "EN", "Update", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TaskTypes",
                keyColumn: "TaskTypeID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TaskTypes",
                keyColumn: "TaskTypeID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TaskTypes",
                keyColumn: "TaskTypeID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TaskTypes",
                keyColumn: "TaskTypeID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TaskTypes",
                keyColumn: "TaskTypeID",
                keyValue: 5);
        }
    }
}
