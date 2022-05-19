using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Snow.Ehr.Migrations
{
    public partial class EmployeeAddStreetId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AreaId",
                table: "AppEmployee");

            migrationBuilder.DropColumn(
                name: "ProvinceId",
                table: "AppEmployee");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "AppEmployee");

            migrationBuilder.AddColumn<Guid>(
                name: "ProvinceId",
                table: "AppEmployee",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CityId",
                table: "AppEmployee",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
            
            migrationBuilder.AddColumn<Guid>(
                name: "DistrictId",
                table: "AppEmployee",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "StreetId",
                table: "AppEmployee",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProvinceId",
                table: "AppEmployee");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "AppEmployee");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "AppEmployee");

            migrationBuilder.DropColumn(
                name: "StreetId",
                table: "AppEmployee");

            migrationBuilder.DropColumn(
                name: "AreaId",
                table: "AppEmployee");


            migrationBuilder.AddColumn<Guid>(
                name: "ProvinceId",
                table: "AppEmployee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "CityId",
                table: "AppEmployee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AreaId",
                table: "AppEmployee",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
