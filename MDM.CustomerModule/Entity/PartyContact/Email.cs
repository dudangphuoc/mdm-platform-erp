using Abp.Domain.Entities.Auditing;
using MDM.Common.EntityFactory;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CustomerModule.Entity.PartyContact;

[InjectContext]
[Table("Emails")]
public class Email : CreationAuditedEntity<Guid>
{
    [Column(TypeName = "nvarchar(200)")]
    public string EmailAddress { get; set; }
}