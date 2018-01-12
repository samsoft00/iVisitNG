using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace iVisitNG.Data.Migrations
{
    public partial class UpdateAppointmentDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentDate_DaysOfWeek_DayOfWeekId",
                table: "AppointmentDate");

            migrationBuilder.DropIndex(
                name: "IX_AppointmentDate_DayOfWeekId",
                table: "AppointmentDate");

            migrationBuilder.DropColumn(
                name: "DayOfWeekId",
                table: "AppointmentDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DayOfWeekId",
                table: "AppointmentDate",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentDate_DayOfWeekId",
                table: "AppointmentDate",
                column: "DayOfWeekId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentDate_DaysOfWeek_DayOfWeekId",
                table: "AppointmentDate",
                column: "DayOfWeekId",
                principalTable: "DaysOfWeek",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
