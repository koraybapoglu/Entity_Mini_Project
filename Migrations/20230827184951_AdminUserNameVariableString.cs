using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity_Musteri_Siparis_Project.Migrations
{
    /// <inheritdoc />
    public partial class AdminUserNameVariableString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AdminUserName",
                table: "Admin",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AdminUserName",
                table: "Admin",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
