﻿using MDM.CatalogModule.Price;
using MDM.ModuleBase;
using System.ComponentModel.DataAnnotations.Schema;
using PriceEntity = MDM.CatalogModule.Price.Price;
namespace MDM.CatalogModule.Product;

[Table(nameof(Product))]
public class Product : MDMFullAuditedEntityBase
{
    [ForeignKey(nameof(BrandId))]
    public Brand? Brand { get; set; }
    public Guid? BrandId { get; set; }

    [ForeignKey(nameof(ProductUnitId))]
    public ProductUnit? ProductUnit { get; set; }
    public Guid? ProductUnitId { get; set; }

    [Column(TypeName = "nvarchar(500)")]
    public string Name { get; set; }

    [Column(TypeName = "varchar(500)")]
    public string Slug { get; set; }

    [Column(TypeName = "nvarchar(500)")]
    public string? MetaTitle { get; set; }

    [Column(TypeName = "nvarchar(1000)")]
    public string? MetaKeyword { get; set; }

    [Column(TypeName = "nvarchar(4000)")]
    public string? MetaDescription { get; set; }

    [Column(TypeName = "nvarchar(4000)")]
    public string ShortDescription { get; set; }

    public string Description { get; set; }

    public int DisplayOrder { get; set; }

    public bool IsPublished { get; set; }

    public DateTime? PublishedTime { get; set; }

    public bool? StockTrackingIsEnabled { get; set; }

    public int? StockQuantity { get; set; }

    [Column(TypeName = "varchar(100)")]
    public string? Sku { get; set; }

    [Column(TypeName = "varchar(100)")]
    public string? Gtin { get; set; }

    public decimal Price { get; set; }

    public decimal? SalePrice { get; set; }

    public EProductType? ProductType { get; set; } = EProductType.Simple;

    [Column(TypeName = "nvarchar(4000)")]
    public string? Thumbnail { get; set; }

    public bool? MarkAsNew { get; set; }

    public DateTime? MarkAsNewStartDate { get; set; }

    public DateTime? MarkAsNewEndDate { get; set; }

    public ICollection<ProductMedia>? ProductMedias { get; set; }

    public ICollection<PriceEntity>? ProductPrices { get; set; }
    //public ProductFeature ProductFeature { get; set; }
    //public ICollection<ProductVariant>? ProductVariants { get; set; }

}
