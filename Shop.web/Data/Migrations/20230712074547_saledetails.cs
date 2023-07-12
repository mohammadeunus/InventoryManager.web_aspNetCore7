using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.web.Data.Migrations
{
    /// <inheritdoc />
    public partial class saledetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesDetails_Products_ProductId",
                table: "SalesDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesSummaries_Customers_CustomerId",
                table: "SalesSummaries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalesSummaries",
                table: "SalesSummaries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalesDetails",
                table: "SalesDetails");

            migrationBuilder.RenameTable(
                name: "SalesSummaries",
                newName: "salesSummaries");

            migrationBuilder.RenameTable(
                name: "SalesDetails",
                newName: "salesDetails");

            migrationBuilder.RenameIndex(
                name: "IX_SalesSummaries_CustomerId",
                table: "salesSummaries",
                newName: "IX_salesSummaries_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_SalesDetails_ProductId",
                table: "salesDetails",
                newName: "IX_salesDetails_ProductId");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalVat",
                table: "salesSummaries",
                type: "decimal(5,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalDiscount",
                table: "salesSummaries",
                type: "decimal(5,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "salesSummaries",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<decimal>(
                name: "VatPercent",
                table: "salesDetails",
                type: "decimal(5,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "salesDetails",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "InvoiceNo",
                table: "salesDetails",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "salesDetails",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_salesSummaries",
                table: "salesSummaries",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_salesDetails",
                table: "salesDetails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_salesDetails_Products_ProductId",
                table: "salesDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_salesSummaries_Customers_CustomerId",
                table: "salesSummaries",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_salesDetails_Products_ProductId",
                table: "salesDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_salesSummaries_Customers_CustomerId",
                table: "salesSummaries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_salesSummaries",
                table: "salesSummaries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_salesDetails",
                table: "salesDetails");

            migrationBuilder.RenameTable(
                name: "salesSummaries",
                newName: "SalesSummaries");

            migrationBuilder.RenameTable(
                name: "salesDetails",
                newName: "SalesDetails");

            migrationBuilder.RenameIndex(
                name: "IX_salesSummaries_CustomerId",
                table: "SalesSummaries",
                newName: "IX_SalesSummaries_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_salesDetails_ProductId",
                table: "SalesDetails",
                newName: "IX_SalesDetails_ProductId");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalVat",
                table: "SalesSummaries",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalDiscount",
                table: "SalesSummaries",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "SalesSummaries",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "VatPercent",
                table: "SalesDetails",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "SalesDetails",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InvoiceNo",
                table: "SalesDetails",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "SalesDetails",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalesSummaries",
                table: "SalesSummaries",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalesDetails",
                table: "SalesDetails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesDetails_Products_ProductId",
                table: "SalesDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesSummaries_Customers_CustomerId",
                table: "SalesSummaries",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
