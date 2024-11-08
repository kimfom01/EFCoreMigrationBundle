using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MigrationBundleDemo.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedPersonData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "FullName" },
                values: new object[] { new Guid("73f61b4c-2141-4f90-b714-b1bfac2df0d7"), "Jason Todd" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: new Guid("73f61b4c-2141-4f90-b714-b1bfac2df0d7"));
        }
    }
}
