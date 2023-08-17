using MDM.ModuleBase;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CatalogModule.Entity.Base;

[Table("Products")]
public abstract class ProductBase<TGifts, TBundle, TRelated> : MDMFullAuditedEntityBase
{
    /// <summary>
    /// sản phảm mới
    /// </summary>
    [DefaultValue(false)]
    public required bool MarkAsNew { get; set; }

    /// <summary>
    /// Theo dõi số lượng kho
    /// </summary>
    [DefaultValue(false)]
    public required bool StockTrackingIsEnabled { get; set; }

    /// <summary>
    /// Loại sản phẩm
    /// </summary>
    public EProductType ProductType { get; set; }

    public int DisplayOrder { get; set; }

    public int? StockQuantity { get; set; }

    public decimal Price { get; set; }

    public decimal? SalePrice { get; set; }

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

    [Column(TypeName = "nvarchar(1000)")]
    public string Description { get; set; }

    [Column(TypeName = "varchar(100)")]
    public string? Sku { get; set; }

    [Column(TypeName = "varchar(100)")]
    public string? Gtin { get; set; }

    [Column(TypeName = "nvarchar(4000)")]
    public string? Thumbnail { get; set; }

    public DateTime? PublishedTime { get; set; }

    public DateTime? MarkAsNewStartDate { get; set; }

    public DateTime? MarkAsNewEndDate { get; set; }

    public virtual ICollection<TGifts> Gifts { get; set; }

    public virtual ICollection<TBundle>? ProductBundles { get; set; }

    public virtual ICollection<TRelated> Relateds { get; set; }
}
