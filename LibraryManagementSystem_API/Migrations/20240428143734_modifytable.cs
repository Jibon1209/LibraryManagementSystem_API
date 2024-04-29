using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagementSystem_API.Migrations
{
    /// <inheritdoc />
    public partial class modifytable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "BorrowedBooks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Borrowed",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddCheckConstraint(
                name: "CK_BorrowedBook_Status",
                table: "BorrowedBooks",
                sql: "[Status] IN ('Borrowed', 'Returned', 'Overdue')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_BorrowedBook_Status",
                table: "BorrowedBooks");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "BorrowedBooks",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "Borrowed");
        }
    }
}
