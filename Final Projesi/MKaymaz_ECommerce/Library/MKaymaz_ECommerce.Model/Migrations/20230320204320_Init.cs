using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MKaymaz_ECommerce.Model.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedComputerName = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedComputerName = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: true),
                    ImageUrl = table.Column<string>(maxLength: 255, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Password = table.Column<string>(maxLength: 12, nullable: false),
                    IsAdmin = table.Column<bool>(nullable: true),
                    LastIPAddress = table.Column<string>(maxLength: 15, nullable: true),
                    LastLogin = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedComputerName = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedComputerName = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Slug = table.Column<string>(maxLength: 255, nullable: true),
                    SortOrder = table.Column<int>(nullable: false),
                    DistributorCode = table.Column<string>(maxLength: 255, nullable: true),
                    Distributor = table.Column<string>(maxLength: 255, nullable: true),
                    ImageFile = table.Column<string>(maxLength: 255, nullable: true),
                    ShowcaseContent = table.Column<string>(maxLength: 2147483647, nullable: true),
                    DisplayShowcaseContent = table.Column<string>(nullable: true),
                    MetaKeywords = table.Column<string>(maxLength: 2147483647, nullable: true),
                    MetaDescription = table.Column<string>(maxLength: 2147483647, nullable: true),
                    CanonicalUrl = table.Column<string>(maxLength: 255, nullable: true),
                    PageTitle = table.Column<string>(maxLength: 255, nullable: true),
                    Attachment = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Brands_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Brands_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedComputerName = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedComputerName = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    SessionId = table.Column<Guid>(maxLength: 255, nullable: false),
                    Locked = table.Column<string>(nullable: false),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Carts_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Carts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedComputerName = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedComputerName = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Slug = table.Column<string>(maxLength: 255, nullable: true),
                    SortOrder = table.Column<int>(nullable: false),
                    DistrbutorCode = table.Column<string>(maxLength: 255, nullable: true),
                    Percent = table.Column<decimal>(nullable: false),
                    ImageFile = table.Column<string>(maxLength: 255, nullable: true),
                    Distributor = table.Column<string>(maxLength: 128, nullable: true),
                    DisplayShowcaseContent = table.Column<int>(nullable: false),
                    ShowcaseContent = table.Column<string>(maxLength: 255, nullable: true),
                    ShowcaseContentDisplayType = table.Column<int>(nullable: false),
                    DisplayShowcaseFooterContent = table.Column<int>(nullable: false),
                    ShowcaseFooterContent = table.Column<string>(maxLength: 999, nullable: true),
                    ShowcaseFooterContentDisplayType = table.Column<int>(nullable: false),
                    HasChildren = table.Column<bool>(nullable: false),
                    MetaKeywords = table.Column<string>(maxLength: 999, nullable: true),
                    MetaDescription = table.Column<string>(maxLength: 999, nullable: true),
                    CanonicalUrl = table.Column<string>(maxLength: 255, nullable: true),
                    PageTitle = table.Column<string>(maxLength: 255, nullable: true),
                    Attachment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Categories_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedComputerName = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedComputerName = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Code = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Countries_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Countries_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    CreatedIP = table.Column<string>(nullable: true),
                    CreatedComputerName = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    ModifiedIP = table.Column<string>(nullable: true),
                    ModifiedComputerName = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Label = table.Column<string>(maxLength: 50, nullable: true),
                    BuyingPrice = table.Column<decimal>(nullable: false),
                    SellingPrice = table.Column<decimal>(nullable: false),
                    Abbr = table.Column<string>(maxLength: 5, nullable: true),
                    IsPrimary = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Currencies_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Currencies_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Maillists",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedComputerName = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedComputerName = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Email = table.Column<string>(maxLength: 255, nullable: false),
                    LastMailSentDate = table.Column<DateTime>(nullable: true),
                    CreatorIpAddres = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maillists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Maillists_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Maillists_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderAddresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedComputerName = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedComputerName = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Firstname = table.Column<string>(maxLength: 255, nullable: false),
                    Surname = table.Column<string>(maxLength: 255, nullable: false),
                    Country = table.Column<string>(maxLength: 128, nullable: false),
                    Location = table.Column<string>(maxLength: 128, nullable: false),
                    SubLocation = table.Column<string>(maxLength: 128, nullable: true),
                    Address = table.Column<string>(maxLength: 9999, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 32, nullable: true),
                    MobilePhoneNumber = table.Column<string>(maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderAddresses_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderAddresses_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShippingAddreses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedComputerName = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedComputerName = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Firstname = table.Column<string>(maxLength: 255, nullable: false),
                    Surname = table.Column<string>(maxLength: 255, nullable: false),
                    Country = table.Column<string>(maxLength: 128, nullable: false),
                    Location = table.Column<string>(maxLength: 128, nullable: false),
                    SubLocation = table.Column<string>(maxLength: 128, nullable: true),
                    Address = table.Column<string>(maxLength: 9999, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 32, nullable: false),
                    MobilePhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingAddreses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShippingAddreses_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShippingAddreses_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedComputerName = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedComputerName = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Predefined = table.Column<string>(nullable: true),
                    CountryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Locations_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Locations_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedComputerName = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedComputerName = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Slug = table.Column<string>(maxLength: 255, nullable: true),
                    FullName = table.Column<string>(maxLength: 255, nullable: false),
                    Sku = table.Column<string>(maxLength: 255, nullable: false),
                    Barcode = table.Column<string>(maxLength: 255, nullable: true),
                    Price1 = table.Column<decimal>(nullable: false),
                    Warranty = table.Column<int>(nullable: true),
                    Tax = table.Column<int>(nullable: true),
                    StockAmount = table.Column<decimal>(nullable: true),
                    VolumetricWeight = table.Column<decimal>(nullable: true),
                    BuyingPrice = table.Column<decimal>(nullable: true),
                    StockTypeLabel = table.Column<string>(nullable: false),
                    Discount = table.Column<decimal>(nullable: true),
                    DiscountType = table.Column<int>(nullable: true),
                    MoneyOrderDiscount = table.Column<decimal>(nullable: true),
                    TaxIncluded = table.Column<bool>(nullable: true),
                    Distributor = table.Column<string>(nullable: true),
                    IsGifted = table.Column<bool>(nullable: true),
                    Gift = table.Column<string>(maxLength: 255, nullable: true),
                    CustomShippingDisabled = table.Column<string>(nullable: true),
                    CustomShippingCost = table.Column<decimal>(nullable: true),
                    MarketPriceDetail = table.Column<string>(maxLength: 255, nullable: true),
                    MetaKeywords = table.Column<string>(maxLength: 999, nullable: true),
                    MetaDescription = table.Column<string>(maxLength: 999, nullable: true),
                    CanonicalUrl = table.Column<string>(maxLength: 255, nullable: true),
                    PageTitle = table.Column<string>(maxLength: 255, nullable: true),
                    ShortDetails = table.Column<string>(maxLength: 512, nullable: true),
                    SearchKeywords = table.Column<string>(maxLength: 255, nullable: true),
                    InstallmentThreshold = table.Column<string>(maxLength: 10, nullable: true),
                    HomeSortOrder = table.Column<int>(nullable: true),
                    PopularSortOrder = table.Column<int>(nullable: true),
                    BrandSortOrder = table.Column<int>(nullable: true),
                    FeaturedSortOrder = table.Column<int>(nullable: true),
                    CampaignedSortOrder = table.Column<int>(nullable: true),
                    NewSortOrder = table.Column<int>(nullable: true),
                    DiscountedSortOrder = table.Column<int>(nullable: true),
                    ViewCount = table.Column<int>(nullable: true),
                    BrandId = table.Column<Guid>(nullable: false),
                    ParentId = table.Column<Guid>(nullable: true),
                    CurrencyId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    CategoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Products_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedComputerName = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedComputerName = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 255, nullable: false),
                    SurName = table.Column<string>(maxLength: 255, nullable: false),
                    Email = table.Column<string>(maxLength: 255, nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 255, nullable: true),
                    MobilePhoneNumber = table.Column<string>(maxLength: 255, nullable: false),
                    OtherLocation = table.Column<string>(maxLength: 255, nullable: true),
                    Address = table.Column<string>(maxLength: 2147483647, nullable: true),
                    TaxNumber = table.Column<string>(maxLength: 255, nullable: true),
                    TcId = table.Column<string>(maxLength: 255, nullable: true),
                    LastLoginDate = table.Column<DateTime>(nullable: true),
                    ZipCode = table.Column<string>(maxLength: 50, nullable: true),
                    CommericalName = table.Column<string>(maxLength: 255, nullable: true),
                    TaxOffice = table.Column<string>(maxLength: 255, nullable: true),
                    GainedPointAmount = table.Column<decimal>(nullable: true),
                    SpentPointAmount = table.Column<decimal>(nullable: true),
                    AllowedToCampaigns = table.Column<bool>(nullable: true),
                    District = table.Column<string>(maxLength: 255, nullable: true),
                    DeviceType = table.Column<string>(maxLength: 255, nullable: true),
                    DeviceInfo = table.Column<string>(maxLength: 255, nullable: true),
                    CountryId = table.Column<Guid>(nullable: false),
                    LocationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Members_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Members_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Members_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Members_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Towns",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedComputerName = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedComputerName = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    LocationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Towns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Towns_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Towns_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Towns_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedComputerName = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedComputerName = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ParentProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<decimal>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    CartId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartItems_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedComputerName = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedComputerName = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Filename = table.Column<string>(maxLength: 255, nullable: false),
                    Extension = table.Column<string>(nullable: false),
                    DirectoryName = table.Column<string>(maxLength: 10, nullable: false),
                    Revision = table.Column<string>(maxLength: 30, nullable: true),
                    SortOrder = table.Column<int>(nullable: true),
                    Attachment = table.Column<string>(nullable: true),
                    ProductId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductImages_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductPrices",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedComputerName = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedComputerName = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Value = table.Column<decimal>(nullable: false),
                    Type = table.Column<int>(nullable: true),
                    ProductId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPrices_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductPrices_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductPrices_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CurrentAccounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedComputerName = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedComputerName = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(maxLength: 255, nullable: true),
                    Title = table.Column<string>(maxLength: 255, nullable: false),
                    Balance = table.Column<int>(nullable: false),
                    RiskLimit = table.Column<int>(nullable: false),
                    MemberId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrentAccounts_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CurrentAccounts_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CurrentAccounts_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FavouritedProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedComputerName = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedComputerName = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    MemberId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouritedProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavouritedProducts_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FavouritedProducts_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavouritedProducts_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FavouritedProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductComments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedComputerName = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedComputerName = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(maxLength: 255, nullable: false),
                    Content = table.Column<string>(maxLength: 9999, nullable: false),
                    Rank = table.Column<int>(nullable: false),
                    IsAnonymous = table.Column<string>(nullable: false),
                    MemberId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductComments_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductComments_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductComments_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductComments_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Oders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedComputerName = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedComputerName = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    CustomerFirstname = table.Column<string>(maxLength: 255, nullable: false),
                    CustomerSurname = table.Column<string>(maxLength: 255, nullable: false),
                    CustomerEmail = table.Column<string>(maxLength: 255, nullable: false),
                    CustomerPhone = table.Column<string>(maxLength: 32, nullable: true),
                    PaymentTypeName = table.Column<string>(maxLength: 128, nullable: true),
                    PaymentProviderCode = table.Column<string>(maxLength: 128, nullable: true),
                    PaymentProviderName = table.Column<string>(maxLength: 128, nullable: true),
                    PaymentGatewayCode = table.Column<string>(maxLength: 128, nullable: true),
                    PaymentGatewayName = table.Column<string>(maxLength: 128, nullable: true),
                    ClientIp = table.Column<string>(maxLength: 32, nullable: true),
                    UserAgent = table.Column<string>(maxLength: 1028, nullable: true),
                    Currency = table.Column<string>(maxLength: 32, nullable: true),
                    CurrencyRates = table.Column<string>(maxLength: 9999, nullable: true),
                    Amount = table.Column<decimal>(nullable: true),
                    CouponDiscount = table.Column<decimal>(nullable: true),
                    TaxAmount = table.Column<decimal>(nullable: true),
                    PromotionDiscount = table.Column<decimal>(nullable: true),
                    GeneralAmount = table.Column<decimal>(nullable: true),
                    ShippingAmount = table.Column<decimal>(nullable: true),
                    AdditionalServiceAmount = table.Column<decimal>(nullable: true),
                    FinalAmount = table.Column<decimal>(nullable: true),
                    SumOfGainedPoints = table.Column<decimal>(nullable: true),
                    Installment = table.Column<int>(nullable: true),
                    InstallmentRate = table.Column<decimal>(nullable: true),
                    ExtraInstallment = table.Column<int>(nullable: true),
                    TransactionId = table.Column<string>(maxLength: 255, nullable: true),
                    HasUserNote = table.Column<bool>(nullable: true),
                    PaymentStatus = table.Column<string>(nullable: true),
                    ErrorMessage = table.Column<string>(maxLength: 9999, nullable: true),
                    DeviceType = table.Column<string>(nullable: true),
                    Referrer = table.Column<string>(maxLength: 9999, nullable: true),
                    InvoicePrintCount = table.Column<int>(nullable: true),
                    UseGiftPackage = table.Column<string>(maxLength: 9999, nullable: true),
                    GiftNote = table.Column<string>(maxLength: 9999, nullable: true),
                    MemberGroupName = table.Column<string>(maxLength: 255, nullable: true),
                    UsePromotion = table.Column<string>(nullable: true),
                    ShippingProviderCode = table.Column<string>(maxLength: 128, nullable: true),
                    ShippingProviderName = table.Column<string>(maxLength: 128, nullable: true),
                    ShippingCompanyName = table.Column<string>(maxLength: 128, nullable: true),
                    ShippingPaymentType = table.Column<string>(nullable: true),
                    Source = table.Column<string>(maxLength: 255, nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    ShippingAddresId = table.Column<Guid>(nullable: false),
                    MaillistId = table.Column<Guid>(nullable: true),
                    OrderDetailId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Oders_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Oders_Maillists_MaillistId",
                        column: x => x.MaillistId,
                        principalTable: "Maillists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Oders_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Oders_ShippingAddreses_ShippingAddresId",
                        column: x => x.ShippingAddresId,
                        principalTable: "ShippingAddreses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Oders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedComputerName = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedComputerName = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    VarKey = table.Column<string>(maxLength: 255, nullable: true),
                    VarValue = table.Column<string>(maxLength: 255, nullable: true),
                    OrderId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Oders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Oders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedComputerName = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedComputerName = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ProductName = table.Column<string>(maxLength: 255, nullable: false),
                    ProductSku = table.Column<string>(maxLength: 255, nullable: false),
                    ProductBarcode = table.Column<string>(maxLength: 255, nullable: true),
                    ProductPrice = table.Column<decimal>(nullable: false),
                    ProductCurrency = table.Column<string>(maxLength: 32, nullable: true),
                    ProductQuantity = table.Column<decimal>(nullable: false),
                    ProductTax = table.Column<int>(nullable: false),
                    ProductDiscount = table.Column<decimal>(nullable: true),
                    ProductMoneyOrderDiscount = table.Column<decimal>(nullable: true),
                    ProductWeight = table.Column<decimal>(nullable: false),
                    ProductStockTypeLabel = table.Column<string>(maxLength: 255, nullable: false),
                    Discount = table.Column<decimal>(nullable: false),
                    OrderId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_Oders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Oders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedComputerName", "CreatedDate", "CreatedIP", "CreatedUserId", "Email", "FirstName", "ImageUrl", "IsAdmin", "LastIPAddress", "LastLogin", "LastName", "ModifiedComputerName", "ModifiedDate", "ModifiedIP", "ModifiedUserId", "Password", "Status", "Title" },
                values: new object[] { new Guid("3a19834c-cc6d-4c68-9008-51fd6a2e4648"), null, null, null, null, "admin@admin.com", "admin", "/", null, "127.0.0.1", null, "admin", null, null, null, null, "123", 1, "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Brands_CreatedUserId",
                table: "Brands",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_ModifiedUserId",
                table: "Brands",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CreatedUserId",
                table: "CartItems",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ModifiedUserId",
                table: "CartItems",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_CreatedUserId",
                table: "Carts",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ModifiedUserId",
                table: "Carts",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CreatedUserId",
                table: "Categories",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ModifiedUserId",
                table: "Categories",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CreatedUserId",
                table: "Countries",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_ModifiedUserId",
                table: "Countries",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_CreatedUserId",
                table: "Currencies",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_ModifiedUserId",
                table: "Currencies",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentAccounts_CreatedUserId",
                table: "CurrentAccounts",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentAccounts_MemberId",
                table: "CurrentAccounts",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentAccounts_ModifiedUserId",
                table: "CurrentAccounts",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FavouritedProducts_CreatedUserId",
                table: "FavouritedProducts",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FavouritedProducts_MemberId",
                table: "FavouritedProducts",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_FavouritedProducts_ModifiedUserId",
                table: "FavouritedProducts",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FavouritedProducts_ProductId",
                table: "FavouritedProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_CountryId",
                table: "Locations",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_CreatedUserId",
                table: "Locations",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_ModifiedUserId",
                table: "Locations",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Maillists_CreatedUserId",
                table: "Maillists",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Maillists_ModifiedUserId",
                table: "Maillists",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_CountryId",
                table: "Members",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_CreatedUserId",
                table: "Members",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_LocationId",
                table: "Members",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_ModifiedUserId",
                table: "Members",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Oders_CreatedUserId",
                table: "Oders",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Oders_MaillistId",
                table: "Oders",
                column: "MaillistId");

            migrationBuilder.CreateIndex(
                name: "IX_Oders_ModifiedUserId",
                table: "Oders",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Oders_OrderDetailId",
                table: "Oders",
                column: "OrderDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Oders_ShippingAddresId",
                table: "Oders",
                column: "ShippingAddresId");

            migrationBuilder.CreateIndex(
                name: "IX_Oders_UserId",
                table: "Oders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderAddresses_CreatedUserId",
                table: "OrderAddresses",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderAddresses_ModifiedUserId",
                table: "OrderAddresses",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_CreatedUserId",
                table: "OrderDetails",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ModifiedUserId",
                table: "OrderDetails",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_CreatedUserId",
                table: "OrderItems",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ModifiedUserId",
                table: "OrderItems",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductComments_CreatedUserId",
                table: "ProductComments",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductComments_MemberId",
                table: "ProductComments",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductComments_ModifiedUserId",
                table: "ProductComments",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductComments_ProductId",
                table: "ProductComments",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_CreatedUserId",
                table: "ProductImages",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ModifiedUserId",
                table: "ProductImages",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPrices_CreatedUserId",
                table: "ProductPrices",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPrices_ModifiedUserId",
                table: "ProductPrices",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPrices_ProductId",
                table: "ProductPrices",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CreatedUserId",
                table: "Products",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CurrencyId",
                table: "Products",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ModifiedUserId",
                table: "Products",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ParentId",
                table: "Products",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UserId",
                table: "Products",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingAddreses_CreatedUserId",
                table: "ShippingAddreses",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingAddreses_ModifiedUserId",
                table: "ShippingAddreses",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Towns_CreatedUserId",
                table: "Towns",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Towns_LocationId",
                table: "Towns",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Towns_ModifiedUserId",
                table: "Towns",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CreatedUserId",
                table: "Users",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ModifiedUserId",
                table: "Users",
                column: "ModifiedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Oders_OrderDetails_OrderDetailId",
                table: "Oders",
                column: "OrderDetailId",
                principalTable: "OrderDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Maillists_Users_CreatedUserId",
                table: "Maillists");

            migrationBuilder.DropForeignKey(
                name: "FK_Maillists_Users_ModifiedUserId",
                table: "Maillists");

            migrationBuilder.DropForeignKey(
                name: "FK_Oders_Users_CreatedUserId",
                table: "Oders");

            migrationBuilder.DropForeignKey(
                name: "FK_Oders_Users_ModifiedUserId",
                table: "Oders");

            migrationBuilder.DropForeignKey(
                name: "FK_Oders_Users_UserId",
                table: "Oders");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Users_CreatedUserId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Users_ModifiedUserId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ShippingAddreses_Users_CreatedUserId",
                table: "ShippingAddreses");

            migrationBuilder.DropForeignKey(
                name: "FK_ShippingAddreses_Users_ModifiedUserId",
                table: "ShippingAddreses");

            migrationBuilder.DropForeignKey(
                name: "FK_Oders_Maillists_MaillistId",
                table: "Oders");

            migrationBuilder.DropForeignKey(
                name: "FK_Oders_OrderDetails_OrderDetailId",
                table: "Oders");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "CurrentAccounts");

            migrationBuilder.DropTable(
                name: "FavouritedProducts");

            migrationBuilder.DropTable(
                name: "OrderAddresses");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "ProductComments");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "ProductPrices");

            migrationBuilder.DropTable(
                name: "Towns");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Maillists");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Oders");

            migrationBuilder.DropTable(
                name: "ShippingAddreses");
        }
    }
}
