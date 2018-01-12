using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace iVisitNG.Data.Migrations
{
    public partial class AddPurposeToVisit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ApprovedStatus",
                table: "Appointment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Appointment",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "FloorNumber",
                table: "Appointment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstructionToSecurity",
                table: "Appointment",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsGroupVisit",
                table: "Appointment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PurposeId",
                table: "Appointment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "Appointment",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "PurposeOfVisit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    purpose = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurposeOfVisit", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_PurposeId",
                table: "Appointment",
                column: "PurposeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_PurposeOfVisit_PurposeId",
                table: "Appointment",
                column: "PurposeId",
                principalTable: "PurposeOfVisit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_PurposeOfVisit_PurposeId",
                table: "Appointment");

            migrationBuilder.DropTable(
                name: "PurposeOfVisit");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_PurposeId",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "ApprovedStatus",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "FloorNumber",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "InstructionToSecurity",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "IsGroupVisit",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "PurposeId",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "Appointment");
        }
    }
}
