using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI_CF.Migrations
{
    public partial class AddTbCatalog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CataID",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Loai",
                columns: table => new
                {
                    CataID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cataname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loai", x => x.CataID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CataID",
                table: "Products",
                column: "CataID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Loai_CataID",
                table: "Products",
                column: "CataID",
                principalTable: "Loai",
                principalColumn: "CataID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Loai_CataID",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Loai");

            migrationBuilder.DropIndex(
                name: "IX_Products_CataID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CataID",
                table: "Products");
        }
    }
}
