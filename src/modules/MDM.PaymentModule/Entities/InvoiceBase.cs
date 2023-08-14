using MDM.ModuleBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.PaymentModule.Entities;

public class InvoiceBase<TReference> : MDMFullAuditedEntityBase
{
    public Guid? OrderId { get; set; }

    [Column(TypeName = "varchar(50)")]
    public string InvoiceCode { get; set; }

    public DateTime InvoiceDate { get; set; }

    public EInvoiceStatus InvoiceStatus { get; set; }

    [DataType("decimal(18,2)")]
    public decimal TotalAmount { get; set; }

    [Column(TypeName = "nvarchar(1000)")]
    public string Note { get; set; }

    public TReference Order { get; set; }

    public ICollection<ReceiptItemBase<TReference>> ReceiptItems { get; set; }
}
