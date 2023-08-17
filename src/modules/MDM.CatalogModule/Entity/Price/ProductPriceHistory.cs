using Abp.Domain.Entities.Auditing;
using MDM.Common.EntityFactory;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CatalogModule.Entity.Price;

[Table("ProductPriceHistory")]
public class ProductPriceHistoryBase<TProduct> : CreationAuditedEntity<Guid>
{
    public Guid ProductId { get; set; }

    [Column(TypeName = "decimal(18,4)")]
    public decimal OldPrice { get; set; }

    [Column(TypeName = "decimal(18,4)")]
    public decimal NewPrice { get; set; }

    [Column(TypeName = "decimal(18,4)")]
    public decimal? SpecialPrice { get; set; }

    public DateTime? SpecialPriceFromDate { get; set; }

    public DateTime? SpecialPriceToDate { get; set; }

    public TProduct Product { get; set; }
}
