using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Artify.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNameToPublicName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0de0f84e-d6f2-44b3-a955-12b108b5975b");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "AspNetUsers",
                newName: "PublicName");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "71058a76-dc94-48f3-88d2-57771a9cf6f8", null, "Author", "AUTHOR" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71058a76-dc94-48f3-88d2-57771a9cf6f8");

            migrationBuilder.RenameColumn(
                name: "PublicName",
                table: "AspNetUsers",
                newName: "Name");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0de0f84e-d6f2-44b3-a955-12b108b5975b", null, "Author", "AUTHOR" });
        }
    }
}
