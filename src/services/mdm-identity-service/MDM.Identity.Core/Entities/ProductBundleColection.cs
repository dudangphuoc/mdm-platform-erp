using MDM.CatalogModule.Entity.Base;
using MDM.Common.EntityFactory;

namespace Identity.Core.Entities;

[InjectContext]
public class ProductBundleColection : ProductBundleColectionBase<Product, ProductBundle>
{
}
