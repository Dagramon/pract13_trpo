using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pract12_trpo.Migrations
{
    /// <inheritdoc />
    public partial class AddUserRelationManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InterestGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsersInterestGroups",
                columns: table => new
                {
                    InterestGroupId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    JoinedAt = table.Column<DateOnly>(type: "date", nullable: false),
                    IsModerator = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersInterestGroups", x => new { x.UserId, x.InterestGroupId });
                    table.ForeignKey(
                        name: "FK_UsersInterestGroups_InterestGroup_InterestGroupId",
                        column: x => x.InterestGroupId,
                        principalTable: "InterestGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersInterestGroups_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersInterestGroups_InterestGroupId",
                table: "UsersInterestGroups",
                column: "InterestGroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersInterestGroups");

            migrationBuilder.DropTable(
                name: "InterestGroup");
        }
    }
}
