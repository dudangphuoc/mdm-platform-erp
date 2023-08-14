using MDM.Common.EntityFactory;
using MDM.PaymentModule.Entities;

namespace Identity.Core.Entities;

[InjectContext]
public class ReceiptItem : ReceiptItemBase
{
    public Invoice Invoice { get; set; }
}
