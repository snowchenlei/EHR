using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Snow.Hcm.Migrations
{
    public partial class AddSalary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HcmDepartment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HcmDepartment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HcmSalary",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BasicAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SocialInsuranceProportion = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsCurrent = table.Column<bool>(type: "bit", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HcmSalary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HcmSalary_HcmEmployee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "HcmEmployee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HcmEmployee_DepartmentId",
                table: "HcmEmployee",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_HcmSalary_EmployeeId",
                table: "HcmSalary",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_HcmEmployee_HcmDepartment_DepartmentId",
                table: "HcmEmployee",
                column: "DepartmentId",
                principalTable: "HcmDepartment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HcmEmployee_HcmDepartment_DepartmentId",
                table: "HcmEmployee");

            migrationBuilder.DropTable(
                name: "HcmDepartment");

            migrationBuilder.DropTable(
                name: "HcmSalary");

            migrationBuilder.DropIndex(
                name: "IX_HcmEmployee_DepartmentId",
                table: "HcmEmployee");
        }
    }
}
