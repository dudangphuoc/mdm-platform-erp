using MDM.Common.EntityFactory;
using MDM.ModuleBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CustomerModule.Entity.CustomerModel;

[InjectContext]
[Table("CustomerSegments")]
public class CustomerSegment : MDMFullAuditedEntityBase
{
    public Guid CustomerId { get; set; }

    public Guid? CustomerSegmentTypeId { get; set; }

    [ForeignKey(nameof(CustomerSegmentTypeId))]
    public CustomerSegmentType? CustomerSegmentType { get; set; }

    [ForeignKey(nameof(CustomerId))]
    public CustomerBase? Customer { get; set; }

}