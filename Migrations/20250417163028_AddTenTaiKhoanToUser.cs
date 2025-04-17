using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quan_Ly_TTDT.Migrations
{
    /// <inheritdoc />
    public partial class AddTenTaiKhoanToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TenTaiKhoan",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenTaiKhoan",
                table: "Users");
        }
    }
}
