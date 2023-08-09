using MDM.ModuleBase;
using System.ComponentModel.DataAnnotations.Schema;
using ProductEntity = MDM.CatalogModule.Product.Product;
namespace MDM.CatalogModule.Price;

[Table("Price")]
public class Price : MDMFullAuditedEntityBase
{
    [ForeignKey(nameof(PriceListId))]
    public PriceList PriceList { get; set; }

    public Guid PriceListId { get; set; }

    public Guid ProductId { get; set; }

    [ForeignKey(nameof(ProductId))]
    public ProductEntity Product { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal BasePrice { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal? SalePrice { get; set; }

    public float MinQuantity { get; set; }

    

    [Column(TypeName = "nvarchar(4000)")]
    public string? Description { get; set; }

    public EComputePrice? ComputePrice { get; set; } = EComputePrice.Fixed;

    [Column(TypeName = "decimal(18,2)")]
    public decimal? Percent { get; set; }
}
