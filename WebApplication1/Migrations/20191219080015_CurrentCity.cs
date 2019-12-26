﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class CurrentCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "CurrentCity",
                table: "Employees");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CurrentCity",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Address", "CompanyName", "CurrentCity", "Designation", "MobileNo", "Name", "Salary" },
                values: new object[] { 1, "New York", "XYZ Inc", null, "Developer", 0, "John", 30000f });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Address", "CompanyName", "CurrentCity", "Designation", "MobileNo", "Name", "Salary" },
                values: new object[] { 2, "New York", "ABC Inc", null, "Manager", 0, "Chris", 50000f });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Address", "CompanyName", "CurrentCity", "Designation", "MobileNo", "Name", "Salary" },
                values: new object[] { 3, "New Delhi", "XYZ Inc", null, "Consultant", 0, "Mukesh", 20000f });
        }
    }
}
