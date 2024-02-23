using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullAPI.Cinema.Migrations
{
    /// <inheritdoc />
    public partial class logical_delete_shows : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Shows",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Shows");
        }
    }
}
