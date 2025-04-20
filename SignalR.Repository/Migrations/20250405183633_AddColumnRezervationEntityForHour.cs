using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalR.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnRezervationEntityForHour : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Hour",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hour",
                table: "Bookings");
        }
    }
}
