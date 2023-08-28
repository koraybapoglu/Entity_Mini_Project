using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity_Musteri_Siparis_Project.Migrations
{
    /// <inheritdoc />
    public partial class MusteriTableSiparisIDColumnAllowNullsYes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musteriler_Siparis_SiparisID",
                table: "Musteriler");

            migrationBuilder.AlterColumn<int>(
                name: "SiparisID",
                table: "Musteriler",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Musteriler_Siparis_SiparisID",
                table: "Musteriler",
                column: "SiparisID",
                principalTable: "Siparis",
                principalColumn: "SiparisID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musteriler_Siparis_SiparisID",
                table: "Musteriler");

            migrationBuilder.AlterColumn<int>(
                name: "SiparisID",
                table: "Musteriler",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Musteriler_Siparis_SiparisID",
                table: "Musteriler",
                column: "SiparisID",
                principalTable: "Siparis",
                principalColumn: "SiparisID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
