using MDM.ModuleBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.PaymentModule.Entities;

[Table("Payment")]
public abstract class PaymentBase<TOrder, TParty, TPaymentMethod> : MDMFullAuditedEntityBase
{
    public Guid ReceiptId { get; set; }

    [Column(TypeName = "varchar(100)")]
    public string PaymentCode { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal PaymentFeeAmount { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalAmount { get; set; }

    public EPaymentStatus PaymentStatus { get; set; }

    public TOrder Order { get; set; }

    public TParty Party { get; set; }

    public TPaymentMethod PaymentMethod { get; set; }

    [ForeignKey(nameof(ReceiptId))]
    public Receipt Receipt { get; set; }
}
