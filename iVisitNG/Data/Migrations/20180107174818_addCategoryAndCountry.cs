using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace iVisitNG.Data.Migrations
{
    public partial class addCategoryAndCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Insert Categores
            migrationBuilder.Sql("INSERT INTO dbo.Category (Name) VALUES ('Contractor')");
            migrationBuilder.Sql("INSERT INTO dbo.Category (Name) VALUES ('Vendor')");
            migrationBuilder.Sql("INSERT INTO dbo.Category (Name) VALUES ('Visitor')");

            //Insert Country
            migrationBuilder.Sql("INSERT INTO dbo.Country (Name) VALUES ('Nigeria')");
            migrationBuilder.Sql("INSERT INTO dbo.Country (Name) VALUES ('Ghana')");
            migrationBuilder.Sql("INSERT INTO dbo.Country (Name) VALUES ('South Africa')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
