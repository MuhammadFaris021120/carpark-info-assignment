using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarparkInfo.Migrations
{
    /// <inheritdoc />
    public partial class AddIsFavoriteToCarpark : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFavorite",
                table: "Carparks",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFavorite",
                table: "Carparks");
        }
    }
}
