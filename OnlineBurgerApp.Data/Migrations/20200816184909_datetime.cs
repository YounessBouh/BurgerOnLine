using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineBurgerApp.Data.Migrations
{
    public partial class datetime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OrderDate",
                table: "Orders",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldMaxLength: 20);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);
        }
    }
}
