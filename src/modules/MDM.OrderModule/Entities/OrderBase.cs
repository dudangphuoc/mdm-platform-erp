using MDM.ModuleBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.OrderModule.Entities;

public class OrderBase<TParty, TPaymentMethod> : MDMFullAuditedEntityBase
{
    [Column(TypeName = "varchar(50)")]
    public string OrderCode { get; set; }

    public TParty Party { get; set; }

    public TPaymentMethod PaymentMethod { get; set; }
}
