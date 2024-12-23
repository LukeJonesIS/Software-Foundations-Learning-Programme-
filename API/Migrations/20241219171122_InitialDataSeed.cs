using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Software_Foundations_Learning_Programme_.Migrations
{
    /// <inheritdoc />
    public partial class InitialDataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "Address_line1", "Address_line2", "City", "Postcode" },
                values: new object[,]
                {
                    { 1, "2 Dummy Lane", "Fake Town", "London", "FA12_6KE" },
                    { 2, "4 Dummy Lane", "Fake Town", "London", "FA12_6KE" },
                    { 3, "3 Fake Street", "Dummy Town", "Manchester", "NO7_4RL" }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Vrn", "Fuel_type", "Make", "Model", "Year_made" },
                values: new object[,]
                {
                    { "CAS300", "petrol", "Volkswagon", "Fox", 2008 },
                    { "EVS400", "electric", "Tesla", "Series S", 2018 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Vrn",
                keyValue: "CAS300");

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Vrn",
                keyValue: "EVS400");
        }
    }
}
