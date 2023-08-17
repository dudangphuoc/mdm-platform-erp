using MDM.ModuleBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CatalogModule.Entity.Base;

[Table("ProductRelated")]
public abstract class ProductRelatedBase<TProduct> : MDMFullAuditedEntityBase
{
    public ERelatedType RelatedType { get; set; }

    public virtual TProduct Product { get; set; }
}
