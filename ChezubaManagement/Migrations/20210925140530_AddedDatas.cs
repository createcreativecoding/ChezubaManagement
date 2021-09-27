using Microsoft.EntityFrameworkCore.Migrations;

namespace ChezubaManagement.Migrations
{
    public partial class AddedDatas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Address", "Duration", "Heading", "NGO_name", "Name", "Phone", "Site", "Time_com" },
                values: new object[] { 2, " Uttoroyan,F-Block", 1, "Graphic Designer", "Niswarth", " Sameer Lama", 456789123, "Online", 12 });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Address", "Duration", "Heading", "NGO_name", "Name", "Phone", "Site", "Time_com" },
                values: new object[] { 3, "Hakimpra", 3, "Translator", "Disha", " Tushar Singh", 789123456, "Online", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
