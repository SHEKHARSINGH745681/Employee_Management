using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EmployeeAdminPortal.Migrations
{
    /// <inheritdoc />
    public partial class Add4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crops_Farmers_FarmerId",
                table: "Crops");

            migrationBuilder.DropForeignKey(
                name: "FK_Farmers_Addresses_AddressId",
                table: "Farmers");

            migrationBuilder.DropIndex(
                name: "IX_Farmers_AddressId",
                table: "Farmers");

            migrationBuilder.DropIndex(
                name: "IX_Crops_FarmerId",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "FarmerId",
                table: "Crops");

            migrationBuilder.AddColumn<int>(
                name: "CattleId",
                table: "Farmers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CropId",
                table: "Farmers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Crops",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Addresses",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateTable(
                name: "Cattle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Breed = table.Column<string>(type: "text", nullable: true),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    HealthStatus = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cattle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cattle_Farmers_Id",
                        column: x => x.Id,
                        principalTable: "Farmers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Farmers_Id",
                table: "Addresses",
                column: "Id",
                principalTable: "Farmers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_Farmers_Id",
                table: "Crops",
                column: "Id",
                principalTable: "Farmers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Farmers_Id",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Crops_Farmers_Id",
                table: "Crops");

            migrationBuilder.DropTable(
                name: "Cattle");

            migrationBuilder.DropColumn(
                name: "CattleId",
                table: "Farmers");

            migrationBuilder.DropColumn(
                name: "CropId",
                table: "Farmers");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Crops",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "FarmerId",
                table: "Crops",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Addresses",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateIndex(
                name: "IX_Farmers_AddressId",
                table: "Farmers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Crops_FarmerId",
                table: "Crops",
                column: "FarmerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_Farmers_FarmerId",
                table: "Crops",
                column: "FarmerId",
                principalTable: "Farmers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Farmers_Addresses_AddressId",
                table: "Farmers",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
