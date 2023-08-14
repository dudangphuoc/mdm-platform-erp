using MDM.Common.EntityFactory;
using MDM.CommonModule.Payment;
using MDM.CustomerModule.Entity.PartyModel;
using MDM.PaymentModule.Entities;

namespace Identity.Core.Entities
{
    [InjectContext]
    public class Payment : PaymentBase<Order, PartiesBase, PaymentMethod>
    {

    }
}
