using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB_Coursework.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate_7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE TRIGGER UpdateProductQuantityOnSupply
ON Supplies
AFTER INSERT
AS
BEGIN
    UPDATE Products
    SET Products.Quantity = Products.Quantity + inserted.Quantity
    FROM inserted
    WHERE inserted.ProductId = Products.Id;
END;
        ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP TRIGGER UpdateProductQuantityOnSupply");
        }
    }
}
