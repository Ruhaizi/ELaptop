using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LaptopModel",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Product_Name = table.Column<string>(nullable: true),
                    ImgUrl = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaptopModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrdersModel",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ProdOrder = table.Column<string>(nullable: true),
                    OrderTotal = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LaptopModel");

            migrationBuilder.DropTable(
                name: "OrdersModel");
        }
    }
}
