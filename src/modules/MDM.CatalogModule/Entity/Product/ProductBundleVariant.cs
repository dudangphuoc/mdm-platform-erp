using Abp.Domain.Entities.Auditing;
using MDM.Common.EntityFactory;
using MDM.ModuleBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CatalogModule.Entity.Product;

[InjectContext]
[Table("ProductBundleVariants")]
public class ProductBundleVariant : CreationAuditedEntity<Guid> , IMayHavePrimary
{
    public Guid ProductVariantRelated { get; set; }

    public Guid ProductBundleColectionId { get; set; }

    public bool IsPrimary { get; set; }

    [ForeignKey(nameof(ProductVariantRelated))]
    public ProductVariant ProductVariant { get; set; }

    [ForeignKey(nameof(ProductBundleColectionId))]
    public ProductBundleColection ProductBundleColection { get; set; }
}
