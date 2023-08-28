using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity_Musteri_Siparis_Project.Migrations
{
    /// <inheritdoc />
    public partial class AddMusteriPasswordProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MusteriSifre",
                table: "Musteriler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MusteriSifre",
                table: "Musteriler");
        }
    }
}
