using Abp.Domain.Entities.Auditing;
using MDM.Common.EntityFactory;
using System.ComponentModel.DataAnnotations.Schema;


namespace MDM.CatalogModule.Entity;

[Table("ProductCategories")]
public class ProductCategoryBase<TProduct, TCategory> : CreationAuditedEntity<Guid>
{
    public virtual TProduct Product { get; set; }

    public virtual TCategory Category { get; set; }
}
