using MDM.Common.EntityFactory;
using MDM.ModuleBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CommonModule.Payment;

[InjectContext]
[Table("PaymentType")]
public class PaymentType : MDMFullAuditedEntityBase
{
    [Column(TypeName = "nvarchar(200)")]
    public string Name { get; set; }

    [Column(TypeName = "nvarchar(500)")]
    public string Description { get; set; }
}
