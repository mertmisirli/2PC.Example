﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Coordinator.Migrations
{
    /// <inheritdoc />
    public partial class mig_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NodeStates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TransactionId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsReady = table.Column<int>(type: "integer", nullable: false),
                    TransactionState = table.Column<int>(type: "integer", nullable: false),
                    NodeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NodeStates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NodeStates_Nodes_NodeId",
                        column: x => x.NodeId,
                        principalTable: "Nodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NodeStates_NodeId",
                table: "NodeStates",
                column: "NodeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NodeStates");

            migrationBuilder.DropTable(
                name: "Nodes");
        }
    }
}
