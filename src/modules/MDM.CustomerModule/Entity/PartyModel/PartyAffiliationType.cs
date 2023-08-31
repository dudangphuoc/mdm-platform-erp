using Abp.Domain.Entities.Auditing;
using MDM.Common.EntityFactory;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CustomerModule.Entity.PartyModel;

[InjectContext]
[Table("PartyAffiliationTypes")]
public class PartyAffiliationType : CreationAuditedEntity<Guid>
{
    [Column(TypeName = "nvarchar(200)")]
    public string Name { get; set; }                  
    
    [Column(TypeName = "nvarchar(200)")]
    public string? Description { get; set; }
}