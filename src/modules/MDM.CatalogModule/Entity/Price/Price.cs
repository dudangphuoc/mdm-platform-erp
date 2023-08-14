using MDM.Common.EntityFactory;
using MDM.ModuleBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CatalogModule.Entity.Price;

[InjectContext]
[Table("Price")]
public class Price : MDMFullAuditedEntityBase
{
    public Guid PriceListId { get; set; }

    public string EntityName { get; set; }

    public Guid EntityId { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal BasePrice { get; set; }

    public bool IsPrimary { get; set; }

    public float MinQuantity { get; set; }

    [Column(TypeName = "nvarchar(4000)")]
    public string? Description { get; set; }

    public EComputePrice? ComputePrice { get; set; } = ModuleBase.EComputePrice.Fixed;

    [Column(TypeName = "decimal(18,2)")]
    public decimal? Percent { get; set; }

    [ForeignKey(nameof(PriceListId))]
    public PriceList PriceList { get; set; }
}