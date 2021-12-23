using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class Aboba : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Descc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Kingdoms",
                columns: table => new
                {
                    KingdomId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kingdoms", x => x.KingdomId);
                });

            migrationBuilder.CreateTable(
                name: "ClassA",
                columns: table => new
                {
                    ClassID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    KingdomID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassA", x => x.ClassID);
                    table.ForeignKey(
                        name: "FK_ClassA_Kingdoms",
                        column: x => x.KingdomID,
                        principalTable: "Kingdoms",
                        principalColumn: "KingdomId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubClass",
                columns: table => new
                {
                    subClassID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    ClassID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubClass", x => x.subClassID);
                    table.ForeignKey(
                        name: "FK_SubClass_ClassA",
                        column: x => x.ClassID,
                        principalTable: "ClassA",
                        principalColumn: "ClassID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Thiss",
                columns: table => new
                {
                    ThisID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    descc = table.Column<string>(nullable: true),
                    img = table.Column<string>(nullable: true),
                    SubClassID = table.Column<int>(nullable: true),
                    CategoryID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thiss", x => x.ThisID);
                    table.ForeignKey(
                        name: "FK_Thiss_Category",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Thiss_SubClass",
                        column: x => x.SubClassID,
                        principalTable: "SubClass",
                        principalColumn: "subClassID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassA_KingdomID",
                table: "ClassA",
                column: "KingdomID");

            migrationBuilder.CreateIndex(
                name: "IX_SubClass_ClassID",
                table: "SubClass",
                column: "ClassID");

            migrationBuilder.CreateIndex(
                name: "IX_Thiss_CategoryID",
                table: "Thiss",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Thiss_SubClassID",
                table: "Thiss",
                column: "SubClassID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Thiss");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "SubClass");

            migrationBuilder.DropTable(
                name: "ClassA");

            migrationBuilder.DropTable(
                name: "Kingdoms");
        }
    }
}
