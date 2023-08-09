using MDM.ModuleBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CatalogModule.Product;

[Table("ProductBundles")]
public class ProductBundle : MDMFullAuditedEntityBase
{
    public Guid ProductId { get; set; }

    public Guid ProductRelated { get; set; }

    public ProductBundleType BundleType { get; set; }
}
