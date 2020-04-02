using Microsoft.EntityFrameworkCore.Migrations;

namespace ArconApi.Data.Migrations
{
    public partial class RenameTableForActivity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GoalDetails_Activities_ActivityId",
                table: "GoalDetails");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.CreateTable(
                name: "GoalActivities",
                columns: table => new
                {
                    ActivityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoalActivities", x => x.ActivityId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_GoalDetails_GoalActivities_ActivityId",
                table: "GoalDetails",
                column: "ActivityId",
                principalTable: "GoalActivities",
                principalColumn: "ActivityId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GoalDetails_GoalActivities_ActivityId",
                table: "GoalDetails");

            migrationBuilder.DropTable(
                name: "GoalActivities");

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    ActivityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.ActivityId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_GoalDetails_Activities_ActivityId",
                table: "GoalDetails",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "ActivityId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
