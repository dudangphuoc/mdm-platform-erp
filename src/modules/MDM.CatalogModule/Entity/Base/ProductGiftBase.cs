using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CatalogModule.Entity.Base;

[Table("ProductGifts")]
public abstract class ProductGiftBase<TProduct, TGift> : CreationAuditedEntity<Guid>
{
    public virtual TProduct Product { get; set; }

    public virtual TGift Gift { get; set; }
}
