using MDM.Common.EntityFactory;
using MDM.ModuleBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CatalogModule.Entity.Product;

[InjectContext]
[Table("ProductBundles")]
public class ProductBundle : MDMFullAuditedEntityBase
{
    public string Name { get; set; }

    public Guid? ProductRelated { get; set; }

    public required ICollection<ProductBundleColection> BundleColection { get; set; }
}
