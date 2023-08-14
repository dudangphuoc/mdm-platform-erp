using MDM.Common.EntityFactory;
using MDM.CommonModule.Payment;
using MDM.CustomerModule.Entity.PartyModel;
using MDM.OrderModule.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Identity.Core.Entities;

[InjectContext]
public class Order : OrderBase<PartiesBase, PaymentMethod>
{
    public Guid InvoidId { get; set; }

    public ICollection<Payment>? Payments { get; set; }

    [ForeignKey(nameof(InvoidId))]
    public Invoice? Invoice { get; set; }

    public ICollection<OrderLine>? OrderItems { get; set; }
}
