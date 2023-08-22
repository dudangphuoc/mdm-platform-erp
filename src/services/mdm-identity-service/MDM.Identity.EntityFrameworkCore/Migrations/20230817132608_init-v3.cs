using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Identity.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class initv3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PriceListAssignments_CustomerSegmentTypeId",
                table: "PriceListAssignments",
                column: "CustomerSegmentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PriceListAssignments_CustomerSegmentTypes_CustomerSegmentTypeId",
                table: "PriceListAssignments",
                column: "CustomerSegmentTypeId",
                principalTable: "CustomerSegmentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PriceListAssignments_CustomerSegmentTypes_CustomerSegmentTypeId",
                table: "PriceListAssignments");

            migrationBuilder.DropIndex(
                name: "IX_PriceListAssignments_CustomerSegmentTypeId",
                table: "PriceListAssignments");
        }
    }
}
