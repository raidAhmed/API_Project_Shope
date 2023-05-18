using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agricultural.Infrastructure.Migrations
{
    public partial class new2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_ServiceProvider_ServiceProviderId",
                schema: "dbo",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_ServiceProviderId",
                schema: "dbo",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "ServiceProviderId",
                schema: "dbo",
                table: "Address");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                schema: "dbo",
                table: "Slider",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 16, 23, 38, 50, 812, DateTimeKind.Local).AddTicks(3369),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2023, 3, 28, 0, 57, 23, 762, DateTimeKind.Local).AddTicks(344));

            migrationBuilder.AlterColumn<int>(
                name: "NatId",
                schema: "dbo",
                table: "ServiceProvider",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 111111);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a2e1650-21bd-4e67-832e-2e99c267a2e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "11c1485f-08f0-4cc0-98f5-8fc983da15b0", "AQAAAAEAACcQAAAAEIiQbB2tCeUc5MZutArcmsOiZCzWeNxMIJpqDNv0jBMjOfzcOgMIZNnaJHMkSxxgMg==", "cc6e2c26-1459-42b4-8695-f4c738702d9d" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ServiceProvider",
                keyColumn: "Id",
                keyValue: 1,
                column: "Email",
                value: "admin@gmail.com");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                schema: "dbo",
                table: "Slider",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 28, 0, 57, 23, 762, DateTimeKind.Local).AddTicks(344),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2023, 4, 16, 23, 38, 50, 812, DateTimeKind.Local).AddTicks(3369));

            migrationBuilder.AlterColumn<int>(
                name: "NatId",
                schema: "dbo",
                table: "ServiceProvider",
                type: "int",
                nullable: false,
                defaultValue: 111111,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServiceProviderId",
                schema: "dbo",
                table: "Address",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a2e1650-21bd-4e67-832e-2e99c267a2e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c270bb22-b4d9-4abf-8d06-942d4b633836", "AQAAAAEAACcQAAAAENJa4jon8qZGz5PQxo/UyKb5CkZZpIjFPSt7pxtp2qdddM9X7So5M5+XQqzrKKxWsA==", "c72cd74c-33c9-4e61-87fa-a2e640740365" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ServiceProvider",
                keyColumn: "Id",
                keyValue: 1,
                column: "Email",
                value: "m@g");

            migrationBuilder.CreateIndex(
                name: "IX_Address_ServiceProviderId",
                schema: "dbo",
                table: "Address",
                column: "ServiceProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_ServiceProvider_ServiceProviderId",
                schema: "dbo",
                table: "Address",
                column: "ServiceProviderId",
                principalSchema: "dbo",
                principalTable: "ServiceProvider",
                principalColumn: "Id");
        }
    }
}
