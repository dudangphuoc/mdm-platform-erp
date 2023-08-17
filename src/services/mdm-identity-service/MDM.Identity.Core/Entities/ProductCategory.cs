using MDM.CatalogModule.Entity;
using MDM.CatalogModule.Entity.Category;
using MDM.Common.EntityFactory;

namespace Identity.Core.Entities;

[InjectContext]
public class ProductCategory : ProductCategoryBase<Product, Category>
{
}
