using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_New.Migrations
{
    /// <inheritdoc />
    public partial class AddTableandRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "tb_m_roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_roles", x => x.id);
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
                name: "tb_m_users",
                columns: table => new
                {
                    nip = table.Column<string>(type: "char(8)", nullable: false),
                    username = table.Column<string>(type: "varchar(255)", nullable: false),
                    password = table.Column<string>(type: "varchar(255)", nullable: false),
                    full_name = table.Column<string>(type: "varchar(50)", nullable: false),
                    email = table.Column<string>(type: "varchar(50)", nullable: false),
                    no_telepon = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_users", x => x.nip);
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
                name: "tb_tr_barang_masuk",
                columns: table => new
                {
                    id_barang_masuk = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tanggal_masuk = table.Column<DateTime>(type: "datetime", nullable: false),
                    id_supplier = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_tr_barang_masuk", x => x.id_barang_masuk);
                    table.ForeignKey(
                        name: "FK_tb_tr_barang_masuk_tb_m_supplier_id_supplier",
                        column: x => x.id_supplier,
                        principalTable: "tb_m_supplier",
                        principalColumn: "id_supplier",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsersRoles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_nip = table.Column<string>(type: "char(8)", nullable: false),
                    role_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersRoles", x => x.id);
                    table.ForeignKey(
                        name: "FK_UsersRoles_tb_m_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "tb_m_roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersRoles_tb_m_users_user_nip",
                        column: x => x.user_nip,
                        principalTable: "tb_m_users",
                        principalColumn: "nip",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_tr_detail_barang_keluar",
                columns: table => new
                {
                    id_keluar = table.Column<int>(type: "int", nullable: false),
                    kd_barang = table.Column<string>(type: "varchar(10)", nullable: false),
                    nip_employee = table.Column<string>(type: "char(8)", nullable: false),
                    jumlah = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_tr_detail_barang_keluar", x => x.id_keluar);
                    table.ForeignKey(
                        name: "FK_tb_tr_detail_barang_keluar_tb_m_barang_kd_barang",
                        column: x => x.kd_barang,
                        principalTable: "tb_m_barang",
                        principalColumn: "kd_barang",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_tr_detail_barang_keluar_tb_m_users_nip_employee",
                        column: x => x.nip_employee,
                        principalTable: "tb_m_users",
                        principalColumn: "nip",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_tr_detail_barang_keluar_tb_tr_barang_keluar_id_keluar",
                        column: x => x.id_keluar,
                        principalTable: "tb_tr_barang_keluar",
                        principalColumn: "id_barang_keluar",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_tr_detail_barang_masuk",
                columns: table => new
                {
                    id_masuk = table.Column<int>(type: "int", nullable: false),
                    kd_barang = table.Column<string>(type: "varchar(10)", nullable: false),
                    nip_employee = table.Column<string>(type: "char(8)", nullable: false),
                    jumlah = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_tr_detail_barang_masuk", x => x.id_masuk);
                    table.ForeignKey(
                        name: "FK_tb_tr_detail_barang_masuk_tb_m_barang_kd_barang",
                        column: x => x.kd_barang,
                        principalTable: "tb_m_barang",
                        principalColumn: "kd_barang",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_tr_detail_barang_masuk_tb_m_users_nip_employee",
                        column: x => x.nip_employee,
                        principalTable: "tb_m_users",
                        principalColumn: "nip",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_tr_detail_barang_masuk_tb_tr_barang_masuk_id_masuk",
                        column: x => x.id_masuk,
                        principalTable: "tb_tr_barang_masuk",
                        principalColumn: "id_barang_masuk",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_barang_masuk_id_supplier",
                table: "tb_tr_barang_masuk",
                column: "id_supplier");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_detail_barang_keluar_kd_barang",
                table: "tb_tr_detail_barang_keluar",
                column: "kd_barang");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_detail_barang_keluar_nip_employee",
                table: "tb_tr_detail_barang_keluar",
                column: "nip_employee");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_detail_barang_masuk_kd_barang",
                table: "tb_tr_detail_barang_masuk",
                column: "kd_barang");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_detail_barang_masuk_nip_employee",
                table: "tb_tr_detail_barang_masuk",
                column: "nip_employee");

            migrationBuilder.CreateIndex(
                name: "IX_UsersRoles_role_id",
                table: "UsersRoles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_UsersRoles_user_nip",
                table: "UsersRoles",
                column: "user_nip");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_tr_detail_barang_keluar");

            migrationBuilder.DropTable(
                name: "tb_tr_detail_barang_masuk");

            migrationBuilder.DropTable(
                name: "UsersRoles");

            migrationBuilder.DropTable(
                name: "tb_tr_barang_keluar");

            migrationBuilder.DropTable(
                name: "tb_m_barang");

            migrationBuilder.DropTable(
                name: "tb_tr_barang_masuk");

            migrationBuilder.DropTable(
                name: "tb_m_roles");

            migrationBuilder.DropTable(
                name: "tb_m_users");

            migrationBuilder.DropTable(
                name: "tb_m_supplier");
        }
    }
}
