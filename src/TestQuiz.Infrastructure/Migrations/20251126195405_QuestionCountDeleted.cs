using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestQuiz.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class QuestionCountDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionsCount",
                table: "Tests");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuestionsCount",
                table: "Tests",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
