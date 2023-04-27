using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeanASP.Net.Migrations
{
    /// <inheritdoc />
    public partial class addCategoryToDatabase : Migration
    {
        /// <inheritdoc />
        // up là những gì cần xảy ra bên trong di chuyển
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // tạo bảng
            migrationBuilder.CreateTable(
                // tạo bảng có tên Categories
                name: "Categories",
                // với các cột
                columns: table => new
                {
                    // id kiểu int, nullable: false: Chỉ định rằng cột này không thể có giá trị null (rỗng) trong cơ sở dữ
                    // và tự động tăng 1
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                // khóa chính
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });
        }

        /// <inheritdoc />
        // down là nếu có gì đó không ổn Chúng ta cần khôi phục các thay đổi
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
