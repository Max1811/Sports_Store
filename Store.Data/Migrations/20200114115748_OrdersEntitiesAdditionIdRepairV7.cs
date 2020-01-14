using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Data.Migrations
{
    public partial class OrdersEntitiesAdditionIdRepairV7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ORDER_ITEMS_ORDERS_OrderId",
                table: "ORDER_ITEMS");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderId",
                table: "ORDER_ITEMS",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ORDER_ITEMS_ORDERS_OrderId",
                table: "ORDER_ITEMS",
                column: "OrderId",
                principalTable: "ORDERS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ORDER_ITEMS_ORDERS_OrderId",
                table: "ORDER_ITEMS");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderId",
                table: "ORDER_ITEMS",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_ORDER_ITEMS_ORDERS_OrderId",
                table: "ORDER_ITEMS",
                column: "OrderId",
                principalTable: "ORDERS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
