using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookPublisher.Migrations
{
    /// <inheritdoc />
    public partial class IdList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdList",
                table: "books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BookWithAuthorAndPublisherDTO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isRead = table.Column<bool>(type: "bit", nullable: false),
                    DateRead = table.Column<DateOnly>(type: "date", nullable: true),
                    Rate = table.Column<int>(type: "int", nullable: true),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAdd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PublisherId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookWithAuthorAndPublisherDTO", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "Id",
                keyValue: 1,
                column: "IdList",
                value: 0);

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "Id",
                keyValue: 2,
                column: "IdList",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookWithAuthorAndPublisherDTO");

            migrationBuilder.DropColumn(
                name: "IdList",
                table: "books");
        }
    }
}
