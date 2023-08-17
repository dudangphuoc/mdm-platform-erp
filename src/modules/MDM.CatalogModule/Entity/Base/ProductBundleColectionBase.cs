using Abp.Domain.Entities.Auditing;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CatalogModule.Entity.Base;


[Table("ProductBundleColections")]
public abstract class ProductBundleColectionBase<TProduct, TBundle> : CreationAuditedEntity<Guid>
{
    [DefaultValue(false)]
    public bool IsPrimary { get; set; }

    public float Quantity { get; set; }

    public virtual TProduct Product { get; set; }

    public virtual TBundle Bundle { get; set; }
}


