using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRelationShips : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TrainerId",
                table: "Trainees",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Trainees_TrainerId",
                table: "Trainees",
                column: "TrainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainees_Trainers_TrainerId",
                table: "Trainees",
                column: "TrainerId",
                principalTable: "Trainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainees_Trainers_TrainerId",
                table: "Trainees");

            migrationBuilder.DropIndex(
                name: "IX_Trainees_TrainerId",
                table: "Trainees");

            migrationBuilder.DropColumn(
                name: "TrainerId",
                table: "Trainees");
        }
    }
}
