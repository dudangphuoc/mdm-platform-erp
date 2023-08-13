using Abp.Domain.Entities.Auditing;
using MDM.Common.EntityFactory;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CustomerModule.Entity.PartyContact;

[InjectContext]
[Table("TelePhones")]
public class TelePhone : CreationAuditedEntity<Guid>
{
    [Column(TypeName = "nvarchar(500)")]
    public string TelephoneNumber { get; set; }

    [Column(TypeName = "nvarchar(500)")]
    public string? ExtensionNumber { get; set; }
}