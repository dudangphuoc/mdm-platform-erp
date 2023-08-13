using Abp.Domain.Entities.Auditing;
using MDM.CatalogModule.Entity.Category;
using MDM.CatalogModule.Entity.Product;
using MDM.Common.EntityFactory;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CatalogModule.Entity;

[InjectContext]
[Table("ProductCategories")]
public class ProductCategory : CreationAuditedEntity<Guid>
{
    public Guid ProductId { get; set; }

    public Guid CategoryId { get; set; }

    [ForeignKey("ProductId")]
    public virtual ProductBase Product { get; set; }

    [ForeignKey("CategoryId")]
    public virtual CategoryBase Category { get; set; }
}
