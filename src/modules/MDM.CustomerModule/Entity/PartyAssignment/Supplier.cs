using Abp.Domain.Entities.Auditing;
using MDM.Common.EntityFactory;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CustomerModule.Entity.PartyAssignment;

[InjectContext]
[Table("Supplier")]
public class Supplier : CreationAuditedEntity<Guid>
{
    public string EntityName { get; set; }

    public Guid EntityId { get; set; }

    public bool AnonymousFlag { get; set; }
}
