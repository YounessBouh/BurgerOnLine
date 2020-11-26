using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineBurgerApp.Data.Migrations
{
    public partial class productIdMax2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CustomerEmail",
                table: "Orders",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CustomerEmail",
                table: "Orders",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 40);
        }
    }
}
