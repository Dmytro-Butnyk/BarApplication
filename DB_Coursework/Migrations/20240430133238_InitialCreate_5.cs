using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB_Coursework.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate_5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "SupplyTime",
                table: "Supplies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SupplyTime",
                table: "Supplies");
        }
    }
}
