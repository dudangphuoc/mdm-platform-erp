using MDM.Common.EntityFactory;
using MDM.ModuleBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CatalogModule.Entity.Price;

[InjectContext]
[Table("PriceListAssignments")]
public class PriceListAssignment : MDMFullAuditedEntityBase
{
    [ForeignKey(nameof(PriceListId))]
    public PriceList PriceList { get; set; }

    public Guid PriceListId { get; set; }

    public Guid CustomerSegmentTypeId { get; set; }

    [Column(TypeName = "nvarchar(4000)")]
    public string? ConditionExpression { get; set; }
}