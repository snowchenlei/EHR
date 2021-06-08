using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Snow.Hcm.Migrations
{
    public partial class EmployeeAddStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BloodType",
                table: "HcmEmployee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Constellation",
                table: "HcmEmployee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InServiceStatus",
                table: "HcmEmployee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeOfDimission",
                table: "HcmEmployee",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Zodiac",
                table: "HcmEmployee",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BloodType",
                table: "HcmEmployee");

            migrationBuilder.DropColumn(
                name: "Constellation",
                table: "HcmEmployee");

            migrationBuilder.DropColumn(
                name: "InServiceStatus",
                table: "HcmEmployee");

            migrationBuilder.DropColumn(
                name: "TimeOfDimission",
                table: "HcmEmployee");

            migrationBuilder.DropColumn(
                name: "Zodiac",
                table: "HcmEmployee");
        }
    }
}
