using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodTeams.Migrations
{
    public partial class _1stMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "MinPrice",
                table: "Orders",
                type: "decimal(25,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "FreeDeliveryPrice",
                table: "Orders",
                type: "decimal(25,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "DeliveryPrice",
                table: "Orders",
                type: "decimal(25,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Dishes",
                type: "decimal(25,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "MinPrice",
                table: "Orders",
                type: "decimal(5,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(25,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "FreeDeliveryPrice",
                table: "Orders",
                type: "decimal(5,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(25,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "DeliveryPrice",
                table: "Orders",
                type: "decimal(5,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(25,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Dishes",
                type: "decimal(5,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(25,2)");
        }
    }
}
