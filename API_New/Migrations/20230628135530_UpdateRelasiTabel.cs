using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_New.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRelasiTabel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "user_nip",
                table: "tb_tr_barang_masuk",
                type: "char(8)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "user_nip",
                table: "tb_tr_barang_keluar",
                type: "char(8)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_barang_masuk_user_nip",
                table: "tb_tr_barang_masuk",
                column: "user_nip");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_barang_keluar_user_nip",
                table: "tb_tr_barang_keluar",
                column: "user_nip");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_barang_keluar_tb_m_users_user_nip",
                table: "tb_tr_barang_keluar",
                column: "user_nip",
                principalTable: "tb_m_users",
                principalColumn: "nip",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_barang_masuk_tb_m_users_user_nip",
                table: "tb_tr_barang_masuk",
                column: "user_nip",
                principalTable: "tb_m_users",
                principalColumn: "nip",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_barang_keluar_tb_m_users_user_nip",
                table: "tb_tr_barang_keluar");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_barang_masuk_tb_m_users_user_nip",
                table: "tb_tr_barang_masuk");

            migrationBuilder.DropIndex(
                name: "IX_tb_tr_barang_masuk_user_nip",
                table: "tb_tr_barang_masuk");

            migrationBuilder.DropIndex(
                name: "IX_tb_tr_barang_keluar_user_nip",
                table: "tb_tr_barang_keluar");

            migrationBuilder.DropColumn(
                name: "user_nip",
                table: "tb_tr_barang_masuk");

            migrationBuilder.DropColumn(
                name: "user_nip",
                table: "tb_tr_barang_keluar");
        }
    }
}
