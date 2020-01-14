using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BuyBook.PersistenceSQL.Migrations
{
    public partial class AddedBsonIdToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MongoId",
                table: "User",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MongoId",
                table: "User");
        }
    }
}
