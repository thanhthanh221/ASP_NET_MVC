using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP_NET_MVC.Migrations
{
    public partial class value1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sản Phẩm",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tên = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Giá = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sản Phẩm", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sản Phẩm");
        }
    }
}
