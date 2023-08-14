using MDM.Common.EntityFactory;
using MDM.ModuleBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.PaymentModule.Entities;


[Table("ReceiptItem")]
public abstract class ReceiptItemBase : MDMFullAuditedEntityBase
{
    public Guid ReceiptId { get; set; }

    public Guid InvoiceId { get; set; }

    [DataType("decimal(18,2)")]
    public decimal TotalAmount { get; set; }
}
