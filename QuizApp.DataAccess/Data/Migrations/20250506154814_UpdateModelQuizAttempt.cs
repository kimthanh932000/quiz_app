using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizApp.DataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModelQuizAttempt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "QuizAttempts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "QuizAttempts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
