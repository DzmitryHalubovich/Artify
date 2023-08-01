using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Artify.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTitle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageFileName",
                table: "Artworks");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Artworks",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Artworks",
                newName: "ImageUrl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Artworks",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Artworks",
                newName: "ImagePath");

            migrationBuilder.AddColumn<string>(
                name: "ImageFileName",
                table: "Artworks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
