using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCoreCodeBooks.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreFieldsToBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "tblBooks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PublishedYear",
                table: "tblBooks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Publisher",
                table: "tblBooks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "tblBooks");

            migrationBuilder.DropColumn(
                name: "PublishedYear",
                table: "tblBooks");

            migrationBuilder.DropColumn(
                name: "Publisher",
                table: "tblBooks");
        }
    }
}
