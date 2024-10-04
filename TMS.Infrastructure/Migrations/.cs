using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AssignTrainerandTraineeToTrainingFeild : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Trainers_TrainerId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainees_Courses_CourseId",
                table: "Trainees");

            migrationBuilder.DropIndex(
                name: "IX_Trainees_CourseId",
                table: "Trainees");

            migrationBuilder.DropIndex(
                name: "IX_Courses_TrainerId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Trainees");

            migrationBuilder.DropColumn(
                name: "TrainerId",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Courses",
                newName: "ResoursesUrl");

            migrationBuilder.AddColumn<int>(
                name: "TrainingFieldId",
                table: "Trainers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Trainers_TrainingFieldId",
                table: "Trainers",
                column: "TrainingFieldId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainers_TrainingFields_TrainingFieldId",
                table: "Trainers",
                column: "TrainingFieldId",
                principalTable: "TrainingFields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainers_TrainingFields_TrainingFieldId",
                table: "Trainers");

            migrationBuilder.DropIndex(
                name: "IX_Trainers_TrainingFieldId",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "TrainingFieldId",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "ResoursesUrl",
                table: "Courses",
                newName: "Title");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Trainees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrainerId",
                table: "Courses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Trainees_CourseId",
                table: "Trainees",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TrainerId",
                table: "Courses",
                column: "TrainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Trainers_TrainerId",
                table: "Courses",
                column: "TrainerId",
                principalTable: "Trainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainees_Courses_CourseId",
                table: "Trainees",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");
        }
    }
}
