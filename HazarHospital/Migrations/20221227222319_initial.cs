using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HazarHospital.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Admins_AdminId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Admins_AdminId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_AdminId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_AdminId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Doctors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_AdminId",
                table: "Patients",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_AdminId",
                table: "Doctors",
                column: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Admins_AdminId",
                table: "Doctors",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Admins_AdminId",
                table: "Patients",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
