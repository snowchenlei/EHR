using Microsoft.EntityFrameworkCore.Migrations;

namespace Snow.Hcm.Migrations
{
    public partial class EmployeeAddCalendar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BirthDay",
                table: "HcmEmployee",
                newName: "Birthday");

            migrationBuilder.AddColumn<bool>(
                name: "IsGregorianCalendar",
                table: "HcmEmployee",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsGregorianCalendar",
                table: "HcmEmployee");

            migrationBuilder.RenameColumn(
                name: "Birthday",
                table: "HcmEmployee",
                newName: "BirthDay");
        }
    }
}
