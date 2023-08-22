using MDM.CatalogModule.Entity.Base;
using MDM.CatalogModule.Entity.Price;
using MDM.CatalogModule.Entity.Product;
using MDM.Common.EntityFactory;

namespace Identity.Core.Entities;

[InjectContext]
public class Product : ProductBase<Gift, ProductBundle, ProductRelated>
{
    public ProductUnit? ProductUnit { get; set; }

    public Brand? Brand { get; set; }

    public ICollection<ProductMedia>? ProductMedias { get; set; }

    public ICollection<ProductCategory>? ProductCategories { get; set; }

    public ICollection<Price>? ProductPrices { get; set; }

    public ICollection<ProductBundleColection> ProductBundleColections { get; set; }
}
