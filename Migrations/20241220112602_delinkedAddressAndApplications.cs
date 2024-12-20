using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Software_Foundations_Learning_Programme_.Migrations
{
    /// <inheritdoc />
    public partial class delinkedAddressAndApplications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Addresses_AddressId",
                table: "Applications");

            migrationBuilder.DropIndex(
                name: "IX_Applications_AddressId",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "AddressId",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Applications",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Applications_AddressId",
                table: "Applications",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Addresses_AddressId",
                table: "Applications",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
