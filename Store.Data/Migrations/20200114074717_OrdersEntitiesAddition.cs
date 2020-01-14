using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Data.Migrations
{
    public partial class OrdersEntitiesAddition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ORDERS",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    HomeAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDERS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ORDER_ITEMS",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ProductId = table.Column<string>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    OrderId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDER_ITEMS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ORDER_ITEMS_ORDERS_OrderId",
                        column: x => x.OrderId,
                        principalTable: "ORDERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SHOPPING_CART_ITEM_ProductId",
                table: "SHOPPING_CART_ITEM",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_ITEMS_OrderId",
                table: "ORDER_ITEMS",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_SHOPPING_CART_ITEM_PRODUCTS_ProductId",
                table: "SHOPPING_CART_ITEM",
                column: "ProductId",
                principalTable: "PRODUCTS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SHOPPING_CART_ITEM_PRODUCTS_ProductId",
                table: "SHOPPING_CART_ITEM");

            migrationBuilder.DropTable(
                name: "ORDER_ITEMS");

            migrationBuilder.DropTable(
                name: "ORDERS");

            migrationBuilder.DropIndex(
                name: "IX_SHOPPING_CART_ITEM_ProductId",
                table: "SHOPPING_CART_ITEM");
        }
    }
}
