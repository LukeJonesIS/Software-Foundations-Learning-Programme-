using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Software_Foundations_Learning_Programme_.Migrations
{
    /// <inheritdoc />
    public partial class eligibilityTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EligibleAddress",
                columns: table => new
                {
                    Postcode = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EligibleAddress", x => x.Postcode);
                });

            migrationBuilder.CreateTable(
                name: "EligibleFuel",
                columns: table => new
                {
                    Fuel_type = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EligibleFuel", x => x.Fuel_type);
                });

            migrationBuilder.InsertData(
                table: "EligibleAddress",
                column: "Postcode",
                value: "NO7_4RL");

            migrationBuilder.InsertData(
                table: "EligibleFuel",
                column: "Fuel_type",
                value: "electric");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EligibleAddress");

            migrationBuilder.DropTable(
                name: "EligibleFuel");
        }
    }
}
