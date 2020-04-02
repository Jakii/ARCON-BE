using Microsoft.EntityFrameworkCore.Migrations;

namespace ArconApi.Data.Migrations
{
    public partial class UpdatedNamePropertyGoal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goal_UserProfiles_PerfilId",
                table: "Goal");

            migrationBuilder.DropForeignKey(
                name: "FK_Goal_Statuses_StatusId",
                table: "Goal");

            migrationBuilder.DropForeignKey(
                name: "FK_GoalDetail_Activity_ActivityId",
                table: "GoalDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_GoalDetail_Goal_GoalId",
                table: "GoalDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GoalDetail",
                table: "GoalDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Goal",
                table: "Goal");

            migrationBuilder.DropIndex(
                name: "IX_Goal_PerfilId",
                table: "Goal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Activity",
                table: "Activity");

            migrationBuilder.DropColumn(
                name: "PerfilId",
                table: "Goal");

            migrationBuilder.RenameTable(
                name: "GoalDetail",
                newName: "GoalDetails");

            migrationBuilder.RenameTable(
                name: "Goal",
                newName: "Goals");

            migrationBuilder.RenameTable(
                name: "Activity",
                newName: "Activities");

            migrationBuilder.RenameIndex(
                name: "IX_GoalDetail_GoalId",
                table: "GoalDetails",
                newName: "IX_GoalDetails_GoalId");

            migrationBuilder.RenameIndex(
                name: "IX_GoalDetail_ActivityId",
                table: "GoalDetails",
                newName: "IX_GoalDetails_ActivityId");

            migrationBuilder.RenameIndex(
                name: "IX_Goal_StatusId",
                table: "Goals",
                newName: "IX_Goals_StatusId");
           

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "Goals",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GoalDetails",
                table: "GoalDetails",
                column: "GoalDetailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Goals",
                table: "Goals",
                column: "GoalId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Activities",
                table: "Activities",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Goals_ProfileId",
                table: "Goals",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_GoalDetails_Activities_ActivityId",
                table: "GoalDetails",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "ActivityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GoalDetails_Goals_GoalId",
                table: "GoalDetails",
                column: "GoalId",
                principalTable: "Goals",
                principalColumn: "GoalId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_UserProfiles_ProfileId",
                table: "Goals",
                column: "ProfileId",
                principalTable: "UserProfiles",
                principalColumn: "UserProfileId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_Statuses_StatusId",
                table: "Goals",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GoalDetails_Activities_ActivityId",
                table: "GoalDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_GoalDetails_Goals_GoalId",
                table: "GoalDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Goals_UserProfiles_ProfileId",
                table: "Goals");

            migrationBuilder.DropForeignKey(
                name: "FK_Goals_Statuses_StatusId",
                table: "Goals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Goals",
                table: "Goals");

            migrationBuilder.DropIndex(
                name: "IX_Goals_ProfileId",
                table: "Goals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GoalDetails",
                table: "GoalDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Activities",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Goals");

            migrationBuilder.RenameTable(
                name: "Goals",
                newName: "Goal");

            migrationBuilder.RenameTable(
                name: "GoalDetails",
                newName: "GoalDetail");

            migrationBuilder.RenameTable(
                name: "Activities",
                newName: "Activity");

            migrationBuilder.RenameIndex(
                name: "IX_Goals_StatusId",
                table: "Goal",
                newName: "IX_Goal_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_GoalDetails_GoalId",
                table: "GoalDetail",
                newName: "IX_GoalDetail_GoalId");

            migrationBuilder.RenameIndex(
                name: "IX_GoalDetails_ActivityId",
                table: "GoalDetail",
                newName: "IX_GoalDetail_ActivityId");
        

            migrationBuilder.AddColumn<int>(
                name: "PerfilId",
                table: "Goal",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Goal",
                table: "Goal",
                column: "GoalId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GoalDetail",
                table: "GoalDetail",
                column: "GoalDetailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Activity",
                table: "Activity",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Goal_PerfilId",
                table: "Goal",
                column: "PerfilId");

            migrationBuilder.AddForeignKey(
                name: "FK_Goal_UserProfiles_PerfilId",
                table: "Goal",
                column: "PerfilId",
                principalTable: "UserProfiles",
                principalColumn: "UserProfileId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Goal_Statuses_StatusId",
                table: "Goal",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GoalDetail_Activity_ActivityId",
                table: "GoalDetail",
                column: "ActivityId",
                principalTable: "Activity",
                principalColumn: "ActivityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GoalDetail_Goal_GoalId",
                table: "GoalDetail",
                column: "GoalId",
                principalTable: "Goal",
                principalColumn: "GoalId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
