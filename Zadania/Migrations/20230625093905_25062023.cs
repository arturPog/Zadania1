using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zadania.Migrations
{
    /// <inheritdoc />
    public partial class _25062023 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovieTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    TextOriginalUrl = table.Column<string>(type: "TEXT", nullable: false),
                    TextUpdate1Url = table.Column<string>(type: "TEXT", nullable: false),
                    TextUpdate2Url = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieTexts", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieTexts");
        }
    }
}
