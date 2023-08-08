using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace MDM.ModuleBase;

public class MDMFullAuditedEntityBase : FullAuditedEntity<Guid>, IMayHaveTenant
{
    public int? TenantId { get; set; }

}
