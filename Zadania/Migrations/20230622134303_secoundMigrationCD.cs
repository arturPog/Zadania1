using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zadania.Migrations
{
    /// <inheritdoc />
    public partial class secoundMigrationCD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roots",
                columns: table => new
                {
                    RootId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ResultId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roots", x => x.RootId);
                    table.ForeignKey(
                        name: "FK_Roots_Results_ResultId",
                        column: x => x.ResultId,
                        principalTable: "Results",
                        principalColumn: "ResultId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Roots_ResultId",
                table: "Roots",
                column: "ResultId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Roots");
        }
    }
}
