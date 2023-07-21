using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Artify.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddStoragePath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StoragePath",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageFileName",
                table: "Artworks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StoragePath",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "ImageFileName",
                table: "Artworks");
        }
    }
}
