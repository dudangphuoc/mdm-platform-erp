using MDM.CatalogModule.Entity.Base;
using MDM.Common.EntityFactory;
using System.ComponentModel.DataAnnotations.Schema;

namespace Identity.Core.Entities;

[InjectContext]
public class ProductBundle : ProductBundleBase<ProductBundleColection>
{
    public Guid ProductId { get; set; }

    [ForeignKey("ProductId")]
    public Product Product { get; set; }
}
