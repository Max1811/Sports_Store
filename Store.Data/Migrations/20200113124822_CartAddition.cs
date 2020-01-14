using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Data.Migrations
{
    public partial class CartAddition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "PRODUCTS",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateTable(
                name: "SHOPPING_CART",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHOPPING_CART", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SHOPPING_CART_USERS_UserId",
                        column: x => x.UserId,
                        principalTable: "USERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SHOPPING_CART_ITEM",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CartId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHOPPING_CART_ITEM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SHOPPING_CART_ITEM_SHOPPING_CART_CartId",
                        column: x => x.CartId,
                        principalTable: "SHOPPING_CART",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SHOPPING_CART_ITEM_PRODUCTS_ProductId",
                        column: x => x.ProductId,
                        principalTable: "PRODUCTS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_CategoryId",
                table: "PRODUCTS",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SHOPPING_CART_UserId",
                table: "SHOPPING_CART",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SHOPPING_CART_ITEM_CartId",
                table: "SHOPPING_CART_ITEM",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_SHOPPING_CART_ITEM_ProductId",
                table: "SHOPPING_CART_ITEM",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUCTS_PRODUCT_CATEGORIES_CategoryId",
                table: "PRODUCTS",
                column: "CategoryId",
                principalTable: "PRODUCT_CATEGORIES",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRODUCTS_PRODUCT_CATEGORIES_CategoryId",
                table: "PRODUCTS");

            migrationBuilder.DropTable(
                name: "SHOPPING_CART_ITEM");

            migrationBuilder.DropTable(
                name: "SHOPPING_CART");

            migrationBuilder.DropIndex(
                name: "IX_PRODUCTS_CategoryId",
                table: "PRODUCTS");

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "PRODUCTS",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);
        }
    }
}
