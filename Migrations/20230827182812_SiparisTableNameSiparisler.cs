using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity_Musteri_Siparis_Project.Migrations
{
    /// <inheritdoc />
    public partial class SiparisTableNameSiparisler : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musteriler_Siparis_SiparisID",
                table: "Musteriler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Siparis",
                table: "Siparis");

            migrationBuilder.RenameTable(
                name: "Siparis",
                newName: "Siparisler");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Siparisler",
                table: "Siparisler",
                column: "SiparisID");

            migrationBuilder.AddForeignKey(
                name: "FK_Musteriler_Siparisler_SiparisID",
                table: "Musteriler",
                column: "SiparisID",
                principalTable: "Siparisler",
                principalColumn: "SiparisID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musteriler_Siparisler_SiparisID",
                table: "Musteriler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Siparisler",
                table: "Siparisler");

            migrationBuilder.RenameTable(
                name: "Siparisler",
                newName: "Siparis");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Siparis",
                table: "Siparis",
                column: "SiparisID");

            migrationBuilder.AddForeignKey(
                name: "FK_Musteriler_Siparis_SiparisID",
                table: "Musteriler",
                column: "SiparisID",
                principalTable: "Siparis",
                principalColumn: "SiparisID");
        }
    }
}
