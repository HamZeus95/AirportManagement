using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Data.Migrations
{
    /// <inheritdoc />
    public partial class PlaneConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Planes_PlaneId",
                table: "Flights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Planes",
                table: "Planes");

            migrationBuilder.RenameTable(
                name: "Planes",
                newName: "MyPlans");

            migrationBuilder.RenameColumn(
                name: "Capacity",
                table: "MyPlans",
                newName: "PlaneCapacity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyPlans",
                table: "MyPlans",
                column: "PlaneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_MyPlans_PlaneId",
                table: "Flights",
                column: "PlaneId",
                principalTable: "MyPlans",
                principalColumn: "PlaneId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_MyPlans_PlaneId",
                table: "Flights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MyPlans",
                table: "MyPlans");

            migrationBuilder.RenameTable(
                name: "MyPlans",
                newName: "Planes");

            migrationBuilder.RenameColumn(
                name: "PlaneCapacity",
                table: "Planes",
                newName: "Capacity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Planes",
                table: "Planes",
                column: "PlaneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Planes_PlaneId",
                table: "Flights",
                column: "PlaneId",
                principalTable: "Planes",
                principalColumn: "PlaneId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
