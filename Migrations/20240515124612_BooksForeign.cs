using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookPublisher.Migrations
{
    /// <inheritdoc />
    public partial class BooksForeign : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_publishers_PublishersId",
                table: "books");

            migrationBuilder.DropIndex(
                name: "IX_books_PublishersId",
                table: "books");

            migrationBuilder.DropColumn(
                name: "PublishersId",
                table: "books");

            migrationBuilder.CreateIndex(
                name: "IX_books_PublisherId",
                table: "books",
                column: "PublisherId");

            migrationBuilder.AddForeignKey(
                name: "FK_books_publishers_PublisherId",
                table: "books",
                column: "PublisherId",
                principalTable: "publishers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_publishers_PublisherId",
                table: "books");

            migrationBuilder.DropIndex(
                name: "IX_books_PublisherId",
                table: "books");

            migrationBuilder.AddColumn<int>(
                name: "PublishersId",
                table: "books",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishersId",
                value: null);

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishersId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_books_PublishersId",
                table: "books",
                column: "PublishersId");

            migrationBuilder.AddForeignKey(
                name: "FK_books_publishers_PublishersId",
                table: "books",
                column: "PublishersId",
                principalTable: "publishers",
                principalColumn: "Id");
        }
    }
}
