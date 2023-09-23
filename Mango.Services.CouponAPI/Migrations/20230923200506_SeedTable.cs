using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mango.Services.CouponAPI.Migrations
{
    public partial class SeedTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CouponCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CouponAmount = table.Column<double>(type: "float", nullable: false),
                    MinAmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "Id", "CouponAmount", "CouponCode", "MinAmount" },
                values: new object[] { 1, 15.0, "FFF10", 10 });

            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "Id", "CouponAmount", "CouponCode", "MinAmount" },
                values: new object[] { 2, 30.0, "GG300", 15 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coupons");
        }
    }
}
