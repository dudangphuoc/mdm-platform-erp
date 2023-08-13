using Abp.Domain.Entities.Auditing;
using Castle.MicroKernel.SubSystems.Conversion;
using MDM.Common.EntityFactory;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CustomerModule.Entity.CustomerModel;

[InjectContext]
[Table("CustomerTypes")]
public class CustomerType : CreationAuditedEntity<Guid>
{
    [Column(TypeName = "varchar(200)")]
    public string Name { get; set; }

    public Guid? CustomerTypeGroupId { get; set; }

    public CustomerTypeGroup? CustomerTypeGroup { get; set; }

    [Column(TypeName = "nvarchar(200)")]
    public string? Desc { get; set; }
}