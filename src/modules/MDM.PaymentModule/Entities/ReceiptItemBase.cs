using MDM.ModuleBase;
using System.ComponentModel.DataAnnotations;

namespace MDM.PaymentModule.Entities;


public class ReceiptItemBase<TOrder> : MDMFullAuditedEntityBase
{
    public Guid ReceiptId { get; set; }

    public Guid InvoiceId { get; set; }

    [DataType("decimal(18,2)")]
    public decimal TotalAmount { get; set; }

    public InvoiceBase<TOrder> Invoice { get; set; }
}
