using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace iVisitNG.Data.Migrations
{
    public partial class PurposeOfVisitId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_PurposeOfVisit_PurposeId",
                table: "Appointment");

            migrationBuilder.RenameColumn(
                name: "PurposeId",
                table: "Appointment",
                newName: "PurposeOfVisitId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointment_PurposeId",
                table: "Appointment",
                newName: "IX_Appointment_PurposeOfVisitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_PurposeOfVisit_PurposeOfVisitId",
                table: "Appointment",
                column: "PurposeOfVisitId",
                principalTable: "PurposeOfVisit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_PurposeOfVisit_PurposeOfVisitId",
                table: "Appointment");

            migrationBuilder.RenameColumn(
                name: "PurposeOfVisitId",
                table: "Appointment",
                newName: "PurposeId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointment_PurposeOfVisitId",
                table: "Appointment",
                newName: "IX_Appointment_PurposeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_PurposeOfVisit_PurposeId",
                table: "Appointment",
                column: "PurposeId",
                principalTable: "PurposeOfVisit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
