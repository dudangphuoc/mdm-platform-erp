using MDM.Common.EntityFactory;
using MDM.OrderModule.Entities;

namespace Identity.Core.Entities;

[InjectContext]
public class OrderLine : OrderItemBase<Order, Product>
{
}
