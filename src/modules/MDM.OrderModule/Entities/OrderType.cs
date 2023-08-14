using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using MDM.Common.EntityFactory;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.OrderModule.Entities;


[InjectContext]
[Table("OrderTypes")]
public class OrderType : CreationAuditedEntity<Guid>, IPassivable
{
    [Column(TypeName = "varchar(20)")]
    public string Code { get; set; }

    [Column(TypeName = "nvarchar(200)")]
    public string Name { get; set; }

    public bool IsActive { get; set; }
}
