using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArconApi.Data.Migrations
{
    public partial class addedImagePropertyForGoal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Goals",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Goals");
        }
    }
}
