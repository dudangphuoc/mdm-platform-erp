using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;
using ProductEntity = MDM.CatalogModule.Product.Product;

namespace MDM.CatalogModule.Price;

public class ProductPriceHistory : CreationAuditedEntity<Guid>
{
    [ForeignKey(nameof(ProductId))]
    public ProductEntity Product { get; set; }

    public Guid ProductId { get; set; }

    [Column(TypeName = "decimal(18,4)")]
    public decimal OldPrice { get; set; }

    [Column(TypeName = "decimal(18,4)")]
    public decimal NewPrice { get; set; }

    [Column(TypeName = "decimal(18,4)")]
    public decimal? SpecialPrice { get; set; }

    public DateTime? SpecialPriceFromDate { get; set; }

    public DateTime? SpecialPriceToDate { get; set; }
}
