using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicGate.DAL.Migrations
{
    public partial class CreateClinicGate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false),
                    PasNumber = table.Column<string>(nullable: true),
                    Forenames = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    SexCode = table.Column<int>(nullable: false),
                    HomeTelephoneNumber = table.Column<string>(nullable: true),
                    NokName = table.Column<string>(nullable: true),
                    NokRelationshipCode = table.Column<int>(nullable: false),
                    NokAddressLine1 = table.Column<string>(nullable: true),
                    NokAddressLine2 = table.Column<string>(nullable: true),
                    NokAddressLine3 = table.Column<string>(nullable: true),
                    NokPostcode = table.Column<string>(nullable: true),
                    GpCode = table.Column<string>(nullable: true),
                    GpSurname = table.Column<string>(nullable: true),
                    GpInitials = table.Column<string>(nullable: true),
                    GpPhone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
