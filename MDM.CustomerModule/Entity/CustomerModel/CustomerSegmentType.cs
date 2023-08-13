using Abp.Domain.Entities.Auditing;
using MDM.Common.EntityFactory;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CustomerModule.Entity.CustomerModel;

[InjectContext]
[Table("CustomerSegmentTypes")]
public class CustomerSegmentType : CreationAuditedEntity<Guid>
{
    [Column(TypeName = "nvarchar(500)")]
    public string Name { get; set; }

    public int? Priority { get; set; }

    public ICollection<CustomerSegment> CustomerSegments { get; set; }
}