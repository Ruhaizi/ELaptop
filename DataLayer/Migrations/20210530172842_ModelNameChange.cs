using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class ModelNameChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderModel",
                table: "OrderModel");

            migrationBuilder.RenameTable(
                name: "OrderModel",
                newName: "OrdersModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrdersModel",
                table: "OrdersModel",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrdersModel",
                table: "OrdersModel");

            migrationBuilder.RenameTable(
                name: "OrdersModel",
                newName: "OrderModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderModel",
                table: "OrderModel",
                column: "Id");
        }
    }
}
