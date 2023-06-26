using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "nip",
                table: "tb_tr_detail_barang_masuk",
                type: "char(8)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "nip",
                table: "tb_tr_detail_barang_keluar",
                type: "char(8)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_detail_barang_masuk_nip",
                table: "tb_tr_detail_barang_masuk",
                column: "nip");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_detail_barang_keluar_nip",
                table: "tb_tr_detail_barang_keluar",
                column: "nip");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_detail_barang_keluar_tb_m_users_nip",
                table: "tb_tr_detail_barang_keluar",
                column: "nip",
                principalTable: "tb_m_users",
                principalColumn: "nip",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_detail_barang_masuk_tb_m_users_nip",
                table: "tb_tr_detail_barang_masuk",
                column: "nip",
                principalTable: "tb_m_users",
                principalColumn: "nip",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_detail_barang_keluar_tb_m_users_nip",
                table: "tb_tr_detail_barang_keluar");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_detail_barang_masuk_tb_m_users_nip",
                table: "tb_tr_detail_barang_masuk");

            migrationBuilder.DropIndex(
                name: "IX_tb_tr_detail_barang_masuk_nip",
                table: "tb_tr_detail_barang_masuk");

            migrationBuilder.DropIndex(
                name: "IX_tb_tr_detail_barang_keluar_nip",
                table: "tb_tr_detail_barang_keluar");

            migrationBuilder.DropColumn(
                name: "nip",
                table: "tb_tr_detail_barang_masuk");

            migrationBuilder.DropColumn(
                name: "nip",
                table: "tb_tr_detail_barang_keluar");
        }
    }
}
