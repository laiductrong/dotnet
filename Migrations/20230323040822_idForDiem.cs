using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class idForDiem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiemThis_MonHocs_monHocIdId",
                table: "DiemThis");

            migrationBuilder.DropForeignKey(
                name: "FK_DiemThis_SinhViens_sinhVienIdId",
                table: "DiemThis");

            migrationBuilder.DropIndex(
                name: "IX_DiemThis_monHocIdId",
                table: "DiemThis");

            migrationBuilder.DropIndex(
                name: "IX_DiemThis_sinhVienIdId",
                table: "DiemThis");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "DiemThis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DiemThis",
                table: "DiemThis",
                columns: new[] { "sinhVienIdId", "monHocIdId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DiemThis",
                table: "DiemThis");

            migrationBuilder.DropColumn(
                name: "id",
                table: "DiemThis");

            migrationBuilder.CreateIndex(
                name: "IX_DiemThis_monHocIdId",
                table: "DiemThis",
                column: "monHocIdId");

            migrationBuilder.CreateIndex(
                name: "IX_DiemThis_sinhVienIdId",
                table: "DiemThis",
                column: "sinhVienIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_DiemThis_MonHocs_monHocIdId",
                table: "DiemThis",
                column: "monHocIdId",
                principalTable: "MonHocs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DiemThis_SinhViens_sinhVienIdId",
                table: "DiemThis",
                column: "sinhVienIdId",
                principalTable: "SinhViens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
