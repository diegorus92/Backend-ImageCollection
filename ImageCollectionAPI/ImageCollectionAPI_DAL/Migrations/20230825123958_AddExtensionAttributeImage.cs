using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImageCollectionAPI_DAL.Migrations
{
    public partial class AddExtensionAttributeImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Extension",
                table: "Images",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Extension",
                table: "Images");
        }
    }
}
