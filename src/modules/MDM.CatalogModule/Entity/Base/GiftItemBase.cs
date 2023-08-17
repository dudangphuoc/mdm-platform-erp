using MDM.ModuleBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDM.CatalogModule.Entity.Base;

[Table("GiftItems")]
public abstract class GiftItemBase<TGiftRelateds, TGift> : MDMFullAuditedEntityBase
{
    public float Quantity { get; set; }

    public TGift Gift { get; set; }

    public virtual ICollection<TGiftRelateds> GiftRelateds { get; set; }
}
