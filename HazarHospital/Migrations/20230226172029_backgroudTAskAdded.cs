using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HazarHospital.Migrations
{
    public partial class backgroudTAskAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "appointmentReminderId",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "appointmentReminderId",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "appointmentReminderId",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "appointmentReminderId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "appointmentReminderId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "appointmentReminderId",
                table: "Appointments");
        }
    }
}
