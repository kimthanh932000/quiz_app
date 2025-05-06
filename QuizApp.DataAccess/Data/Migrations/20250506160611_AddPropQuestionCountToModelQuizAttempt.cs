using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizApp.DataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPropQuestionCountToModelQuizAttempt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuestionCount",
                table: "QuizAttempts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionCount",
                table: "QuizAttempts");
        }
    }
}
