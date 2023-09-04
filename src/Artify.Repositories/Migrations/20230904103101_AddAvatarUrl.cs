using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Artify.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class AddAvatarUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4388901e-5147-4044-bbb1-c2387e215897"));

            migrationBuilder.AddColumn<string>(
                name: "AvatarUrl",
                table: "AuthorProfiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("3bf80679-7b2c-4206-8d69-68442615d50a"), null, "Author", "AUTHOR" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3bf80679-7b2c-4206-8d69-68442615d50a"));

            migrationBuilder.DropColumn(
                name: "AvatarUrl",
                table: "AuthorProfiles");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("4388901e-5147-4044-bbb1-c2387e215897"), null, "Author", "AUTHOR" });
        }
    }
}
