using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HazarHospital.Migrations
{
    public partial class adjusted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoctorComment",
                table: "Appointments");

            migrationBuilder.AddColumn<string>(
                name: "AppointmentConfirmationNumber",
                table: "Appointments",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppointmentConfirmationNumber",
                table: "Appointments");

            migrationBuilder.AddColumn<string>(
                name: "DoctorComment",
                table: "Appointments",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
