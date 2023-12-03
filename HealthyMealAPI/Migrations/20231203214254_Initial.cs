using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthyMealAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EatingType",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(450)", unicode: false, maxLength: 450, nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EatingType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Food",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(450)", unicode: false, maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Food", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(450)", unicode: false, maxLength: 450, nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(450)", unicode: false, maxLength: 450, nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KcalGoal = table.Column<double>(type: "float", nullable: false),
                    NormalKcal = table.Column<double>(type: "float", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NutritionalValue",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(450)", unicode: false, maxLength: 450, nullable: false),
                    FoodId = table.Column<string>(type: "varchar(450)", unicode: false, maxLength: 450, nullable: false),
                    UnitsId = table.Column<string>(type: "varchar(450)", unicode: false, maxLength: 450, nullable: false),
                    Kcal = table.Column<double>(type: "float", nullable: false),
                    Proteins = table.Column<double>(type: "float", nullable: false),
                    Fats = table.Column<double>(type: "float", nullable: false),
                    Carbohydrates = table.Column<double>(type: "float", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NutritionalValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NutritionalValue_Food",
                        column: x => x.FoodId,
                        principalTable: "Food",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NutritionalValue_UnitsId",
                        column: x => x.UnitsId,
                        principalTable: "Units",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "varchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "varchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(450)", unicode: false, maxLength: 450, nullable: false),
                    UserId = table.Column<string>(type: "varchar(450)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Kcal = table.Column<double>(type: "float", nullable: false),
                    Proteins = table.Column<double>(type: "float", nullable: false),
                    Fats = table.Column<double>(type: "float", nullable: false),
                    Carbohydrates = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menu_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(450)", unicode: false, maxLength: 450, nullable: false),
                    FoodId = table.Column<string>(type: "varchar(450)", unicode: false, maxLength: 450, nullable: false),
                    UserId = table.Column<string>(type: "varchar(450)", nullable: false),
                    Name = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Description = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Food",
                        column: x => x.FoodId,
                        principalTable: "Food",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Product_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Recipe",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(450)", unicode: false, maxLength: 450, nullable: false),
                    FoodId = table.Column<string>(type: "varchar(450)", unicode: false, maxLength: 450, nullable: false),
                    UserId = table.Column<string>(type: "varchar(450)", nullable: false),
                    Name = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CookingTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Description = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipe_Food",
                        column: x => x.FoodId,
                        principalTable: "Food",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Recipe_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Eating",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(450)", unicode: false, maxLength: 450, nullable: false),
                    EatingTypeId = table.Column<string>(type: "varchar(450)", unicode: false, maxLength: 450, nullable: false),
                    NutritionalValueId = table.Column<string>(type: "varchar(450)", unicode: false, maxLength: 450, nullable: false),
                    UserId = table.Column<string>(type: "varchar(450)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    AmountEaten = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Eating_EatingTypeId",
                        column: x => x.EatingTypeId,
                        principalTable: "EatingType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Eating_NutritionalValue",
                        column: x => x.NutritionalValueId,
                        principalTable: "NutritionalValue",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Eating_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductToBuy",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(450)", unicode: false, maxLength: 450, nullable: false),
                    ProductId = table.Column<string>(type: "varchar(450)", unicode: false, maxLength: 450, nullable: false),
                    UnitsId = table.Column<string>(type: "varchar(450)", unicode: false, maxLength: 450, nullable: false),
                    UserId = table.Column<string>(type: "varchar(450)", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsBought = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductToBuy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductToBuy_Product",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductToBuy_Units",
                        column: x => x.UnitsId,
                        principalTable: "Units",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductToBuy_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CookingStep",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(450)", unicode: false, maxLength: 450, nullable: false),
                    RecipeId = table.Column<string>(type: "varchar(450)", unicode: false, maxLength: 450, nullable: false),
                    StepNumber = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CookingStep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CookingStep_Recipe",
                        column: x => x.RecipeId,
                        principalTable: "Recipe",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ingredient",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(450)", unicode: false, maxLength: 450, nullable: false),
                    ProductId = table.Column<string>(type: "varchar(450)", unicode: false, maxLength: 450, nullable: false),
                    RecipeId = table.Column<string>(type: "varchar(450)", unicode: false, maxLength: 450, nullable: false),
                    UnitsId = table.Column<string>(type: "varchar(450)", unicode: false, maxLength: 450, nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredient_Product",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ingredient_Recipe",
                        column: x => x.RecipeId,
                        principalTable: "Recipe",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ingredient_Units",
                        column: x => x.UnitsId,
                        principalTable: "Units",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MenuString",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(450)", unicode: false, maxLength: 450, nullable: false),
                    EatingTypeId = table.Column<string>(type: "varchar(450)", unicode: false, maxLength: 450, nullable: false),
                    RecipeId = table.Column<string>(type: "varchar(450)", unicode: false, maxLength: 450, nullable: false),
                    MenuId = table.Column<string>(type: "varchar(450)", unicode: false, maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuString", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuString_EatingTypeId",
                        column: x => x.EatingTypeId,
                        principalTable: "EatingType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MenuString_Menu",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MenuString_Recipe",
                        column: x => x.RecipeId,
                        principalTable: "Recipe",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_CookingStep_RecipeId",
                table: "CookingStep",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Eating_EatingTypeId",
                table: "Eating",
                column: "EatingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Eating_NutritionalValueId",
                table: "Eating",
                column: "NutritionalValueId");

            migrationBuilder.CreateIndex(
                name: "IX_Eating_UserId",
                table: "Eating",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_ProductId",
                table: "Ingredient",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_RecipeId",
                table: "Ingredient",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_UnitsId",
                table: "Ingredient",
                column: "UnitsId");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_UserId",
                table: "Menu",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuString_EatingTypeId",
                table: "MenuString",
                column: "EatingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuString_MenuId",
                table: "MenuString",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuString_RecipeId",
                table: "MenuString",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_NutritionalValue_FoodId",
                table: "NutritionalValue",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_NutritionalValue_UnitsId",
                table: "NutritionalValue",
                column: "UnitsId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_FoodId",
                table: "Product",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_UserId",
                table: "Product",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductToBuy_ProductId",
                table: "ProductToBuy",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductToBuy_UnitsId",
                table: "ProductToBuy",
                column: "UnitsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductToBuy_UserId",
                table: "ProductToBuy",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_FoodId",
                table: "Recipe",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_UserId",
                table: "Recipe",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "User",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "User",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CookingStep");

            migrationBuilder.DropTable(
                name: "Eating");

            migrationBuilder.DropTable(
                name: "Ingredient");

            migrationBuilder.DropTable(
                name: "MenuString");

            migrationBuilder.DropTable(
                name: "ProductToBuy");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "NutritionalValue");

            migrationBuilder.DropTable(
                name: "EatingType");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Recipe");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "Food");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
