using Microsoft.EntityFrameworkCore.Migrations;

namespace Watchmasters.Migrations
{
    public partial class AddedStore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Watch",
                type: "decimal(11, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "StoreID",
                table: "Watch",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Watch_StoreID",
                table: "Watch",
                column: "StoreID");

            migrationBuilder.AddForeignKey(
                name: "FK_Watch_Store_StoreID",
                table: "Watch",
                column: "StoreID",
                principalTable: "Store",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Watch_Store_StoreID",
                table: "Watch");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropIndex(
                name: "IX_Watch_StoreID",
                table: "Watch");

            migrationBuilder.DropColumn(
                name: "StoreID",
                table: "Watch");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Watch",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(11, 2)");
        }
    }
}
