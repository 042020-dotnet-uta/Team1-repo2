using Microsoft.EntityFrameworkCore.Migrations;

namespace CookingPapa.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RecipeIngredients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeIngredientName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecipeMeasurements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeMeasurementName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeMeasurements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecipeOrigins",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeOriginName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeOrigins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: true),
                    RecipeOriginId = table.Column<int>(nullable: true),
                    RecipeName = table.Column<string>(nullable: true),
                    RecipeCookTime = table.Column<int>(nullable: false),
                    RecipeInstruction = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_RecipeOrigins_RecipeOriginId",
                        column: x => x.RecipeOriginId,
                        principalTable: "RecipeOrigins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recipes_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CookBook",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: true),
                    RecipeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CookBook", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CookBook_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CookBook_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecipeIngredientGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<int>(nullable: true),
                    RecipeIngredientId = table.Column<int>(nullable: true),
                    RecipeMeasurementId = table.Column<int>(nullable: true),
                    RecipeIngredientAmount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredientGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeIngredientGroups_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecipeIngredientGroups_RecipeIngredients_RecipeIngredientId",
                        column: x => x.RecipeIngredientId,
                        principalTable: "RecipeIngredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecipeIngredientGroups_RecipeMeasurements_RecipeMeasurementId",
                        column: x => x.RecipeMeasurementId,
                        principalTable: "RecipeMeasurements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecipeReviews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: true),
                    RecipeId = table.Column<int>(nullable: true),
                    RecipeReviewRating = table.Column<int>(nullable: false),
                    RecipeReviewComment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeReviews_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecipeReviews_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CookBook_RecipeId",
                table: "CookBook",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_CookBook_UserId",
                table: "CookBook",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredientGroups_RecipeId",
                table: "RecipeIngredientGroups",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredientGroups_RecipeIngredientId",
                table: "RecipeIngredientGroups",
                column: "RecipeIngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredientGroups_RecipeMeasurementId",
                table: "RecipeIngredientGroups",
                column: "RecipeMeasurementId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeReviews_RecipeId",
                table: "RecipeReviews",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeReviews_UserId",
                table: "RecipeReviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_RecipeOriginId",
                table: "Recipes",
                column: "RecipeOriginId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_UserId",
                table: "Recipes",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CookBook");

            migrationBuilder.DropTable(
                name: "RecipeIngredientGroups");

            migrationBuilder.DropTable(
                name: "RecipeReviews");

            migrationBuilder.DropTable(
                name: "RecipeIngredients");

            migrationBuilder.DropTable(
                name: "RecipeMeasurements");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "RecipeOrigins");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
