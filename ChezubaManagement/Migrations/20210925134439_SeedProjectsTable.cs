using Microsoft.EntityFrameworkCore.Migrations;

namespace ChezubaManagement.Migrations
{
    public partial class SeedProjectsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Address", "Duration", "Heading", "NGO_name", "Name", "Phone", "Site", "Time_com" },
                values: new object[] { 1, " Kharag Singh Road", 2, "Advocate", "Waasta", " Rajesh Verma", 123456789, "Onsite", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
