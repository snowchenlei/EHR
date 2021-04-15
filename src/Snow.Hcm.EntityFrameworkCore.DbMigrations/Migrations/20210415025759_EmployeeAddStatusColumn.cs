using Microsoft.EntityFrameworkCore.Migrations;

namespace Snow.Hcm.Migrations
{
    public partial class EmployeeAddStatusColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BankCardNumber",
                table: "HcmEmployee",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaritalStatus",
                table: "HcmEmployee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PoliticalStatus",
                table: "HcmEmployee",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BankCardNumber",
                table: "HcmEmployee");

            migrationBuilder.DropColumn(
                name: "MaritalStatus",
                table: "HcmEmployee");

            migrationBuilder.DropColumn(
                name: "PoliticalStatus",
                table: "HcmEmployee");
        }
    }
}
