using MDM.CatalogModule.Entity.Price;
using MDM.Common.EntityFactory;

namespace Identity.Core.Entities;

[InjectContext]
public class Price : PriceBase<PriceList>
{
}

