using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Migrations
{
    public partial class lbr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admins",
                columns: table => new
                {
                    admin_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    admin_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    create_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    delete_Flag = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admins", x => x.admin_ID);
                });

            migrationBuilder.CreateTable(
                name: "authorss",
                columns: table => new
                {
                    authors_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    create_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    delete_Flag = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authorss", x => x.authors_ID);
                });

            migrationBuilder.CreateTable(
                name: "genress",
                columns: table => new
                {
                    genres_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    create_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    delete_Flag = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genress", x => x.genres_ID);
                });

            migrationBuilder.CreateTable(
                name: "userss",
                columns: table => new
                {
                    users_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    create_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    delete_Flag = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userss", x => x.users_ID);
                });

            migrationBuilder.CreateTable(
                name: "bookss",
                columns: table => new
                {
                    books_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    subtitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    authors_ID = table.Column<int>(type: "int", nullable: false),
                    genres_ID = table.Column<int>(type: "int", nullable: false),
                    publishing_Year = table.Column<int>(type: "int", nullable: false),
                    quantity_In_Stock = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    create_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    delete_Flag = table.Column<bool>(type: "bit", nullable: false),
                    authors_ID1 = table.Column<int>(type: "int", nullable: false),
                    genres_ID1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookss", x => x.books_ID);
                    table.ForeignKey(
                        name: "FK_bookss_authorss_authors_ID1",
                        column: x => x.authors_ID1,
                        principalTable: "authorss",
                        principalColumn: "authors_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bookss_genress_genres_ID1",
                        column: x => x.genres_ID1,
                        principalTable: "genress",
                        principalColumn: "genres_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "borrowingss",
                columns: table => new
                {
                    borrowings_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    users_ID = table.Column<int>(type: "int", nullable: false),
                    start_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    end_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    actual_End_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    create_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    delete_Flag = table.Column<bool>(type: "bit", nullable: false),
                    Users_brusers_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_borrowingss", x => x.borrowings_ID);
                    table.ForeignKey(
                        name: "FK_borrowingss_userss_Users_brusers_ID",
                        column: x => x.Users_brusers_ID,
                        principalTable: "userss",
                        principalColumn: "users_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ratingss",
                columns: table => new
                {
                    ratings_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    books_ID = table.Column<int>(type: "int", nullable: false),
                    users_ID = table.Column<int>(type: "int", nullable: false),
                    star = table.Column<int>(type: "int", nullable: false),
                    create_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    delete_Flag = table.Column<bool>(type: "bit", nullable: false),
                    books_rbooks_ID = table.Column<int>(type: "int", nullable: false),
                    users_rusers_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ratingss", x => x.ratings_ID);
                    table.ForeignKey(
                        name: "FK_ratingss_bookss_books_rbooks_ID",
                        column: x => x.books_rbooks_ID,
                        principalTable: "bookss",
                        principalColumn: "books_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ratingss_userss_users_rusers_ID",
                        column: x => x.users_rusers_ID,
                        principalTable: "userss",
                        principalColumn: "users_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "borrowingItems",
                columns: table => new
                {
                    borrowingItem_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    borrowings_ID = table.Column<int>(type: "int", nullable: false),
                    books_ID = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    create_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    delete_Flag = table.Column<bool>(type: "bit", nullable: false),
                    Borrowings_briborrowings_ID = table.Column<int>(type: "int", nullable: false),
                    Books_bribooks_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_borrowingItems", x => x.borrowingItem_ID);
                    table.ForeignKey(
                        name: "FK_borrowingItems_bookss_Books_bribooks_ID",
                        column: x => x.Books_bribooks_ID,
                        principalTable: "bookss",
                        principalColumn: "books_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_borrowingItems_borrowingss_Borrowings_briborrowings_ID",
                        column: x => x.Borrowings_briborrowings_ID,
                        principalTable: "borrowingss",
                        principalColumn: "borrowings_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bookss_authors_ID1",
                table: "bookss",
                column: "authors_ID1");

            migrationBuilder.CreateIndex(
                name: "IX_bookss_genres_ID1",
                table: "bookss",
                column: "genres_ID1");

            migrationBuilder.CreateIndex(
                name: "IX_borrowingItems_Books_bribooks_ID",
                table: "borrowingItems",
                column: "Books_bribooks_ID");

            migrationBuilder.CreateIndex(
                name: "IX_borrowingItems_Borrowings_briborrowings_ID",
                table: "borrowingItems",
                column: "Borrowings_briborrowings_ID");

            migrationBuilder.CreateIndex(
                name: "IX_borrowingss_Users_brusers_ID",
                table: "borrowingss",
                column: "Users_brusers_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ratingss_books_rbooks_ID",
                table: "ratingss",
                column: "books_rbooks_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ratingss_users_rusers_ID",
                table: "ratingss",
                column: "users_rusers_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admins");

            migrationBuilder.DropTable(
                name: "borrowingItems");

            migrationBuilder.DropTable(
                name: "ratingss");

            migrationBuilder.DropTable(
                name: "borrowingss");

            migrationBuilder.DropTable(
                name: "bookss");

            migrationBuilder.DropTable(
                name: "userss");

            migrationBuilder.DropTable(
                name: "authorss");

            migrationBuilder.DropTable(
                name: "genress");
        }
    }
}
