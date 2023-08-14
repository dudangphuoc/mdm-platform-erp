using Abp.Domain.Entities;
using MDM.ModuleBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.OrderModule.Entities;

[Table("OrderItems")]
public abstract class OrderItemBase<TOrder, TProduct> : MDMFullAuditedEntityBase
    where TOrder : Entity<Guid>
    where TProduct : Entity<Guid>
{
    [Column(TypeName = "nvarchar(500)")]
    public string ProductName { get; set; }

    public string? Thumbnail { get; set; }

    public int? ProductType { get; set; }

    [DataType("Decimal(18,2)")]
    public decimal UnitPrice { get; set; }

    [DataType("Decimal(18,2)")]
    public decimal Quantity { get; set; }

    [DataType("Decimal(18,2)")]
    public decimal DiscountAmount { get; set; }

    public TOrder Order { get; set; }

    public TProduct Product { get; set; }
}
