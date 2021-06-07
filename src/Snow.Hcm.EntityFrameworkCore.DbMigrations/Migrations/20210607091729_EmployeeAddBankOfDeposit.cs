using Microsoft.EntityFrameworkCore.Migrations;

namespace Snow.Hcm.Migrations
{
    public partial class EmployeeAddBankOfDeposit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BankOfDeposit",
                table: "HcmEmployee",
                type: "nvarchar(125)",
                maxLength: 125,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BankOfDeposit",
                table: "HcmEmployee");
        }
    }
}
