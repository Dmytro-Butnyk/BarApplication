using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB_Coursework.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate_10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE TRIGGER tr_UpdateProductQuantity
            ON OrderDetails
            AFTER INSERT
            AS
            BEGIN
                DECLARE @quantity INT
                DECLARE @productId INT
                SELECT @quantity = Quantity, @productId = ProductId FROM inserted

                IF EXISTS (SELECT 1 FROM Products WHERE Id = @productId AND Quantity >= @quantity)
                BEGIN
                    UPDATE Products
                    SET Quantity = Quantity - @quantity
                    WHERE Id = @productId
                END
                ELSE
                BEGIN
                    ROLLBACK TRANSACTION
                    RAISERROR ('Not enough quantity in stock', 16, 1)
                END
            END
        ");

            migrationBuilder.Sql(@"
            CREATE TRIGGER tr_UpdateProductQuantityOnDelete
            ON OrderDetails
            FOR DELETE
            AS
            BEGIN
                DECLARE @quantity INT
                DECLARE @productId INT
                SELECT @quantity = Quantity, @productId = ProductId FROM deleted

                UPDATE Products
                SET Quantity = Quantity + @quantity
                WHERE Id = @productId
            END
        ");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER tr_UpdateProductQuantity");
            migrationBuilder.Sql("DROP TRIGGER tr_UpdateProductQuantityOnDelete");
        }
    }
}
