using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogIn.Migrations
{
    public partial class UpdateUserIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$W5yHiacRRVbKjuA5KUdWJO7fXnjONwEjHLkYsxCXV4VYEaxQazDf2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$G1IG5VKj5yjMcmnUI.Zvke8xozWcahFp1hRqOT.bc3bJlv1BJTSUi");
        }
    }
}
