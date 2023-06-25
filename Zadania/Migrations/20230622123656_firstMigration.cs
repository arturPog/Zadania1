using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zadania.Migrations
{
    /// <inheritdoc />
    public partial class firstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    SubjectId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    regon = table.Column<string>(type: "TEXT", nullable: false),
                    restorationDate = table.Column<string>(type: "TEXT", nullable: false),
                    workingAddress = table.Column<string>(type: "TEXT", nullable: false),
                    hasVirtualAccounts = table.Column<bool>(type: "INTEGER", nullable: false),
                    statusVat = table.Column<string>(type: "TEXT", nullable: false),
                    krs = table.Column<string>(type: "TEXT", nullable: false),
                    restorationBasis = table.Column<string>(type: "TEXT", nullable: false),
                    registrationDenialBasis = table.Column<string>(type: "TEXT", nullable: false),
                    nip = table.Column<string>(type: "TEXT", nullable: false),
                    removalDate = table.Column<string>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    registrationLegalDate = table.Column<string>(type: "TEXT", nullable: false),
                    removalBasis = table.Column<string>(type: "TEXT", nullable: false),
                    pesel = table.Column<string>(type: "TEXT", nullable: false),
                    residenceAddress = table.Column<string>(type: "TEXT", nullable: false),
                    registrationDenialDate = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.SubjectId);
                });

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

            migrationBuilder.CreateTable(
                name: "EntityPersonProkurents",
                columns: table => new
                {
                    EntityPersonProkurentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    companyName = table.Column<string>(type: "TEXT", nullable: false),
                    firstName = table.Column<string>(type: "TEXT", nullable: false),
                    lastName = table.Column<string>(type: "TEXT", nullable: false),
                    pesel = table.Column<string>(type: "TEXT", nullable: false),
                    nip = table.Column<string>(type: "TEXT", nullable: false),
                    SubjectId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityPersonProkurents", x => x.EntityPersonProkurentId);
                    table.ForeignKey(
                        name: "FK_EntityPersonProkurents_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId");
                });

            migrationBuilder.CreateTable(
                name: "EntityPersonWspolniks",
                columns: table => new
                {
                    EntityPersonWspolnikId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    companyName = table.Column<string>(type: "TEXT", nullable: false),
                    firstName = table.Column<string>(type: "TEXT", nullable: false),
                    lastName = table.Column<string>(type: "TEXT", nullable: false),
                    pesel = table.Column<string>(type: "TEXT", nullable: false),
                    nip = table.Column<string>(type: "TEXT", nullable: false),
                    SubjectId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityPersonWspolniks", x => x.EntityPersonWspolnikId);
                    table.ForeignKey(
                        name: "FK_EntityPersonWspolniks_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId");
                });

            migrationBuilder.CreateTable(
                name: "Representatives",
                columns: table => new
                {
                    RepresentativeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    firstName = table.Column<string>(type: "TEXT", nullable: false),
                    lastName = table.Column<string>(type: "TEXT", nullable: false),
                    nip = table.Column<string>(type: "TEXT", nullable: false),
                    companyName = table.Column<string>(type: "TEXT", nullable: false),
                    SubjectId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Representatives", x => x.RepresentativeId);
                    table.ForeignKey(
                        name: "FK_Representatives_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId");
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    ResultId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SubjectId = table.Column<int>(type: "INTEGER", nullable: false),
                    requestDateTime = table.Column<string>(type: "TEXT", nullable: false),
                    requestId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.ResultId);
                    table.ForeignKey(
                        name: "FK_Results_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountNumbers_SubjectId",
                table: "AccountNumbers",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityPersonProkurents_SubjectId",
                table: "EntityPersonProkurents",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityPersonWspolniks_SubjectId",
                table: "EntityPersonWspolniks",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Representatives_SubjectId",
                table: "Representatives",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_SubjectId",
                table: "Results",
                column: "SubjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountNumbers");

            migrationBuilder.DropTable(
                name: "EntityPersonProkurents");

            migrationBuilder.DropTable(
                name: "EntityPersonWspolniks");

            migrationBuilder.DropTable(
                name: "Representatives");

            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "Subjects");
        }
    }
}
