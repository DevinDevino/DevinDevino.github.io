using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeparateCategorieAndBeschrijving : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Beschrijving_BeschrijvingId",
                table: "Blogs");

            migrationBuilder.RenameTable(
                name: "Beschrijving",
                newName: "Categorie");

            migrationBuilder.RenameColumn(
                name: "Titel",
                table: "Categorie",
                newName: "Naam");

            migrationBuilder.RenameColumn(
                name: "BeschrijvingId",
                table: "Blogs",
                newName: "CategorieId");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_BeschrijvingId",
                table: "Blogs",
                newName: "IX_Blogs_CategorieId");

            migrationBuilder.AddColumn<string>(
                name: "Beschrijving",
                table: "Blogs",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Categorie_CategorieId",
                table: "Blogs",
                column: "CategorieId",
                principalTable: "Categorie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Categorie_CategorieId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "Beschrijving",
                table: "Blogs");

            migrationBuilder.RenameColumn(
                name: "CategorieId",
                table: "Blogs",
                newName: "BeschrijvingId");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_CategorieId",
                table: "Blogs",
                newName: "IX_Blogs_BeschrijvingId");

            migrationBuilder.RenameTable(
                name: "Categorie",
                newName: "Beschrijving");

            migrationBuilder.RenameColumn(
                name: "Naam",
                table: "Beschrijving",
                newName: "Titel");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Beschrijving_BeschrijvingId",
                table: "Blogs",
                column: "BeschrijvingId",
                principalTable: "Beschrijving",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
