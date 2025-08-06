using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSupportGroupMember : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SupportGroupMembers",
                columns: table => new
                {
                    MemberGroupID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    JoinedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    RoleInGroup = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserID = table.Column<int>(type: "int", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateUserID = table.Column<int>(type: "int", nullable: true),
                    ModCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportGroupMembers", x => x.MemberGroupID);
                    table.ForeignKey(
                        name: "FK_SupportGroupMembers_SupportGroups_GroupID",
                        column: x => x.GroupID,
                        principalTable: "SupportGroups",
                        principalColumn: "GroupID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SupportGroupMembers_GroupID",
                table: "SupportGroupMembers",
                column: "GroupID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SupportGroupMembers");
        }
    }
}
