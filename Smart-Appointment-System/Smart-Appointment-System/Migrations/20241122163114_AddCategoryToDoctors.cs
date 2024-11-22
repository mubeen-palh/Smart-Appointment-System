using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Smart_Appointment_System.Migrations
{
    public partial class AddCategoryToDoctors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Add the Category column to the existing Doctors table
            //migrationBuilder.AddColumn<string>(
            //    name: "Category",
            //    table: "Doctors",
            //    type: "character varying(255)",
            //    nullable: false,
            //    defaultValue: "General"); // You can adjust the default value or make it nullable as needed.
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove the Category column if rolling back the migration
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Doctors");
        }
    }
}
