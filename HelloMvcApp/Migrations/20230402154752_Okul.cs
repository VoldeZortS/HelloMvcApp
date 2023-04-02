using Microsoft.EntityFrameworkCore.Migrations;

namespace HelloMvcApp.Migrations
{
    public partial class Okul : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ogretmenler",
                columns: table => new
                {
                    Ogretmenid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tckimlik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ad = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Soyad = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Ders = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Ogrsayi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ogretmenler", x => x.Ogretmenid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ogretmenler");
        }
    }
}
