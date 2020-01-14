using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Data.Migrations
{
    public partial class Cart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRODUCTS_PRODUCT_CATEGORIES_CategoryId",
                table: "PRODUCTS");

            migrationBuilder.DropForeignKey(
                name: "FK_SHOPPING_CART_USERS_UserId",
                table: "SHOPPING_CART");

            migrationBuilder.DropForeignKey(
                name: "FK_SHOPPING_CART_ITEM_PRODUCTS_ProductId",
                table: "SHOPPING_CART_ITEM");

            migrationBuilder.DropIndex(
                name: "IX_SHOPPING_CART_ITEM_ProductId",
                table: "SHOPPING_CART_ITEM");

            migrationBuilder.DropIndex(
                name: "IX_SHOPPING_CART_UserId",
                table: "SHOPPING_CART");

            migrationBuilder.DropIndex(
                name: "IX_PRODUCTS_CategoryId",
                table: "PRODUCTS");

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "PRODUCTS",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "PRODUCTS",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.CreateIndex(
                name: "IX_SHOPPING_CART_ITEM_ProductId",
                table: "SHOPPING_CART_ITEM",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SHOPPING_CART_UserId",
                table: "SHOPPING_CART",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_CategoryId",
                table: "PRODUCTS",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUCTS_PRODUCT_CATEGORIES_CategoryId",
                table: "PRODUCTS",
                column: "CategoryId",
                principalTable: "PRODUCT_CATEGORIES",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SHOPPING_CART_USERS_UserId",
                table: "SHOPPING_CART",
                column: "UserId",
                principalTable: "USERS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SHOPPING_CART_ITEM_PRODUCTS_ProductId",
                table: "SHOPPING_CART_ITEM",
                column: "ProductId",
                principalTable: "PRODUCTS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
