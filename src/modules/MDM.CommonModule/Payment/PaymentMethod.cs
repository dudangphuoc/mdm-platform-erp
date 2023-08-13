using MDM.Common.EntityFactory;
using MDM.ModuleBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CommonModule.Payment;

[InjectContext]
[Table("PaymentMethod")]
public class PaymentMethod : MDMFullAuditedEntityBase
{
    [Column(TypeName = "nvarchar(200)")]
    public string Name { get; set; }

    [Column(TypeName = "varchar(500)")]
    public string LogoUrl { get; set; }

    [Column(TypeName = "nvarchar(500)")]
    public string Description { get; set; }
}
