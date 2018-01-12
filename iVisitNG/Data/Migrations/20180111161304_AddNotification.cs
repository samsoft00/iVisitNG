using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace iVisitNG.Data.Migrations
{
    public partial class AddNotification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StaffProfile_Division_DivisionId",
                table: "StaffProfile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Division",
                table: "Division");

            migrationBuilder.RenameTable(
                name: "Division",
                newName: "Divisions");

            migrationBuilder.AlterColumn<string>(
                name: "DivisionName",
                table: "Divisions",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Divisions",
                table: "Divisions",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    Message = table.Column<string>(nullable: false),
                    PostedById = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notification_Staff_PostedById",
                        column: x => x.PostedById,
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notification_PostedById",
                table: "Notification",
                column: "PostedById");

            migrationBuilder.AddForeignKey(
                name: "FK_StaffProfile_Divisions_DivisionId",
                table: "StaffProfile",
                column: "DivisionId",
                principalTable: "Divisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StaffProfile_Divisions_DivisionId",
                table: "StaffProfile");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Divisions",
                table: "Divisions");

            migrationBuilder.RenameTable(
                name: "Divisions",
                newName: "Division");

            migrationBuilder.AlterColumn<string>(
                name: "DivisionName",
                table: "Division",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Division",
                table: "Division",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StaffProfile_Division_DivisionId",
                table: "StaffProfile",
                column: "DivisionId",
                principalTable: "Division",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
