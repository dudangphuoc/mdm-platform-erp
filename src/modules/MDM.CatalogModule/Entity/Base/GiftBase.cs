using MDM.ModuleBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CatalogModule.Entity.Base;

[Table("Gifts")]
public abstract class GiftBase<TProducts, TGiftItems> : MDMFullAuditedEntityBase, IMayHaveEffectDate
{
    public virtual EProductGiftType ProductGiftType { get; set; }

    public virtual int MaxChoice { get; set; }

    [Column(TypeName = "nvarchar(1000)")]
    public string Description { get; set; }

    public DateTime? EffectStartDate { get; set; }

    public DateTime? EffectEndDate { get; set; }

    public virtual ICollection<TGiftItems> GiftItems { get; set; }

    public virtual ICollection<TProducts> Products { get; set; }
}
