using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookOrder.Migrations
{
    /// <inheritdoc />
    public partial class book2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "sound",
                table: "books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sound",
                table: "books");
        }
    }
}
