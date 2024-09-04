using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Coordinator.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Nodes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("45b95664-de8c-42d6-b938-da0aedb52b62"), "Order.API" },
                    { new Guid("6abe0b27-0bea-4c60-b887-9f89b0db4569"), "Stock.API" },
                    { new Guid("7bdc030c-595a-4287-b9f2-233ba09698e5"), "Payment.API" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: new Guid("45b95664-de8c-42d6-b938-da0aedb52b62"));

            migrationBuilder.DeleteData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: new Guid("6abe0b27-0bea-4c60-b887-9f89b0db4569"));

            migrationBuilder.DeleteData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: new Guid("7bdc030c-595a-4287-b9f2-233ba09698e5"));
        }
    }
}
