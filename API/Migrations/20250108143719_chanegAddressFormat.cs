using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Software_Foundations_Learning_Programme_.Migrations
{
    /// <inheritdoc />
    public partial class chanegAddressFormat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address_line1",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "Address_line2",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "Postcode",
                table: "Applications");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Applications",
                type: "TEXT",
                maxLength: 150,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Applications");

            migrationBuilder.AddColumn<string>(
                name: "Address_line1",
                table: "Applications",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_line2",
                table: "Applications",
                type: "TEXT",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Applications",
                type: "TEXT",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Postcode",
                table: "Applications",
                type: "TEXT",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }
    }
}
