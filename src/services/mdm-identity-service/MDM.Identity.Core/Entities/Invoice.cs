using MDM.Common.EntityFactory;
using MDM.PaymentModule.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Identity.Core.Entities;

[InjectContext]
public class Invoice : InvoiceBase<Order>
{
    public Guid? OrderId { get; set; }

    [ForeignKey(nameof(OrderId))]
    override public Order Order { get; set; }

    public ICollection<ReceiptItem> ReceiptItems { get; set; }

}
