using MDM.Common.EntityFactory;
using MDM.ModuleBase;
using System.ComponentModel.DataAnnotations.Schema;
namespace MDM.CatalogModule.Entity.Product;

[InjectContext]
[Table("Products")]
public class ProductBase : MDMFullAuditedEntityBase
{
    public Guid? BrandId { get; set; }

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

    [Column(TypeName = "nvarchar(4000)")]
    public string? Thumbnail { get; set; }

    public bool? MarkAsNew { get; set; }

    public DateTime? MarkAsNewStartDate { get; set; }

    public DateTime? MarkAsNewEndDate { get; set; }

    [ForeignKey(nameof(BrandId))]
    public Brand? Brand { get; set; }

    [ForeignKey(nameof(ProductUnitId))]
    public ProductUnit? ProductUnit { get; set; }

    public ICollection<ProductMedia>? ProductMedias { get; set; }

    public ICollection<ProductBundle> ProductBundles { get; set; }
}
