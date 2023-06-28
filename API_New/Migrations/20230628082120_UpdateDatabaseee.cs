using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_New.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_usersRole_tb_m_roles_role_id",
                table: "tb_tr_usersRole");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_usersRole_tb_m_users_user_nip",
                table: "tb_tr_usersRole");

            migrationBuilder.DropTable(
                name: "tb_tr_detail_barang_keluar");

            migrationBuilder.DropTable(
                name: "tb_tr_detail_barang_masuk");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_tr_usersRole",
                table: "tb_tr_usersRole");

            migrationBuilder.RenameTable(
                name: "tb_tr_usersRole",
                newName: "UsersRoles");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "tb_m_supplier",
                newName: "id_supplier");

            migrationBuilder.RenameIndex(
                name: "IX_tb_tr_usersRole_user_nip",
                table: "UsersRoles",
                newName: "IX_UsersRoles_user_nip");

            migrationBuilder.RenameIndex(
                name: "IX_tb_tr_usersRole_role_id",
                table: "UsersRoles",
                newName: "IX_UsersRoles_role_id");

            migrationBuilder.AddColumn<int>(
                name: "jumlah",
                table: "tb_tr_barang_masuk",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "kd_barang",
                table: "tb_tr_barang_masuk",
                type: "varchar(10)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "nama_pembeli",
                table: "tb_tr_barang_keluar",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AddColumn<int>(
                name: "jumlah",
                table: "tb_tr_barang_keluar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "kd_barang",
                table: "tb_tr_barang_keluar",
                type: "varchar(10)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "tb_m_users",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)");

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "tb_m_users",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)");

            migrationBuilder.AlterColumn<string>(
                name: "no_telepon",
                table: "tb_m_users",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(12)");

            migrationBuilder.AlterColumn<string>(
                name: "full_name",
                table: "tb_m_users",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersRoles",
                table: "UsersRoles",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_barang_masuk_kd_barang",
                table: "tb_tr_barang_masuk",
                column: "kd_barang");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_barang_keluar_kd_barang",
                table: "tb_tr_barang_keluar",
                column: "kd_barang");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_barang_keluar_tb_m_barang_kd_barang",
                table: "tb_tr_barang_keluar",
                column: "kd_barang",
                principalTable: "tb_m_barang",
                principalColumn: "kd_barang",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_barang_masuk_tb_m_barang_kd_barang",
                table: "tb_tr_barang_masuk",
                column: "kd_barang",
                principalTable: "tb_m_barang",
                principalColumn: "kd_barang",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersRoles_tb_m_roles_role_id",
                table: "UsersRoles",
                column: "role_id",
                principalTable: "tb_m_roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersRoles_tb_m_users_user_nip",
                table: "UsersRoles",
                column: "user_nip",
                principalTable: "tb_m_users",
                principalColumn: "nip",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_barang_keluar_tb_m_barang_kd_barang",
                table: "tb_tr_barang_keluar");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_barang_masuk_tb_m_barang_kd_barang",
                table: "tb_tr_barang_masuk");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersRoles_tb_m_roles_role_id",
                table: "UsersRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersRoles_tb_m_users_user_nip",
                table: "UsersRoles");

            migrationBuilder.DropIndex(
                name: "IX_tb_tr_barang_masuk_kd_barang",
                table: "tb_tr_barang_masuk");

            migrationBuilder.DropIndex(
                name: "IX_tb_tr_barang_keluar_kd_barang",
                table: "tb_tr_barang_keluar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersRoles",
                table: "UsersRoles");

            migrationBuilder.DropColumn(
                name: "jumlah",
                table: "tb_tr_barang_masuk");

            migrationBuilder.DropColumn(
                name: "kd_barang",
                table: "tb_tr_barang_masuk");

            migrationBuilder.DropColumn(
                name: "jumlah",
                table: "tb_tr_barang_keluar");

            migrationBuilder.DropColumn(
                name: "kd_barang",
                table: "tb_tr_barang_keluar");

            migrationBuilder.RenameTable(
                name: "UsersRoles",
                newName: "tb_tr_usersRole");

            migrationBuilder.RenameColumn(
                name: "id_supplier",
                table: "tb_m_supplier",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_UsersRoles_user_nip",
                table: "tb_tr_usersRole",
                newName: "IX_tb_tr_usersRole_user_nip");

            migrationBuilder.RenameIndex(
                name: "IX_UsersRoles_role_id",
                table: "tb_tr_usersRole",
                newName: "IX_tb_tr_usersRole_role_id");

            migrationBuilder.AlterColumn<string>(
                name: "nama_pembeli",
                table: "tb_tr_barang_keluar",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "tb_m_users",
                type: "varchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "tb_m_users",
                type: "varchar(10)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "no_telepon",
                table: "tb_m_users",
                type: "varchar(12)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "full_name",
                table: "tb_m_users",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_tr_usersRole",
                table: "tb_tr_usersRole",
                column: "id");

            migrationBuilder.CreateTable(
                name: "tb_tr_detail_barang_keluar",
                columns: table => new
                {
                    id_barang_keluar = table.Column<int>(type: "int", nullable: false),
                    kd_barang = table.Column<string>(type: "varchar(10)", nullable: false),
                    nip_user = table.Column<string>(type: "char(8)", nullable: false),
                    jumlah = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_tr_detail_barang_keluar", x => x.id_barang_keluar);
                    table.ForeignKey(
                        name: "FK_tb_tr_detail_barang_keluar_tb_m_barang_kd_barang",
                        column: x => x.kd_barang,
                        principalTable: "tb_m_barang",
                        principalColumn: "kd_barang",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_tr_detail_barang_keluar_tb_m_users_nip_user",
                        column: x => x.nip_user,
                        principalTable: "tb_m_users",
                        principalColumn: "nip",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_tr_detail_barang_keluar_tb_tr_barang_keluar_id_barang_keluar",
                        column: x => x.id_barang_keluar,
                        principalTable: "tb_tr_barang_keluar",
                        principalColumn: "id_barang_keluar",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_tr_detail_barang_masuk",
                columns: table => new
                {
                    id_barang_masuk = table.Column<int>(type: "int", nullable: false),
                    kd_barang = table.Column<string>(type: "varchar(10)", nullable: false),
                    nip_user = table.Column<string>(type: "char(8)", nullable: false),
                    jumlah = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_tr_detail_barang_masuk", x => x.id_barang_masuk);
                    table.ForeignKey(
                        name: "FK_tb_tr_detail_barang_masuk_tb_m_barang_kd_barang",
                        column: x => x.kd_barang,
                        principalTable: "tb_m_barang",
                        principalColumn: "kd_barang",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_tr_detail_barang_masuk_tb_m_users_nip_user",
                        column: x => x.nip_user,
                        principalTable: "tb_m_users",
                        principalColumn: "nip",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_tr_detail_barang_masuk_tb_tr_barang_masuk_id_barang_masuk",
                        column: x => x.id_barang_masuk,
                        principalTable: "tb_tr_barang_masuk",
                        principalColumn: "id_barang_masuk",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_detail_barang_keluar_kd_barang",
                table: "tb_tr_detail_barang_keluar",
                column: "kd_barang");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_detail_barang_keluar_nip_user",
                table: "tb_tr_detail_barang_keluar",
                column: "nip_user");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_detail_barang_masuk_kd_barang",
                table: "tb_tr_detail_barang_masuk",
                column: "kd_barang");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_detail_barang_masuk_nip_user",
                table: "tb_tr_detail_barang_masuk",
                column: "nip_user");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_usersRole_tb_m_roles_role_id",
                table: "tb_tr_usersRole",
                column: "role_id",
                principalTable: "tb_m_roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_usersRole_tb_m_users_user_nip",
                table: "tb_tr_usersRole",
                column: "user_nip",
                principalTable: "tb_m_users",
                principalColumn: "nip",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
