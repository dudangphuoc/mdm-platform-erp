using Abp.Domain.Entities.Auditing;
using Castle.MicroKernel.SubSystems.Conversion;
using MDM.Common.EntityFactory;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CustomerModule.Entity.CustomerModel;

[InjectContext]
[Table("CustomerTypeGroups")]
public class CustomerTypeGroup : CreationAuditedEntity<Guid>
{
    [Column(TypeName = "varchar(200)")]
    public string Name { get; set; }
}