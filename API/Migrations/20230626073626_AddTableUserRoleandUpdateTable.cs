using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class AddTableUserRoleandUpdateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_users_Roles_roles",
                table: "tb_m_users");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_detail_barang_keluar_tb_m_users_nip",
                table: "tb_tr_detail_barang_keluar");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_detail_barang_masuk_tb_m_users_nip",
                table: "tb_tr_detail_barang_masuk");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_tr_detail_barang_masuk",
                table: "tb_tr_detail_barang_masuk");

            migrationBuilder.DropIndex(
                name: "IX_tb_tr_detail_barang_masuk_id_masuk",
                table: "tb_tr_detail_barang_masuk");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_tr_detail_barang_keluar",
                table: "tb_tr_detail_barang_keluar");

            migrationBuilder.DropIndex(
                name: "IX_tb_tr_detail_barang_keluar_id_keluar",
                table: "tb_tr_detail_barang_keluar");

            migrationBuilder.DropIndex(
                name: "IX_tb_m_users_roles",
                table: "tb_m_users");

            migrationBuilder.DropColumn(
                name: "id_detail_masuk",
                table: "tb_tr_detail_barang_masuk");

            migrationBuilder.DropColumn(
                name: "id_detail_keluar",
                table: "tb_tr_detail_barang_keluar");

            migrationBuilder.DropColumn(
                name: "roles",
                table: "tb_m_users");

            migrationBuilder.RenameColumn(
                name: "nip",
                table: "tb_tr_detail_barang_masuk",
                newName: "nip_employee");

            migrationBuilder.RenameIndex(
                name: "IX_tb_tr_detail_barang_masuk_nip",
                table: "tb_tr_detail_barang_masuk",
                newName: "IX_tb_tr_detail_barang_masuk_nip_employee");

            migrationBuilder.RenameColumn(
                name: "nip",
                table: "tb_tr_detail_barang_keluar",
                newName: "nip_employee");

            migrationBuilder.RenameIndex(
                name: "IX_tb_tr_detail_barang_keluar_nip",
                table: "tb_tr_detail_barang_keluar",
                newName: "IX_tb_tr_detail_barang_keluar_nip_employee");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_tr_detail_barang_masuk",
                table: "tb_tr_detail_barang_masuk",
                column: "id_masuk");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_tr_detail_barang_keluar",
                table: "tb_tr_detail_barang_keluar",
                column: "id_keluar");

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
                        name: "FK_UsersRoles_Roles_role_id",
                        column: x => x.role_id,
                        principalTable: "Roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersRoles_tb_m_users_user_nip",
                        column: x => x.user_nip,
                        principalTable: "tb_m_users",
                        principalColumn: "nip",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersRoles_role_id",
                table: "UsersRoles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_UsersRoles_user_nip",
                table: "UsersRoles",
                column: "user_nip");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_detail_barang_keluar_tb_m_users_nip_employee",
                table: "tb_tr_detail_barang_keluar",
                column: "nip_employee",
                principalTable: "tb_m_users",
                principalColumn: "nip",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_detail_barang_masuk_tb_m_users_nip_employee",
                table: "tb_tr_detail_barang_masuk",
                column: "nip_employee",
                principalTable: "tb_m_users",
                principalColumn: "nip",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_detail_barang_keluar_tb_m_users_nip_employee",
                table: "tb_tr_detail_barang_keluar");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_detail_barang_masuk_tb_m_users_nip_employee",
                table: "tb_tr_detail_barang_masuk");

            migrationBuilder.DropTable(
                name: "UsersRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_tr_detail_barang_masuk",
                table: "tb_tr_detail_barang_masuk");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_tr_detail_barang_keluar",
                table: "tb_tr_detail_barang_keluar");

            migrationBuilder.RenameColumn(
                name: "nip_employee",
                table: "tb_tr_detail_barang_masuk",
                newName: "nip");

            migrationBuilder.RenameIndex(
                name: "IX_tb_tr_detail_barang_masuk_nip_employee",
                table: "tb_tr_detail_barang_masuk",
                newName: "IX_tb_tr_detail_barang_masuk_nip");

            migrationBuilder.RenameColumn(
                name: "nip_employee",
                table: "tb_tr_detail_barang_keluar",
                newName: "nip");

            migrationBuilder.RenameIndex(
                name: "IX_tb_tr_detail_barang_keluar_nip_employee",
                table: "tb_tr_detail_barang_keluar",
                newName: "IX_tb_tr_detail_barang_keluar_nip");

            migrationBuilder.AddColumn<int>(
                name: "id_detail_masuk",
                table: "tb_tr_detail_barang_masuk",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "id_detail_keluar",
                table: "tb_tr_detail_barang_keluar",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "roles",
                table: "tb_m_users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_tr_detail_barang_masuk",
                table: "tb_tr_detail_barang_masuk",
                column: "id_detail_masuk");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_tr_detail_barang_keluar",
                table: "tb_tr_detail_barang_keluar",
                column: "id_detail_keluar");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_detail_barang_masuk_id_masuk",
                table: "tb_tr_detail_barang_masuk",
                column: "id_masuk");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_detail_barang_keluar_id_keluar",
                table: "tb_tr_detail_barang_keluar",
                column: "id_keluar");

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
    }
}
