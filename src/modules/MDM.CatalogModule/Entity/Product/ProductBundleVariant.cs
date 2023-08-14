using Abp.Domain.Entities.Auditing;
using MDM.Common.EntityFactory;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CatalogModule.Entity.Product;

[InjectContext]
[Table("ProductBundleVariants")]
public class ProductBundleVariant : CreationAuditedEntity<Guid>
{
    public Guid ProductVariantRelated { get; set; }

    public Guid ProductBundleColectionId { get; set; }

    [ForeignKey(nameof(ProductVariantRelated))]
    public ProductVariant ProductVariant { get; set; }

    [ForeignKey(nameof(ProductBundleColectionId))]
    public ProductBundleColection ProductBundleColection { get; set; }
}
