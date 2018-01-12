using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace iVisitNG.Data.Migrations
{
    public partial class UpdateDbContextBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleClaim_AspNetRoles_RoleId",
                table: "RoleClaim");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffClaim_Staffs_UserId",
                table: "StaffClaim");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffLogin_Staffs_UserId",
                table: "StaffLogin");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffProfile_Staffs_StaffId",
                table: "StaffProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffRole_AspNetRoles_RoleId",
                table: "StaffRole");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffRole_Staffs_UserId",
                table: "StaffRole");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffToken_Staffs_UserId",
                table: "StaffToken");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Staffs",
                table: "Staffs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetRoles");

            migrationBuilder.RenameTable(
                name: "Staffs",
                newName: "Staff");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "Role");

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedName",
                table: "Role",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Role",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Staff",
                table: "Staff",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleClaim_AspNetRoles_RoleId",
                table: "RoleClaim",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffClaim_Staff_UserId",
                table: "StaffClaim",
                column: "UserId",
                principalTable: "Staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffLogin_Staff_UserId",
                table: "StaffLogin",
                column: "UserId",
                principalTable: "Staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffProfile_Staff_StaffId",
                table: "StaffProfile",
                column: "StaffId",
                principalTable: "Staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffRole_AspNetRoles_RoleId",
                table: "StaffRole",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffRole_Staff_UserId",
                table: "StaffRole",
                column: "UserId",
                principalTable: "Staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffToken_Staff_UserId",
                table: "StaffToken",
                column: "UserId",
                principalTable: "Staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleClaim_AspNetRoles_RoleId",
                table: "RoleClaim");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffClaim_Staff_UserId",
                table: "StaffClaim");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffLogin_Staff_UserId",
                table: "StaffLogin");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffProfile_Staff_StaffId",
                table: "StaffProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffRole_AspNetRoles_RoleId",
                table: "StaffRole");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffRole_Staff_UserId",
                table: "StaffRole");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffToken_Staff_UserId",
                table: "StaffToken");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Staff",
                table: "Staff");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.RenameTable(
                name: "Staff",
                newName: "Staffs");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "AspNetRoles");

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedName",
                table: "AspNetRoles",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetRoles",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetRoles",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Staffs",
                table: "Staffs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleClaim_AspNetRoles_RoleId",
                table: "RoleClaim",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffClaim_Staffs_UserId",
                table: "StaffClaim",
                column: "UserId",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffLogin_Staffs_UserId",
                table: "StaffLogin",
                column: "UserId",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffProfile_Staffs_StaffId",
                table: "StaffProfile",
                column: "StaffId",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffRole_AspNetRoles_RoleId",
                table: "StaffRole",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffRole_Staffs_UserId",
                table: "StaffRole",
                column: "UserId",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffToken_Staffs_UserId",
                table: "StaffToken",
                column: "UserId",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
