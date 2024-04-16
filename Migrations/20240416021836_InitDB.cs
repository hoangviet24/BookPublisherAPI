using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookPublisher.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "author",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdList = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_author", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "publishers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRead = table.Column<bool>(type: "bit", nullable: true),
                    DateRead = table.Column<DateOnly>(type: "date", nullable: true),
                    Rate = table.Column<int>(type: "int", nullable: true),
                    Genre = table.Column<int>(type: "int", nullable: true),
                    CoverUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAdd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PublisherId = table.Column<int>(type: "int", nullable: true),
                    PublishersId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_books_publishers_PublishersId",
                        column: x => x.PublishersId,
                        principalTable: "publishers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "book_authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idbook = table.Column<int>(type: "int", nullable: false),
                    idauthor = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: true),
                    BookId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_book_authors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_book_authors_author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "author",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_book_authors_books_BookId",
                        column: x => x.BookId,
                        principalTable: "books",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "author",
                columns: new[] { "Id", "IdList", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Võ Hoàng Việt" },
                    { 2, 2, "Nguyễn Phạm Phương Linh" }
                });

            migrationBuilder.InsertData(
                table: "book_authors",
                columns: new[] { "Id", "AuthorId", "BookId", "idauthor", "idbook" },
                values: new object[,]
                {
                    { 1, null, null, 1, 1 },
                    { 2, null, null, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "books",
                columns: new[] { "Id", "CoverUrl", "DateAdd", "DateRead", "Description", "Genre", "IsRead", "PublisherId", "PublishersId", "Rate", "Title" },
                values: new object[,]
                {
                    { 1, "Hello", new DateTime(2004, 1, 28, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(2024, 4, 15), "Chưa biết", 17, false, 1, null, 4, "Sách hay" },
                    { 2, "Hello", new DateTime(2004, 1, 28, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(2024, 4, 15), "Chưa biết", 17, false, 1, null, 3, "Sách hay" }
                });

            migrationBuilder.InsertData(
                table: "publishers",
                columns: new[] { "Id", "BookId", "Name" },
                values: new object[] { 1, 1, "NoName" });

            migrationBuilder.CreateIndex(
                name: "IX_book_authors_AuthorId",
                table: "book_authors",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_book_authors_BookId",
                table: "book_authors",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_books_PublishersId",
                table: "books",
                column: "PublishersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "book_authors");

            migrationBuilder.DropTable(
                name: "author");

            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropTable(
                name: "publishers");
        }
    }
}
