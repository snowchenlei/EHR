using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Snow.Hcm.Migrations
{
    public partial class AddPosition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HcmEmployee_HcmDepartment_DepartmentId",
                table: "HcmEmployee");

            migrationBuilder.DropIndex(
                name: "IX_HcmEmployee_DepartmentId",
                table: "HcmEmployee");

            migrationBuilder.CreateTable(
                name: "HcmPosition",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HcmPosition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HcmPosition_HcmDepartment_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "HcmDepartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HcmEmployee_PositionId",
                table: "HcmEmployee",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_HcmPosition_DepartmentId",
                table: "HcmPosition",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_HcmEmployee_HcmPosition_PositionId",
                table: "HcmEmployee",
                column: "PositionId",
                principalTable: "HcmPosition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HcmEmployee_HcmPosition_PositionId",
                table: "HcmEmployee");

            migrationBuilder.DropTable(
                name: "HcmPosition");

            migrationBuilder.DropIndex(
                name: "IX_HcmEmployee_PositionId",
                table: "HcmEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_HcmEmployee_DepartmentId",
                table: "HcmEmployee",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_HcmEmployee_HcmDepartment_DepartmentId",
                table: "HcmEmployee",
                column: "DepartmentId",
                principalTable: "HcmDepartment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
