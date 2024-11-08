using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MigrationBundleDemo.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueUserNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: new Guid("73f61b4c-2141-4f90-b714-b1bfac2df0d7"));

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "People",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "FullName", "UserName" },
                values: new object[] { new Guid("094261e6-ee3a-48fb-9366-b00290e52678"), "Jason Todd", "jtodd" });

            migrationBuilder.CreateIndex(
                name: "IX_People_Id",
                table: "People",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_People_UserName",
                table: "People",
                column: "UserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_People_Id",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_UserName",
                table: "People");

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: new Guid("094261e6-ee3a-48fb-9366-b00290e52678"));

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "People");

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "FullName" },
                values: new object[] { new Guid("73f61b4c-2141-4f90-b714-b1bfac2df0d7"), "Jason Todd" });
        }
    }
}
