using Microsoft.EntityFrameworkCore.Migrations;

namespace BuyBook.PersistenceSQL.Migrations
{
    public partial class ChangedRatingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Book_BookId",
                table: "Rating");

            migrationBuilder.DropIndex(
                name: "IX_Rating_BookId",
                table: "Rating");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Rating");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Rating");

            migrationBuilder.AddColumn<string>(
                name: "BookRating",
                table: "Rating",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ISBN",
                table: "Rating",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookRating",
                table: "Rating");

            migrationBuilder.DropColumn(
                name: "ISBN",
                table: "Rating");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Rating",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Value",
                table: "Rating",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Rating_BookId",
                table: "Rating",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Book_BookId",
                table: "Rating",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
