using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.OrderModule.Entities;

public class ShippingType : CreationAuditedEntity<Guid>, IPassivable
{
    [Column(TypeName = "nvarchar(200)")]
    public string Name { get; set; }

    public bool IsActive { get; set; }
}
