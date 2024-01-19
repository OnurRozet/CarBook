using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBook.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class migfixedCarEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarDescriptions_CarDescriptionId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CarDescriptionId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CarDescriptionId",
                table: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "CarDescriptions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarDescriptions_CarId",
                table: "CarDescriptions",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarDescriptions_Cars_CarId",
                table: "CarDescriptions",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarDescriptions_Cars_CarId",
                table: "CarDescriptions");

            migrationBuilder.DropIndex(
                name: "IX_CarDescriptions_CarId",
                table: "CarDescriptions");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "CarDescriptions");

            migrationBuilder.AddColumn<int>(
                name: "CarDescriptionId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarDescriptionId",
                table: "Cars",
                column: "CarDescriptionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarDescriptions_CarDescriptionId",
                table: "Cars",
                column: "CarDescriptionId",
                principalTable: "CarDescriptions",
                principalColumn: "CarDescriptionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
