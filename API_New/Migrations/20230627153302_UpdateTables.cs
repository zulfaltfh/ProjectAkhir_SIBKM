using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_New.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_detail_barang_keluar_tb_m_users_nip_employee",
                table: "tb_tr_detail_barang_keluar");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_detail_barang_keluar_tb_tr_barang_keluar_id_keluar",
                table: "tb_tr_detail_barang_keluar");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_detail_barang_masuk_tb_m_users_nip_employee",
                table: "tb_tr_detail_barang_masuk");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_detail_barang_masuk_tb_tr_barang_masuk_id_masuk",
                table: "tb_tr_detail_barang_masuk");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersRoles_tb_m_roles_role_id",
                table: "UsersRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersRoles_tb_m_users_user_nip",
                table: "UsersRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersRoles",
                table: "UsersRoles");

            migrationBuilder.RenameTable(
                name: "UsersRoles",
                newName: "tb_tr_usersRole");

            migrationBuilder.RenameColumn(
                name: "nip_employee",
                table: "tb_tr_detail_barang_masuk",
                newName: "nip_user");

            migrationBuilder.RenameColumn(
                name: "id_masuk",
                table: "tb_tr_detail_barang_masuk",
                newName: "id_barang_masuk");

            migrationBuilder.RenameIndex(
                name: "IX_tb_tr_detail_barang_masuk_nip_employee",
                table: "tb_tr_detail_barang_masuk",
                newName: "IX_tb_tr_detail_barang_masuk_nip_user");

            migrationBuilder.RenameColumn(
                name: "nip_employee",
                table: "tb_tr_detail_barang_keluar",
                newName: "nip_user");

            migrationBuilder.RenameColumn(
                name: "id_keluar",
                table: "tb_tr_detail_barang_keluar",
                newName: "id_barang_keluar");

            migrationBuilder.RenameIndex(
                name: "IX_tb_tr_detail_barang_keluar_nip_employee",
                table: "tb_tr_detail_barang_keluar",
                newName: "IX_tb_tr_detail_barang_keluar_nip_user");

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

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_detail_barang_keluar_tb_m_users_nip_user",
                table: "tb_tr_detail_barang_keluar",
                column: "nip_user",
                principalTable: "tb_m_users",
                principalColumn: "nip",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_detail_barang_keluar_tb_tr_barang_keluar_id_barang_keluar",
                table: "tb_tr_detail_barang_keluar",
                column: "id_barang_keluar",
                principalTable: "tb_tr_barang_keluar",
                principalColumn: "id_barang_keluar",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_detail_barang_masuk_tb_m_users_nip_user",
                table: "tb_tr_detail_barang_masuk",
                column: "nip_user",
                principalTable: "tb_m_users",
                principalColumn: "nip",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_detail_barang_masuk_tb_tr_barang_masuk_id_barang_masuk",
                table: "tb_tr_detail_barang_masuk",
                column: "id_barang_masuk",
                principalTable: "tb_tr_barang_masuk",
                principalColumn: "id_barang_masuk",
                onDelete: ReferentialAction.Restrict);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_detail_barang_keluar_tb_m_users_nip_user",
                table: "tb_tr_detail_barang_keluar");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_detail_barang_keluar_tb_tr_barang_keluar_id_barang_keluar",
                table: "tb_tr_detail_barang_keluar");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_detail_barang_masuk_tb_m_users_nip_user",
                table: "tb_tr_detail_barang_masuk");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_detail_barang_masuk_tb_tr_barang_masuk_id_barang_masuk",
                table: "tb_tr_detail_barang_masuk");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_usersRole_tb_m_roles_role_id",
                table: "tb_tr_usersRole");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_usersRole_tb_m_users_user_nip",
                table: "tb_tr_usersRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_tr_usersRole",
                table: "tb_tr_usersRole");

            migrationBuilder.RenameTable(
                name: "tb_tr_usersRole",
                newName: "UsersRoles");

            migrationBuilder.RenameColumn(
                name: "nip_user",
                table: "tb_tr_detail_barang_masuk",
                newName: "nip_employee");

            migrationBuilder.RenameColumn(
                name: "id_barang_masuk",
                table: "tb_tr_detail_barang_masuk",
                newName: "id_masuk");

            migrationBuilder.RenameIndex(
                name: "IX_tb_tr_detail_barang_masuk_nip_user",
                table: "tb_tr_detail_barang_masuk",
                newName: "IX_tb_tr_detail_barang_masuk_nip_employee");

            migrationBuilder.RenameColumn(
                name: "nip_user",
                table: "tb_tr_detail_barang_keluar",
                newName: "nip_employee");

            migrationBuilder.RenameColumn(
                name: "id_barang_keluar",
                table: "tb_tr_detail_barang_keluar",
                newName: "id_keluar");

            migrationBuilder.RenameIndex(
                name: "IX_tb_tr_detail_barang_keluar_nip_user",
                table: "tb_tr_detail_barang_keluar",
                newName: "IX_tb_tr_detail_barang_keluar_nip_employee");

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

            migrationBuilder.AlterColumn<string>(
                name: "nama_pembeli",
                table: "tb_tr_barang_keluar",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

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

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_detail_barang_keluar_tb_m_users_nip_employee",
                table: "tb_tr_detail_barang_keluar",
                column: "nip_employee",
                principalTable: "tb_m_users",
                principalColumn: "nip",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_detail_barang_keluar_tb_tr_barang_keluar_id_keluar",
                table: "tb_tr_detail_barang_keluar",
                column: "id_keluar",
                principalTable: "tb_tr_barang_keluar",
                principalColumn: "id_barang_keluar",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_detail_barang_masuk_tb_m_users_nip_employee",
                table: "tb_tr_detail_barang_masuk",
                column: "nip_employee",
                principalTable: "tb_m_users",
                principalColumn: "nip",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_detail_barang_masuk_tb_tr_barang_masuk_id_masuk",
                table: "tb_tr_detail_barang_masuk",
                column: "id_masuk",
                principalTable: "tb_tr_barang_masuk",
                principalColumn: "id_barang_masuk",
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
    }
}
