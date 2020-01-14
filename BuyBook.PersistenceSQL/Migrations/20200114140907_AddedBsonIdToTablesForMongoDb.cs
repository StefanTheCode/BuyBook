using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BuyBook.PersistenceSQL.Migrations
{
    public partial class AddedBsonIdToTablesForMongoDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MongoId",
                table: "User");

            migrationBuilder.AddColumn<Guid>(
                name: "BsonId",
                table: "User",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "BsonId",
                table: "Rating",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "BsonId",
                table: "Book",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BsonId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "BsonId",
                table: "Rating");

            migrationBuilder.DropColumn(
                name: "BsonId",
                table: "Book");

            migrationBuilder.AddColumn<Guid>(
                name: "MongoId",
                table: "User",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
