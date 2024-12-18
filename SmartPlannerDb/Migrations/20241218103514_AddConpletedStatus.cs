using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartPlannerDb.Migrations
{
    /// <inheritdoc />
    public partial class AddConpletedStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSucessisCompleted",
                table: "Notes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSucessisCompleted",
                table: "Notes");
        }
    }
}
