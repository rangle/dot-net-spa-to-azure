using Microsoft.EntityFrameworkCore.Migrations;

namespace functions.Migrations
{
    public partial class RemovedStateFromCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_States_StateId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_StateId",
                table: "Customers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Customers_StateId",
                table: "Customers",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_States_StateId",
                table: "Customers",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
