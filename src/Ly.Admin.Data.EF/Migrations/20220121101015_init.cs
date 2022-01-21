using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ly.Admin.Data.EF.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "sys_auth",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false, comment: "主键Id")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<int>(type: "int(11)", nullable: false),
                    platform = table.Column<int>(type: "int(1)", nullable: false, defaultValue: 0, comment: "登录平台"),
                    refresh_token = table.Column<string>(type: "varchar(50)", nullable: false, comment: "刷新令牌")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    refresh_token_expired_time = table.Column<DateTime>(type: "datetime", nullable: false, comment: "刷新令牌过期时间"),
                    login_time = table.Column<DateTime>(type: "datetime", nullable: false, comment: "最后登录时间戳"),
                    login_IP = table.Column<string>(type: "varchar(50)", nullable: false, comment: "最后登录IP")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    sort_id = table.Column<int>(type: "int(11)", nullable: false, comment: "排序"),
                    delete_flag = table.Column<int>(type: "int(1)", nullable: false, defaultValue: 1, comment: "删除标识"),
                    created_by = table.Column<int>(type: "int(11)", nullable: false, comment: "创建人"),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: false, comment: "创建时间")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    update_by = table.Column<int>(type: "int(11)", nullable: true, comment: "更新人"),
                    update_time = table.Column<DateTime>(type: "datetime", nullable: true, comment: "更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_auth", x => x.id);
                },
                comment: "认证信息")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "sys_menu",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false, comment: "主键Id")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    parent_id = table.Column<int>(type: "int(11)", nullable: false, comment: "父级"),
                    menu_name = table.Column<string>(type: "varchar(50)", nullable: false, comment: "菜单名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    menu_url = table.Column<string>(type: "varchar(200)", nullable: false, comment: "菜单链接")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    permission_code = table.Column<string>(type: "varchar(500)", nullable: false, comment: "权限码")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    is_display = table.Column<int>(type: "int(1)", nullable: false, defaultValue: 1, comment: "是否显示"),
                    hierarchy = table.Column<int>(type: "int(1)", nullable: false, comment: "层级"),
                    menu_type = table.Column<int>(type: "int(1)", nullable: false, comment: "菜单类型"),
                    open_type = table.Column<int>(type: "int(1)", nullable: false, comment: "打开方式"),
                    menu_icon = table.Column<string>(type: "varchar(50)", nullable: false, comment: "图标")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    status = table.Column<int>(type: "int(1)", nullable: false, defaultValue: 1, comment: "状态"),
                    sort_id = table.Column<int>(type: "int(11)", nullable: false, comment: "排序"),
                    delete_flag = table.Column<int>(type: "int(1)", nullable: false, defaultValue: 1, comment: "删除标识"),
                    created_by = table.Column<int>(type: "int(11)", nullable: false, comment: "创建人"),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: false, comment: "创建时间")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    update_by = table.Column<int>(type: "int(11)", nullable: true, comment: "更新人"),
                    update_time = table.Column<DateTime>(type: "datetime", nullable: true, comment: "更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_menu", x => x.id);
                },
                comment: "菜单表")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "sys_r_role_menu",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false, comment: "主键Id")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    role_id = table.Column<int>(type: "int(11)", nullable: false, comment: "角色Id"),
                    menu_id = table.Column<int>(type: "int(11)", nullable: false, comment: "菜单Id"),
                    sort_id = table.Column<int>(type: "int(11)", nullable: false, comment: "排序"),
                    delete_flag = table.Column<int>(type: "int(1)", nullable: false, comment: "删除标识"),
                    created_by = table.Column<int>(type: "int(11)", nullable: false, comment: "创建人"),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: false, comment: "创建时间"),
                    update_by = table.Column<int>(type: "int(11)", nullable: true, comment: "更新人"),
                    update_time = table.Column<DateTime>(type: "datetime", nullable: true, comment: "更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_r_role_menu", x => x.id);
                },
                comment: "角色菜单对应关系")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "sys_r_user_menu",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false, comment: "主键Id")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<int>(type: "int(11)", nullable: false, comment: "用户Id"),
                    menu_id = table.Column<int>(type: "int(11)", nullable: false, comment: "菜单Id"),
                    have_permission = table.Column<int>(type: "int(1)", nullable: false, comment: "是否拥有权限"),
                    sort_id = table.Column<int>(type: "int(11)", nullable: false, comment: "排序"),
                    delete_flag = table.Column<int>(type: "int(1)", nullable: false, comment: "删除标识"),
                    created_by = table.Column<int>(type: "int(11)", nullable: false, comment: "创建人"),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: false, comment: "创建时间"),
                    update_by = table.Column<int>(type: "int(11)", nullable: true, comment: "更新人"),
                    update_time = table.Column<DateTime>(type: "datetime", nullable: true, comment: "更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_r_user_menu", x => x.id);
                },
                comment: "用户菜单对应关系")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "sys_r_user_role",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false, comment: "主键Id")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<int>(type: "int(11)", nullable: false, comment: "用户Id"),
                    role_id = table.Column<int>(type: "int(11)", nullable: false, comment: "角色Id"),
                    sort_id = table.Column<int>(type: "int(11)", nullable: false, comment: "排序"),
                    delete_flag = table.Column<int>(type: "int(1)", nullable: false, comment: "删除标识"),
                    created_by = table.Column<int>(type: "int(11)", nullable: false, comment: "创建人"),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: false, comment: "创建时间"),
                    update_by = table.Column<int>(type: "int(11)", nullable: true, comment: "更新人"),
                    update_time = table.Column<DateTime>(type: "datetime", nullable: true, comment: "更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_r_user_role", x => x.id);
                },
                comment: "用户角色对应关系")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "sys_role",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false, comment: "主键Id")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    role_name = table.Column<string>(type: "varchar(50)", nullable: false, comment: "角色名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    remark = table.Column<string>(type: "varchar(200)", nullable: false, comment: "备注")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    status = table.Column<int>(type: "int(1)", nullable: false, defaultValue: 1, comment: "状态"),
                    sort_id = table.Column<int>(type: "int(11)", nullable: false, comment: "排序"),
                    delete_flag = table.Column<int>(type: "int(1)", nullable: false, defaultValue: 1, comment: "删除标识"),
                    created_by = table.Column<int>(type: "int(11)", nullable: false, comment: "创建人"),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: false, comment: "创建时间")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    update_by = table.Column<int>(type: "int(11)", nullable: true, comment: "更新人"),
                    update_time = table.Column<DateTime>(type: "datetime", nullable: true, comment: "更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_role", x => x.id);
                },
                comment: "角色表")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "sys_user",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false, comment: "主键Id")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_name = table.Column<string>(type: "varchar(20)", nullable: false, comment: "用户名")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    real_name = table.Column<string>(type: "varchar(10)", nullable: false, comment: "姓名")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "varchar(50)", nullable: false, comment: "密码")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    gender = table.Column<int>(type: "int(1)", nullable: false, defaultValue: 0, comment: "性别"),
                    status = table.Column<int>(type: "int(1)", nullable: false, defaultValue: 1, comment: "状态"),
                    sort_id = table.Column<int>(type: "int(11)", nullable: false, comment: "排序"),
                    delete_flag = table.Column<int>(type: "int(1)", nullable: false, defaultValue: 1, comment: "删除标识"),
                    created_by = table.Column<int>(type: "int(11)", nullable: false, comment: "创建人"),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: false, comment: "创建时间")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    update_by = table.Column<int>(type: "int(11)", nullable: true, comment: "更新人"),
                    update_time = table.Column<DateTime>(type: "datetime", nullable: true, comment: "更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_user", x => x.id);
                },
                comment: "用户表")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_post",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false, comment: "主键Id")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "longtext", nullable: false, comment: "标题")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    body = table.Column<string>(type: "longtext", nullable: false, comment: "内容")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    author = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, defaultValue: "1", comment: "作者")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    sort_id = table.Column<int>(type: "int(11)", nullable: false, comment: "排序"),
                    delete_flag = table.Column<int>(type: "int(1)", nullable: false, defaultValue: 1, comment: "删除标识"),
                    created_by = table.Column<int>(type: "int(11)", nullable: false, comment: "创建人"),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: false, comment: "创建时间")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    update_by = table.Column<int>(type: "int(11)", nullable: true, comment: "更新人"),
                    update_time = table.Column<DateTime>(type: "datetime", nullable: true, comment: "更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_post", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sys_auth");

            migrationBuilder.DropTable(
                name: "sys_menu");

            migrationBuilder.DropTable(
                name: "sys_r_role_menu");

            migrationBuilder.DropTable(
                name: "sys_r_user_menu");

            migrationBuilder.DropTable(
                name: "sys_r_user_role");

            migrationBuilder.DropTable(
                name: "sys_role");

            migrationBuilder.DropTable(
                name: "sys_user");

            migrationBuilder.DropTable(
                name: "tb_post");
        }
    }
}
