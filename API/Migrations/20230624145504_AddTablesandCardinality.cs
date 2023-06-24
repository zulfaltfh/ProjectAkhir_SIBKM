using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class AddTablesandCardinality : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_barang",
                columns: table => new
                {
                    kd_barang = table.Column<string>(type: "varchar(10)", nullable: false),
                    nama_barang = table.Column<string>(type: "varchar(255)", nullable: false),
                    jenis_barang = table.Column<string>(type: "varchar(50)", nullable: false),
                    stok_barang = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_barang", x => x.kd_barang);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_supplier",
                columns: table => new
                {
                    id_supplier = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nama_supplier = table.Column<string>(type: "varchar(50)", nullable: false),
                    no_telp = table.Column<string>(type: "varchar(12)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_supplier", x => x.id_supplier);
                });

            migrationBuilder.CreateTable(
                name: "tb_tr_barang_keluar",
                columns: table => new
                {
                    id_barang_keluar = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tanggal_keluar = table.Column<DateTime>(type: "datetime", nullable: false),
                    nama_pembeli = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_tr_barang_keluar", x => x.id_barang_keluar);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_users",
                columns: table => new
                {
                    id_user = table.Column<string>(type: "char(8)", nullable: false),
                    username = table.Column<string>(type: "varchar(255)", nullable: false),
                    password = table.Column<string>(type: "varchar(255)", nullable: false),
                    full_name = table.Column<string>(type: "varchar(50)", nullable: false),
                    email = table.Column<string>(type: "varchar(50)", nullable: false),
                    no_telepon = table.Column<string>(type: "varchar(50)", nullable: false),
                    roles = table.Column<int>(type: "int", nullable: false),
                    RolesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_users", x => x.id_user);
                    table.ForeignKey(
                        name: "FK_tb_m_users_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_tr_barang_masuk",
                columns: table => new
                {
                    id_barang_masuk = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tanggal_masuk = table.Column<DateTime>(type: "datetime", nullable: false),
                    id_supplier = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_tr_barang_masuk", x => x.id_barang_masuk);
                    table.ForeignKey(
                        name: "FK_tb_tr_barang_masuk_tb_m_supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "tb_m_supplier",
                        principalColumn: "id_supplier");
                });

            migrationBuilder.CreateTable(
                name: "tb_tr_detail_barang_keluar",
                columns: table => new
                {
                    id_detail_keluar = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kd_barang = table.Column<string>(type: "varchar(10)", nullable: false),
                    id_keluar = table.Column<int>(type: "int", nullable: false),
                    jumlah = table.Column<int>(type: "int", nullable: false),
                    BarangKeluarId = table.Column<int>(type: "int", nullable: true),
                    BarangKodeBarang = table.Column<string>(type: "varchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_tr_detail_barang_keluar", x => x.id_detail_keluar);
                    table.ForeignKey(
                        name: "FK_tb_tr_detail_barang_keluar_tb_m_barang_BarangKodeBarang",
                        column: x => x.BarangKodeBarang,
                        principalTable: "tb_m_barang",
                        principalColumn: "kd_barang");
                    table.ForeignKey(
                        name: "FK_tb_tr_detail_barang_keluar_tb_tr_barang_keluar_BarangKeluarId",
                        column: x => x.BarangKeluarId,
                        principalTable: "tb_tr_barang_keluar",
                        principalColumn: "id_barang_keluar");
                });

            migrationBuilder.CreateTable(
                name: "tb_tr_detail_barang_masuk",
                columns: table => new
                {
                    id_detail_masuk = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kd_barang = table.Column<string>(type: "varchar(10)", nullable: false),
                    id_masuk = table.Column<int>(type: "int", nullable: false),
                    jumlah = table.Column<int>(type: "int", nullable: false),
                    BarangMasukId = table.Column<int>(type: "int", nullable: true),
                    BarangKodeBarang = table.Column<string>(type: "varchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_tr_detail_barang_masuk", x => x.id_detail_masuk);
                    table.ForeignKey(
                        name: "FK_tb_tr_detail_barang_masuk_tb_m_barang_BarangKodeBarang",
                        column: x => x.BarangKodeBarang,
                        principalTable: "tb_m_barang",
                        principalColumn: "kd_barang");
                    table.ForeignKey(
                        name: "FK_tb_tr_detail_barang_masuk_tb_tr_barang_masuk_BarangMasukId",
                        column: x => x.BarangMasukId,
                        principalTable: "tb_tr_barang_masuk",
                        principalColumn: "id_barang_masuk");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_users_RolesId",
                table: "tb_m_users",
                column: "RolesId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_barang_masuk_SupplierId",
                table: "tb_tr_barang_masuk",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_detail_barang_keluar_BarangKeluarId",
                table: "tb_tr_detail_barang_keluar",
                column: "BarangKeluarId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_detail_barang_keluar_BarangKodeBarang",
                table: "tb_tr_detail_barang_keluar",
                column: "BarangKodeBarang");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_detail_barang_masuk_BarangKodeBarang",
                table: "tb_tr_detail_barang_masuk",
                column: "BarangKodeBarang");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_detail_barang_masuk_BarangMasukId",
                table: "tb_tr_detail_barang_masuk",
                column: "BarangMasukId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_m_users");

            migrationBuilder.DropTable(
                name: "tb_tr_detail_barang_keluar");

            migrationBuilder.DropTable(
                name: "tb_tr_detail_barang_masuk");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "tb_tr_barang_keluar");

            migrationBuilder.DropTable(
                name: "tb_m_barang");

            migrationBuilder.DropTable(
                name: "tb_tr_barang_masuk");

            migrationBuilder.DropTable(
                name: "tb_m_supplier");
        }
    }
}
