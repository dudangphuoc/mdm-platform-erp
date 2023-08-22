using MDM.Common.EntityFactory;
using MDM.ModuleBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CatalogModule.Entity.Price;

//[InjectContext]
[Table("PriceListAssignments")]
public abstract class PriceListAssignmentBase<TPriceList, TCustomerSegmentType> : MDMFullAuditedEntityBase
{
    [Column(TypeName = "nvarchar(4000)")]
    public string? ConditionExpression { get; set; }

    public TPriceList PriceList { get; set; }

    public TCustomerSegmentType CustomerSegmentType { get; set; }
}