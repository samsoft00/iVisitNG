using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace iVisitNG.Data.Migrations
{
    public partial class AddDivisionIdToProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DivisionId",
                table: "StaffProfile",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StaffProfile_DivisionId",
                table: "StaffProfile",
                column: "DivisionId");

            migrationBuilder.AddForeignKey(
                name: "FK_StaffProfile_Division_DivisionId",
                table: "StaffProfile",
                column: "DivisionId",
                principalTable: "Division",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StaffProfile_Division_DivisionId",
                table: "StaffProfile");

            migrationBuilder.DropIndex(
                name: "IX_StaffProfile_DivisionId",
                table: "StaffProfile");

            migrationBuilder.DropColumn(
                name: "DivisionId",
                table: "StaffProfile");
        }
    }
}
