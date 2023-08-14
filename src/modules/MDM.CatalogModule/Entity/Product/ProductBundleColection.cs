using Abp.Domain.Entities.Auditing;
using MDM.Common.EntityFactory;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CatalogModule.Entity.Product;

[InjectContext]
[Table("ProductBundleColections")]
public class ProductBundleColection : CreationAuditedEntity<Guid>
{
    public Guid ProductRelated { get; set; }

    public Guid ProductBundleId { get; set; }

    [DataType("Decimal(18,2)")]
    public decimal Quantity { get; set; }

    [ForeignKey(nameof(ProductBundleId))]
    public ProductBundle ProductBundle { get; set; }

    [ForeignKey(nameof(ProductRelated))]
    public ProductBase Product { get; set; }

    public ICollection<ProductBundleVariant> ProductBundleVariants { get; set; }
}


