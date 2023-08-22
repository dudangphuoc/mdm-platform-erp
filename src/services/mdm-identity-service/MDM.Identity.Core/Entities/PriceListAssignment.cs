using MDM.CatalogModule.Entity.Price;
using MDM.Common.EntityFactory;
using MDM.CustomerModule.Entity.CustomerModel;

namespace Identity.Core.Entities;

[InjectContext]
public class PriceListAssignment : PriceListAssignmentBase<PriceList, CustomerSegmentType>
{

}
