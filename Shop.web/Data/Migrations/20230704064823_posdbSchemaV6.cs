using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.web.Data.Migrations
{
    /// <inheritdoc />
    public partial class posdbSchemaV6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "updatedDate",
                table: "Categories",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "updatedBy",
                table: "Categories",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "createdDate",
                table: "Categories",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "createdBy",
                table: "Categories",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Admins",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Admins",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "isDelete",
                table: "Admins",
                newName: "IsDelete");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Admins",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "userName",
                table: "Admins",
                newName: "UserName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "Categories",
                newName: "updatedDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "Categories",
                newName: "updatedBy");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Categories",
                newName: "createdDate");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Categories",
                newName: "createdBy");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Admins",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Admins",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                table: "Admins",
                newName: "isDelete");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Admins",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Admins",
                newName: "userName");
        }
    }
}
