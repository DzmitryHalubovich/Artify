using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Artify.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedRolesToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "38d6bf1a-0694-4547-a16b-84bce64aa934", null, "Author", "AUTHOR" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38d6bf1a-0694-4547-a16b-84bce64aa934");
        }
    }
}
