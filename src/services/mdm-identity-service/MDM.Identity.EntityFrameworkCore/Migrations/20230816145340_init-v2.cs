using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Identity.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class initv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductBundleColections_ProductBundles_ProductBundleId",
                table: "ProductBundleColections");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductBundleColections_Products_ProductRelated",
                table: "ProductBundleColections");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductBundles_Products_ProductBaseId",
                table: "ProductBundles");

            migrationBuilder.DropTable(
                name: "ProductBundleVariants");

            migrationBuilder.DropTable(
                name: "ProductMediaBase");

            migrationBuilder.DropTable(
                name: "ProductVariant");

            migrationBuilder.DropIndex(
                name: "IX_ProductBundles_ProductBaseId",
                table: "ProductBundles");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ProductBundles");

            migrationBuilder.DropColumn(
                name: "ProductBaseId",
                table: "ProductBundles");

            migrationBuilder.DropColumn(
                name: "ProductBundleType",
                table: "ProductBundles");

            migrationBuilder.DropColumn(
                name: "ProductRelated",
                table: "ProductBundles");

            migrationBuilder.RenameColumn(
                name: "ProductRelated",
                table: "ProductBundleColections",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "ProductBundleId",
                table: "ProductBundleColections",
                newName: "BundleId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductBundleColections_ProductRelated",
                table: "ProductBundleColections",
                newName: "IX_ProductBundleColections_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductBundleColections_ProductBundleId",
                table: "ProductBundleColections",
                newName: "IX_ProductBundleColections_BundleId");

            migrationBuilder.AlterColumn<bool>(
                name: "StockTrackingIsEnabled",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "MarkAsNew",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(1000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<Guid>(
                name: "GiftItemId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ProductType",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "SalePrice",
                table: "Products",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ProductBundles",
                type: "nvarchar(1000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "ProductBundles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<float>(
                name: "Quantity",
                table: "ProductBundleColections",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<bool>(
                name: "IsPrimary",
                table: "ProductBundleColections",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    IncludeInTopMenu = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(512)", nullable: false),
                    SeoTitle = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    SeoKeywords = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    SeoDescription = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    SeoSlug = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gifts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    ProductGiftType = table.Column<int>(type: "int", nullable: false),
                    MaxChoice = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    EffectStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EffectEndDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gifts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PriceLists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(4000)", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductMedias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(512)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(512)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(4000)", nullable: true),
                    MediaType = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMedias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductMedias_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductRelated",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    RelatedType = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductRelated", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductRelated_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GiftItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<float>(type: "real", nullable: false),
                    GiftId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiftItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GiftItems_Gifts_GiftId",
                        column: x => x.GiftId,
                        principalTable: "Gifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductGifts",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GiftId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGifts", x => new { x.ProductId, x.GiftId });
                    table.ForeignKey(
                        name: "FK_ProductGifts_Gifts_GiftId",
                        column: x => x.GiftId,
                        principalTable: "Gifts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductGifts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Price",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false),
                    MinQuantity = table.Column<float>(type: "real", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(4000)", nullable: true),
                    ComputePrice = table.Column<int>(type: "int", nullable: true),
                    Percent = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PriceListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Price", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Price_PriceLists_PriceListId",
                        column: x => x.PriceListId,
                        principalTable: "PriceLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Price_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PriceListAssignments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PriceListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerSegmentTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConditionExpression = table.Column<string>(type: "nvarchar(4000)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceListAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceListAssignments_PriceLists_PriceListId",
                        column: x => x.PriceListId,
                        principalTable: "PriceLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_GiftItemId",
                table: "Products",
                column: "GiftItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductBundles_ProductId",
                table: "ProductBundles",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_GiftItems_GiftId",
                table: "GiftItems",
                column: "GiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Price_PriceListId",
                table: "Price",
                column: "PriceListId");

            migrationBuilder.CreateIndex(
                name: "IX_Price_ProductId",
                table: "Price",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceListAssignments_PriceListId",
                table: "PriceListAssignments",
                column: "PriceListId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryId",
                table: "ProductCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_ProductId",
                table: "ProductCategories",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductGifts_GiftId",
                table: "ProductGifts",
                column: "GiftId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductMedias_ProductId",
                table: "ProductMedias",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductRelated_ProductId",
                table: "ProductRelated",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductBundleColections_ProductBundles_BundleId",
                table: "ProductBundleColections",
                column: "BundleId",
                principalTable: "ProductBundles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductBundleColections_Products_ProductId",
                table: "ProductBundleColections",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductBundles_Products_ProductId",
                table: "ProductBundles",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_GiftItems_GiftItemId",
                table: "Products",
                column: "GiftItemId",
                principalTable: "GiftItems",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductBundleColections_ProductBundles_BundleId",
                table: "ProductBundleColections");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductBundleColections_Products_ProductId",
                table: "ProductBundleColections");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductBundles_Products_ProductId",
                table: "ProductBundles");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_GiftItems_GiftItemId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "GiftItems");

            migrationBuilder.DropTable(
                name: "Price");

            migrationBuilder.DropTable(
                name: "PriceListAssignments");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "ProductGifts");

            migrationBuilder.DropTable(
                name: "ProductMedias");

            migrationBuilder.DropTable(
                name: "ProductRelated");

            migrationBuilder.DropTable(
                name: "PriceLists");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Gifts");

            migrationBuilder.DropIndex(
                name: "IX_Products_GiftItemId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_ProductBundles_ProductId",
                table: "ProductBundles");

            migrationBuilder.DropColumn(
                name: "GiftItemId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductType",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SalePrice",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ProductBundles");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductBundles");

            migrationBuilder.DropColumn(
                name: "IsPrimary",
                table: "ProductBundleColections");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ProductBundleColections",
                newName: "ProductRelated");

            migrationBuilder.RenameColumn(
                name: "BundleId",
                table: "ProductBundleColections",
                newName: "ProductBundleId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductBundleColections_ProductId",
                table: "ProductBundleColections",
                newName: "IX_ProductBundleColections_ProductRelated");

            migrationBuilder.RenameIndex(
                name: "IX_ProductBundleColections_BundleId",
                table: "ProductBundleColections",
                newName: "IX_ProductBundleColections_ProductBundleId");

            migrationBuilder.AlterColumn<bool>(
                name: "StockTrackingIsEnabled",
                table: "Products",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "MarkAsNew",
                table: "Products",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)");

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ProductBundles",
                type: "nvarchar(128)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductBaseId",
                table: "ProductBundles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductBundleType",
                table: "ProductBundles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductRelated",
                table: "ProductBundles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "ProductBundleColections",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.CreateTable(
                name: "ProductMediaBase",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(4000)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    MediaType = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(512)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(512)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMediaBase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductMediaBase_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductVariant",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(64)", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    TenantId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVariant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductVariant_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductBundleVariants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductBundleColectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductVariantRelated = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductBundleVariants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductBundleVariants_ProductBundleColections_ProductBundleColectionId",
                        column: x => x.ProductBundleColectionId,
                        principalTable: "ProductBundleColections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductBundleVariants_ProductVariant_ProductVariantRelated",
                        column: x => x.ProductVariantRelated,
                        principalTable: "ProductVariant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductBundles_ProductBaseId",
                table: "ProductBundles",
                column: "ProductBaseId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductBundleVariants_ProductBundleColectionId",
                table: "ProductBundleVariants",
                column: "ProductBundleColectionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductBundleVariants_ProductVariantRelated",
                table: "ProductBundleVariants",
                column: "ProductVariantRelated");

            migrationBuilder.CreateIndex(
                name: "IX_ProductMediaBase_ProductId",
                table: "ProductMediaBase",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariant_ProductId",
                table: "ProductVariant",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductBundleColections_ProductBundles_ProductBundleId",
                table: "ProductBundleColections",
                column: "ProductBundleId",
                principalTable: "ProductBundles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductBundleColections_Products_ProductRelated",
                table: "ProductBundleColections",
                column: "ProductRelated",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductBundles_Products_ProductBaseId",
                table: "ProductBundles",
                column: "ProductBaseId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
