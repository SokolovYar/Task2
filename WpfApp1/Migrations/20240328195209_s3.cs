using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WpfApp1.Migrations
{
    /// <inheritdoc />
    public partial class s3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Employees_ConsultantId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Employees_ManagerId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Employees_ManagerId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ManagerId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Clients_ConsultantId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_ManagerId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ClothingProperty",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductType",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TechProperty",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "EmployeeType",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ClientType",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ConsultantId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Clients");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClothingProperty",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductType",
                table: "Products",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TechProperty",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeType",
                table: "Employees",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ClientType",
                table: "Clients",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ConsultantId",
                table: "Clients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "Clients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ManagerId",
                table: "Products",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ConsultantId",
                table: "Clients",
                column: "ConsultantId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ManagerId",
                table: "Clients",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Employees_ConsultantId",
                table: "Clients",
                column: "ConsultantId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Employees_ManagerId",
                table: "Clients",
                column: "ManagerId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Employees_ManagerId",
                table: "Products",
                column: "ManagerId",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}
