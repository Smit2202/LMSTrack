using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMSTrack.Migrations
{
    /// <inheritdoc />
    public partial class SecCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "bId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bId",
                table: "Books");
        }
    }
}
