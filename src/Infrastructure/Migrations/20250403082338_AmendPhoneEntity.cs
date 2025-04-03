using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unknown1.Dal.Migrations
{
    /// <inheritdoc />
    public partial class AmendPhoneEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Phone_PhoneId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_PhoneId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PhoneId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Phone",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Phone_UserId",
                table: "Phone",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Phone_Users_UserId",
                table: "Phone",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phone_Users_UserId",
                table: "Phone");

            migrationBuilder.DropIndex(
                name: "IX_Phone_UserId",
                table: "Phone");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Phone");

            migrationBuilder.AddColumn<int>(
                name: "PhoneId",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_PhoneId",
                table: "Users",
                column: "PhoneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Phone_PhoneId",
                table: "Users",
                column: "PhoneId",
                principalTable: "Phone",
                principalColumn: "PhoneId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
