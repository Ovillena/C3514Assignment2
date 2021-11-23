using Microsoft.EntityFrameworkCore.Migrations;

namespace SpeakerApi.Data.Migrations
{
    public partial class M1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Speakers",
                columns: table => new
                {
                    SpeakerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    City = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Province = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Employer = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speakers", x => x.SpeakerId);
                });

            migrationBuilder.InsertData(
                table: "Speakers",
                columns: new[] { "SpeakerId", "City", "Email", "Employer", "FirstName", "LastName", "MobileNumber", "Province", "Specialization" },
                values: new object[,]
                {
                    { "998ca356-5c0a-4d4e-ab53-08b1b71a639d", "Vancouver", "tday@amazon.com", "Amazon", "Tom", "Day", "604-111-1111", "BC", "AWS" },
                    { "1ed2051c-ecf6-4d66-9110-c33850d84754", "Calgary", "afox@microsoft.com", "Microsoft", "Ann", "Fox", "604-222-2222", "AB", "Dotnet" },
                    { "f4f5dc84-ea0c-470e-ab0a-c88a52fcb5d1", "Toronto", "aash@meta.com", "Meta", "Art", "Ash", "604-333-3333", "ON", "Oculus" },
                    { "8becc722-96fc-4b9b-aaa9-b5d22b045fea", "Montreal", "mhay@yahoo.com", "Yahoo", "Mia", "Hay", "604-444-4444", "QB", "Yahoo Search" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Speakers");
        }
    }
}
