using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArconApi.Data.Migrations
{
    public partial class AddedNewEntitiesForGoals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    ActivityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.ActivityId);
                });

            migrationBuilder.CreateTable(
                name: "Goal",
                columns: table => new
                {
                    GoalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PerfilId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(9, 2)", nullable: false),
                    Progress = table.Column<decimal>(type: "decimal(9, 2)", nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    CompleteDate = table.Column<DateTime>(nullable: false),
                    TransferDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goal", x => x.GoalId);
                    table.ForeignKey(
                        name: "FK_Goal_UserProfiles_PerfilId",
                        column: x => x.PerfilId,
                        principalTable: "UserProfiles",
                        principalColumn: "UserProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Goal_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GoalDetail",
                columns: table => new
                {
                    GoalDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GoalId = table.Column<int>(nullable: false),
                    ActivityId = table.Column<int>(nullable: false),
                    IsComplete = table.Column<bool>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoalDetail", x => x.GoalDetailId);
                    table.ForeignKey(
                        name: "FK_GoalDetail_Activity_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activity",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GoalDetail_Goal_GoalId",
                        column: x => x.GoalId,
                        principalTable: "Goal",
                        principalColumn: "GoalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Goal_PerfilId",
                table: "Goal",
                column: "PerfilId");

            migrationBuilder.CreateIndex(
                name: "IX_Goal_StatusId",
                table: "Goal",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_GoalDetail_ActivityId",
                table: "GoalDetail",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_GoalDetail_GoalId",
                table: "GoalDetail",
                column: "GoalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GoalDetail");

            migrationBuilder.DropTable(
                name: "Activity");

            migrationBuilder.DropTable(
                name: "Goal");
        }
    }
}
