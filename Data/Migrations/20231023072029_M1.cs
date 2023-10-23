using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Newsletter.Data.Migrations
{
    /// <inheritdoc />
    public partial class M1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Newsletters",
                columns: table => new
                {
                    NewsletterId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NewsTitle = table.Column<string>(type: "TEXT", nullable: false),
                    SequentialNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Newsletters", x => x.NewsletterId);
                });

            migrationBuilder.CreateTable(
                name: "UserData",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserData", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    ArticleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Content = table.Column<string>(type: "TEXT", nullable: false),
                    NewsletterId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.ArticleId);
                    table.ForeignKey(
                        name: "FK_Article_Newsletters_NewsletterId",
                        column: x => x.NewsletterId,
                        principalTable: "Newsletters",
                        principalColumn: "NewsletterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Newsletters",
                columns: new[] { "NewsletterId", "Date", "IsActive", "NewsTitle", "SequentialNumber" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 23, 0, 20, 29, 838, DateTimeKind.Local).AddTicks(4866), true, "First Newsletter", 1 },
                    { 2, new DateTime(2023, 10, 23, 0, 20, 29, 838, DateTimeKind.Local).AddTicks(4928), true, "Second Newsletter", 2 },
                    { 3, new DateTime(2023, 10, 23, 0, 20, 29, 838, DateTimeKind.Local).AddTicks(4933), false, "Third Newsletter", 3 }
                });

            migrationBuilder.InsertData(
                table: "UserData",
                columns: new[] { "UserId", "Email", "Password" },
                values: new object[] { 1, "aa@aa.aa", "P@ssw0rd" });

            migrationBuilder.InsertData(
                table: "Article",
                columns: new[] { "ArticleId", "Content", "NewsletterId", "Title" },
                values: new object[,]
                {
                    { 1, "This is the first article", 1, "First Article" },
                    { 2, "This is the second article", 1, "Second Article" },
                    { 3, "This is the third article", 2, "Third Article" },
                    { 4, "This is the fourth article", 2, "Fourth Article" },
                    { 5, "This is the fifth article", 3, "Fifth Article" },
                    { 6, "This is the sixth article", 3, "Sixth Article" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Article_NewsletterId",
                table: "Article",
                column: "NewsletterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Article");

            migrationBuilder.DropTable(
                name: "UserData");

            migrationBuilder.DropTable(
                name: "Newsletters");
        }
    }
}
