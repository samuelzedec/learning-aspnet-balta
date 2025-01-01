using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class AdjustInAuthorTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "PublicationYear",
                table: "Book",
                type: "SMALLINT",
                nullable: false,
                defaultValue: (short)2025,
                oldClrType: typeof(short),
                oldType: "SMALLINT",
                oldDefaultValue: (short)2024);

            migrationBuilder.AlterColumn<string>(
                name: "Biography",
                table: "Author",
                type: "NVARCHAR(MAX)",
                nullable: false,
                defaultValue: "## Não há registro informado sobre sua biografia ##",
                oldClrType: typeof(string),
                oldType: "NVARCHAR",
                oldDefaultValue: "## Não há registro informado sobre sua biografia ##");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "PublicationYear",
                table: "Book",
                type: "SMALLINT",
                nullable: false,
                defaultValue: (short)2024,
                oldClrType: typeof(short),
                oldType: "SMALLINT",
                oldDefaultValue: (short)2025);

            migrationBuilder.AlterColumn<string>(
                name: "Biography",
                table: "Author",
                type: "NVARCHAR",
                nullable: false,
                defaultValue: "## Não há registro informado sobre sua biografia ##",
                oldClrType: typeof(string),
                oldType: "NVARCHAR(MAX)",
                oldDefaultValue: "## Não há registro informado sobre sua biografia ##");
        }
    }
}
