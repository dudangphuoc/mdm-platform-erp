using MDM.ModuleBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CatalogModule.Entity.Product;

[Table("ProductBundleColections")]
public class ProductBundleColection : MDMFullAuditedEntityBase
{
    public Guid ProductRelated { get; set; }

    public Guid ProductBundleId { get; set; }

    [ForeignKey(nameof(ProductBundleId))]
    public ProductBundle ProductBundle { get; set; }

    [ForeignKey(nameof(ProductRelated))]
    public ProductBase Product { get; set; }
}
