using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManager.Identity.Migrations
{
    /// <inheritdoc />
    public partial class teste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b6bb4218-a1bb-45fc-9fa9-31519e523754",
                columns: new[] { "ConcurrencyStamp", "Cpf", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b120896e-87ce-49df-ad1a-e9ff7c493080", "00000000000", "AQAAAAIAAYagAAAAEPhHNU4TvdCdWebsO3oWWGbyqBo4bYFhyXIed9yXn7d9bYB64xgf0BzcpHrUQqYBXg==", "cf301a50-9cb9-47b9-83b3-2cd9da63a248" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ebba5465-9c71-443e-b035-6438699dabaa",
                columns: new[] { "ConcurrencyStamp", "Cpf", "PasswordHash", "SecurityStamp" },
                values: new object[] { "50bb2cdf-6b17-4fda-92f2-bf6af639b694", "11111111111", "AQAAAAIAAYagAAAAEEEuTnxFLMooU8pNy4xT6kLQl2fM8v9AIUz27saztEL+o44olrWzHNk7YkXiKsfNNQ==", "a9c22468-1597-4339-9398-b5b4837f9c85" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b6bb4218-a1bb-45fc-9fa9-31519e523754",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "efbdf7a1-0780-4f17-b35a-4ed582e023f8", "AQAAAAIAAYagAAAAEErwSxo7tCFdLC5R+vo2hAGzWzOxCtmOYVg5YtHGzTAHru/eApF/rjNOZIr2MWU6zw==", "777f8b48-6374-4763-a0e4-bfebe699e2c6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ebba5465-9c71-443e-b035-6438699dabaa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a41ba883-02c9-4b26-99ca-c9ad3d453033", "AQAAAAIAAYagAAAAEEFU++/cOL1Q2PVFJZOitu6wSV4QPbjf97+Xiel2RNE+U+VbCfOtKyNeBKfq7oAT7w==", "4ef5f4ac-449b-4390-990e-a9614762e3ad" });
        }
    }
}
