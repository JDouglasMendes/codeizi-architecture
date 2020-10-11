using Microsoft.EntityFrameworkCore.Migrations;

namespace Codeizi.Infra.Data.Migrations
{
    public partial class AddIndexForCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "Customer",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Number_CreationDate",
                table: "Customer",
                columns: new[] { "Number", "CreationDate" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customer_Number_CreationDate",
                table: "Customer");

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30,
                oldNullable: true);
        }
    }
}
