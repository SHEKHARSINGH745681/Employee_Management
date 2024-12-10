using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EmployeeAdminPortal.Migrations
{
    /// <inheritdoc />
    public partial class Add3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Farmers_FarmerId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_UploadImages_Farmers_FarmerId",
                table: "UploadImages");

            migrationBuilder.DropIndex(
                name: "IX_UploadImages_FarmerId",
                table: "UploadImages");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_FarmerId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "FarmerId",
                table: "UploadImages");

            migrationBuilder.DropColumn(
                name: "FarmerId",
                table: "Addresses");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "UploadImages",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "ImageId",
                table: "Farmers",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_Farmers_AddressId",
                table: "Farmers",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Farmers_Addresses_AddressId",
                table: "Farmers",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UploadImages_Farmers_Id",
                table: "UploadImages",
                column: "Id",
                principalTable: "Farmers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Farmers_Addresses_AddressId",
                table: "Farmers");

            migrationBuilder.DropForeignKey(
                name: "FK_UploadImages_Farmers_Id",
                table: "UploadImages");

            migrationBuilder.DropIndex(
                name: "IX_Farmers_AddressId",
                table: "Farmers");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "UploadImages",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "FarmerId",
                table: "UploadImages",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ImageId",
                table: "Farmers",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FarmerId",
                table: "Addresses",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UploadImages_FarmerId",
                table: "UploadImages",
                column: "FarmerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_FarmerId",
                table: "Addresses",
                column: "FarmerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Farmers_FarmerId",
                table: "Addresses",
                column: "FarmerId",
                principalTable: "Farmers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UploadImages_Farmers_FarmerId",
                table: "UploadImages",
                column: "FarmerId",
                principalTable: "Farmers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
