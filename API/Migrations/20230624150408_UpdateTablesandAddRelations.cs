using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTablesandAddRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_users_Roles_RolesId",
                table: "tb_m_users");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_barang_masuk_tb_m_supplier_SupplierId",
                table: "tb_tr_barang_masuk");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_detail_barang_keluar_tb_m_barang_BarangKodeBarang",
                table: "tb_tr_detail_barang_keluar");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_detail_barang_keluar_tb_tr_barang_keluar_BarangKeluarId",
                table: "tb_tr_detail_barang_keluar");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_detail_barang_masuk_tb_m_barang_BarangKodeBarang",
                table: "tb_tr_detail_barang_masuk");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_detail_barang_masuk_tb_tr_barang_masuk_BarangMasukId",
                table: "tb_tr_detail_barang_masuk");

            migrationBuilder.DropIndex(
                name: "IX_tb_tr_detail_barang_masuk_BarangKodeBarang",
                table: "tb_tr_detail_barang_masuk");

            migrationBuilder.DropIndex(
                name: "IX_tb_tr_detail_barang_masuk_BarangMasukId",
                table: "tb_tr_detail_barang_masuk");

            migrationBuilder.DropIndex(
                name: "IX_tb_tr_detail_barang_keluar_BarangKeluarId",
                table: "tb_tr_detail_barang_keluar");

            migrationBuilder.DropIndex(
                name: "IX_tb_tr_detail_barang_keluar_BarangKodeBarang",
                table: "tb_tr_detail_barang_keluar");

            migrationBuilder.DropIndex(
                name: "IX_tb_tr_barang_masuk_SupplierId",
                table: "tb_tr_barang_masuk");

            migrationBuilder.DropIndex(
                name: "IX_tb_m_users_RolesId",
                table: "tb_m_users");

            migrationBuilder.DropColumn(
                name: "BarangKodeBarang",
                table: "tb_tr_detail_barang_masuk");

            migrationBuilder.DropColumn(
                name: "BarangMasukId",
                table: "tb_tr_detail_barang_masuk");

            migrationBuilder.DropColumn(
                name: "BarangKeluarId",
                table: "tb_tr_detail_barang_keluar");

            migrationBuilder.DropColumn(
                name: "BarangKodeBarang",
                table: "tb_tr_detail_barang_keluar");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "tb_tr_barang_masuk");

            migrationBuilder.DropColumn(
                name: "RolesId",
                table: "tb_m_users");

            migrationBuilder.AlterColumn<string>(
                name: "kd_barang",
                table: "tb_tr_detail_barang_masuk",
                type: "varchar(10)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(10)");

            migrationBuilder.AlterColumn<string>(
                name: "kd_barang",
                table: "tb_tr_detail_barang_keluar",
                type: "varchar(10)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(10)");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_detail_barang_masuk_id_masuk",
                table: "tb_tr_detail_barang_masuk",
                column: "id_masuk");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_detail_barang_masuk_kd_barang",
                table: "tb_tr_detail_barang_masuk",
                column: "kd_barang");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_detail_barang_keluar_id_keluar",
                table: "tb_tr_detail_barang_keluar",
                column: "id_keluar");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_detail_barang_keluar_kd_barang",
                table: "tb_tr_detail_barang_keluar",
                column: "kd_barang");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_barang_masuk_id_supplier",
                table: "tb_tr_barang_masuk",
                column: "id_supplier");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_users_roles",
                table: "tb_m_users",
                column: "roles");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_users_Roles_roles",
                table: "tb_m_users",
                column: "roles",
                principalTable: "Roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_barang_masuk_tb_m_supplier_id_supplier",
                table: "tb_tr_barang_masuk",
                column: "id_supplier",
                principalTable: "tb_m_supplier",
                principalColumn: "id_supplier",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_detail_barang_keluar_tb_m_barang_kd_barang",
                table: "tb_tr_detail_barang_keluar",
                column: "kd_barang",
                principalTable: "tb_m_barang",
                principalColumn: "kd_barang",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_detail_barang_keluar_tb_tr_barang_keluar_id_keluar",
                table: "tb_tr_detail_barang_keluar",
                column: "id_keluar",
                principalTable: "tb_tr_barang_keluar",
                principalColumn: "id_barang_keluar",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_detail_barang_masuk_tb_m_barang_kd_barang",
                table: "tb_tr_detail_barang_masuk",
                column: "kd_barang",
                principalTable: "tb_m_barang",
                principalColumn: "kd_barang",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_detail_barang_masuk_tb_tr_barang_masuk_id_masuk",
                table: "tb_tr_detail_barang_masuk",
                column: "id_masuk",
                principalTable: "tb_tr_barang_masuk",
                principalColumn: "id_barang_masuk",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_users_Roles_roles",
                table: "tb_m_users");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_barang_masuk_tb_m_supplier_id_supplier",
                table: "tb_tr_barang_masuk");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_detail_barang_keluar_tb_m_barang_kd_barang",
                table: "tb_tr_detail_barang_keluar");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_detail_barang_keluar_tb_tr_barang_keluar_id_keluar",
                table: "tb_tr_detail_barang_keluar");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_detail_barang_masuk_tb_m_barang_kd_barang",
                table: "tb_tr_detail_barang_masuk");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_detail_barang_masuk_tb_tr_barang_masuk_id_masuk",
                table: "tb_tr_detail_barang_masuk");

            migrationBuilder.DropIndex(
                name: "IX_tb_tr_detail_barang_masuk_id_masuk",
                table: "tb_tr_detail_barang_masuk");

            migrationBuilder.DropIndex(
                name: "IX_tb_tr_detail_barang_masuk_kd_barang",
                table: "tb_tr_detail_barang_masuk");

            migrationBuilder.DropIndex(
                name: "IX_tb_tr_detail_barang_keluar_id_keluar",
                table: "tb_tr_detail_barang_keluar");

            migrationBuilder.DropIndex(
                name: "IX_tb_tr_detail_barang_keluar_kd_barang",
                table: "tb_tr_detail_barang_keluar");

            migrationBuilder.DropIndex(
                name: "IX_tb_tr_barang_masuk_id_supplier",
                table: "tb_tr_barang_masuk");

            migrationBuilder.DropIndex(
                name: "IX_tb_m_users_roles",
                table: "tb_m_users");

            migrationBuilder.AlterColumn<string>(
                name: "kd_barang",
                table: "tb_tr_detail_barang_masuk",
                type: "char(10)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)");

            migrationBuilder.AddColumn<string>(
                name: "BarangKodeBarang",
                table: "tb_tr_detail_barang_masuk",
                type: "varchar(10)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BarangMasukId",
                table: "tb_tr_detail_barang_masuk",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "kd_barang",
                table: "tb_tr_detail_barang_keluar",
                type: "char(10)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)");

            migrationBuilder.AddColumn<int>(
                name: "BarangKeluarId",
                table: "tb_tr_detail_barang_keluar",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BarangKodeBarang",
                table: "tb_tr_detail_barang_keluar",
                type: "varchar(10)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "tb_tr_barang_masuk",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RolesId",
                table: "tb_m_users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_detail_barang_masuk_BarangKodeBarang",
                table: "tb_tr_detail_barang_masuk",
                column: "BarangKodeBarang");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_detail_barang_masuk_BarangMasukId",
                table: "tb_tr_detail_barang_masuk",
                column: "BarangMasukId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_detail_barang_keluar_BarangKeluarId",
                table: "tb_tr_detail_barang_keluar",
                column: "BarangKeluarId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_detail_barang_keluar_BarangKodeBarang",
                table: "tb_tr_detail_barang_keluar",
                column: "BarangKodeBarang");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_barang_masuk_SupplierId",
                table: "tb_tr_barang_masuk",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_users_RolesId",
                table: "tb_m_users",
                column: "RolesId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_users_Roles_RolesId",
                table: "tb_m_users",
                column: "RolesId",
                principalTable: "Roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_barang_masuk_tb_m_supplier_SupplierId",
                table: "tb_tr_barang_masuk",
                column: "SupplierId",
                principalTable: "tb_m_supplier",
                principalColumn: "id_supplier");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_detail_barang_keluar_tb_m_barang_BarangKodeBarang",
                table: "tb_tr_detail_barang_keluar",
                column: "BarangKodeBarang",
                principalTable: "tb_m_barang",
                principalColumn: "kd_barang");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_detail_barang_keluar_tb_tr_barang_keluar_BarangKeluarId",
                table: "tb_tr_detail_barang_keluar",
                column: "BarangKeluarId",
                principalTable: "tb_tr_barang_keluar",
                principalColumn: "id_barang_keluar");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_detail_barang_masuk_tb_m_barang_BarangKodeBarang",
                table: "tb_tr_detail_barang_masuk",
                column: "BarangKodeBarang",
                principalTable: "tb_m_barang",
                principalColumn: "kd_barang");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_detail_barang_masuk_tb_tr_barang_masuk_BarangMasukId",
                table: "tb_tr_detail_barang_masuk",
                column: "BarangMasukId",
                principalTable: "tb_tr_barang_masuk",
                principalColumn: "id_barang_masuk");
        }
    }
}
