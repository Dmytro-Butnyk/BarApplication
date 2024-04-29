using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB_Coursework.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Orders_Order_IdId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Tables_Table_IdId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Product_IdId",
                table: "Supplies",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Supplies_Product_IdId",
                table: "Supplies",
                newName: "IX_Supplies_ProductId");

            migrationBuilder.RenameColumn(
                name: "Table_IdId",
                table: "Orders",
                newName: "TableId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_Table_IdId",
                table: "Orders",
                newName: "IX_Orders_TableId");

            migrationBuilder.RenameColumn(
                name: "Product_IdId",
                table: "OrderDetails",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "Order_IdId",
                table: "OrderDetails",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_Product_IdId",
                table: "OrderDetails",
                newName: "IX_OrderDetails_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_Order_IdId",
                table: "OrderDetails",
                newName: "IX_OrderDetails_OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Orders_OrderId",
                table: "OrderDetails",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Tables_TableId",
                table: "Orders",
                column: "TableId",
                principalTable: "Tables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Orders_OrderId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Tables_TableId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Supplies",
                newName: "Product_IdId");

            migrationBuilder.RenameIndex(
                name: "IX_Supplies_ProductId",
                table: "Supplies",
                newName: "IX_Supplies_Product_IdId");

            migrationBuilder.RenameColumn(
                name: "TableId",
                table: "Orders",
                newName: "Table_IdId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_TableId",
                table: "Orders",
                newName: "IX_Orders_Table_IdId");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "OrderDetails",
                newName: "Product_IdId");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "OrderDetails",
                newName: "Order_IdId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                newName: "IX_OrderDetails_Product_IdId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                newName: "IX_OrderDetails_Order_IdId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Orders_Order_IdId",
                table: "OrderDetails",
                column: "Order_IdId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Tables_Table_IdId",
                table: "Orders",
                column: "Table_IdId",
                principalTable: "Tables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
