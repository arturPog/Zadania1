using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zadania.Migrations
{
    /// <inheritdoc />
    public partial class mihration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "Tasks",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duration",
                table: "Tasks",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Tasks");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "Tasks",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
