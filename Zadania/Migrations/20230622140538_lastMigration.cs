using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zadania.Migrations
{
    /// <inheritdoc />
    public partial class lastMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountNumbers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountNumbers",
                columns: table => new
                {
                    AccountNumbersId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Numbers = table.Column<string>(type: "TEXT", nullable: false),
                    SubjectId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountNumbers", x => x.AccountNumbersId);
                    table.ForeignKey(
                        name: "FK_AccountNumbers_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountNumbers_SubjectId",
                table: "AccountNumbers",
                column: "SubjectId");
        }
    }
}
