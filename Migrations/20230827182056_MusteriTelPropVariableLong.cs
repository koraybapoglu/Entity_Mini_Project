using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity_Musteri_Siparis_Project.Migrations
{
    /// <inheritdoc />
    public partial class MusteriTelPropVariableLong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "MusteriTel",
                table: "Musteriler",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MusteriTel",
                table: "Musteriler",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
