using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bArtTest.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Incidents_Incidentname",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Accounts_Accountid",
                table: "Contacts");

            migrationBuilder.AlterColumn<int>(
                name: "Accountid",
                table: "Contacts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Incidentname",
                table: "Accounts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Incidents_Incidentname",
                table: "Accounts",
                column: "Incidentname",
                principalTable: "Incidents",
                principalColumn: "name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Accounts_Accountid",
                table: "Contacts",
                column: "Accountid",
                principalTable: "Accounts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Incidents_Incidentname",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Accounts_Accountid",
                table: "Contacts");

            migrationBuilder.AlterColumn<int>(
                name: "Accountid",
                table: "Contacts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Incidentname",
                table: "Accounts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Incidents_Incidentname",
                table: "Accounts",
                column: "Incidentname",
                principalTable: "Incidents",
                principalColumn: "name");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Accounts_Accountid",
                table: "Contacts",
                column: "Accountid",
                principalTable: "Accounts",
                principalColumn: "id");
        }
    }
}
