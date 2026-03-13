using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pract12_trpo.Migrations
{
    /// <inheritdoc />
    public partial class InterestGroups : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinedAt",
                table: "UsersInterestGroups",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "JoinedAt",
                table: "UsersInterestGroups",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
